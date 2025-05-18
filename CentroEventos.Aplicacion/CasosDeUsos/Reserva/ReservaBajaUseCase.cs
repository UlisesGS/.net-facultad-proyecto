namespace CentroEventos.Aplicacion
{
    public class ReservaBajaUseCase(IReservaRepositorio repoReserva, IServicioAutorizacion servicioAutorizacion){
            private readonly IReservaRepositorio _repositorioReserva = repoReserva;
            private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
        

        public void Ejecutar(int idReserva, int idUsuario){

            if(!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.ReservaBaja)){
                throw new FalloAutorizacionException("ERROR - No estas autorizado.");
            }

            if (!_repositorioReserva.ExistsById(idReserva)) {
                throw new EntidadNotFoundException("ERROR - La reserva no es valida.");
            }
        
            _repositorioReserva.Eliminar(idReserva);
        
        }
    }
}
