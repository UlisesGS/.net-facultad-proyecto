using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUsos.Reservas
{
    public class ReservaListarUseCase(IReservaRepositorio repoReserva){
        private readonly IReservaRepositorio _repositorioReserva = repoReserva;
        

        public List<Reserva> Ejecutar(){

            return _repositorioReserva.Listar();
        
        }
    }
}
