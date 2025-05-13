using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion
{
    public class CancelarReservaUseCase
    {
        private readonly IReservaRepositorio _repositorioReserva;

        public CancelarReservaUseCase(IReservaRepositorio repoReserva){
            _repositorioReserva = repoReserva;
        }

        public void Ejecutar(Reserva reserva){

            var auxReserva = _repositorioReserva.GetById(reserva.Id);
        
            if(reserva==null){
                throw new ValidacionException ("ERROR - La reserva no existe.");
            }

            if(reserva.EstadoAsistencia!=EnumEstadoAsistencia.pendiente){
                throw new ValidacionException ("ERROR - La reserva ya expiro.");
            }

            reserva.EstadoAsistencia=EnumEstadoAsistencia.cancelado;

            _repositorioReserva.Modificar(reserva);
        }
    }
}
