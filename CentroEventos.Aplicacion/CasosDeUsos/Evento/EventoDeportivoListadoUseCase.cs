using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUsos.Evento
{
    public class EventoDeportivoListarUseCase(IEventoDeportivoRepositorio repoEvento){
            private readonly IEventoDeportivoRepositorio _repositorioEvento = repoEvento;
 
            public List<EventoDeportivo> Ejecutar(){

                return _repositorioEvento.Listar();
            
            }
    }
}
