namespace CentroEventos.Aplicacion
{
    public class EventoDeportivoListarUseCase(IEventoDeportivoRepositorio repoEvento){
            private readonly IEventoDeportivoRepositorio _repositorioEvento = repoEvento;
 
            public List<EventoDeportivo> Ejecutar(){

                return _repositorioEvento.Listar();
            
            }
    }
}
