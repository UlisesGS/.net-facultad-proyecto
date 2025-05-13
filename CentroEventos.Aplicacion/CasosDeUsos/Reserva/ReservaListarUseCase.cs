namespace CentroEventos.Aplicacion
{
    public class ReservaListarUseCase(IReservaRepositorio repoReserva){
            private readonly IReservaRepositorio _repositorioReserva = repoReserva;
        

        public List<Reserva> Ejecutar(){

            return _repositorioReserva.Listar();
        
        }
    }
}
