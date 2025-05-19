using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion{

    public class ListarEventosConCupoDisponibleUseCase(IReservaRepositorio repoReserva, IEventoDeportivoRepositorio repoEvento){

        private readonly IReservaRepositorio _repositorioReserva = repoReserva;
        private readonly IEventoDeportivoRepositorio _repositorioEvento = repoEvento;


        public List<EventoDeportivo> Ejecutar(){

            List<EventoDeportivo> listaEventoDeportivo = _repositorioEvento.ListarFechaFutura();
            List<EventoDeportivo> listaFinal = [];

            if(!listaEventoDeportivo.Any()){
                throw new ValidacionException("ERROR - No hay eventos disponibles.");
            }

            foreach(EventoDeportivo evento in listaEventoDeportivo){

                if (_repositorioReserva.QuantityCupo(evento.Id) < _repositorioEvento.CupoMaximo(evento.Id)){
                    listaFinal.Add(evento);
                }
            }

            if(!listaFinal.Any()){
                throw new ValidacionException("ERROR - No hay eventos disponibles.");
            }

            return listaFinal;
        }
    }
}