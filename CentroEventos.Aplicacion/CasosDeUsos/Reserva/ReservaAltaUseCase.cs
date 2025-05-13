namespace CentroEventos.Aplicacion
{
    public class  ReservaAltaUseCase(IReservaRepositorio repoReserva, IServicioAutorizacion servicioAutorizacion,ReservaValidador validador){
            private readonly IReservaRepositorio _repositorioReserva = repoReserva;
            private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
            private readonly ReservaValidador _validadorReserva =  validador;

            public void Ejecutar(Reserva reserva, int idUsuario){

                if(!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.ReservaAlta)){
                    throw new FalloAutorizacionException("ERROR - No estas autorizado.");
                }
            
                _validadorReserva.Validar(reserva);

                reserva.FechaAltaReserva = DateTime.Now;

                reserva.EstadoAsistencia = EnumEstadoAsistencia.pendiente;

                _repositorioReserva.Agregar(reserva);
            
            }

    }
}
