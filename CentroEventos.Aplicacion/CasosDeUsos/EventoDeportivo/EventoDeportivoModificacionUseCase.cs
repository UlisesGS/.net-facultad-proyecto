using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion
{
    public class EventoDeportivoModificacionUseCase(IEventoDeportivoRepositorio repoEvento, IServicioAutorizacion servicioAutorizacion,EventoDeportivoValidador validador){
            private readonly IEventoDeportivoRepositorio _repositorioEvento = repoEvento;
            private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
            private readonly EventoDeportivoValidador _validadorEvento =  validador;

            public void Ejecutar(EventoDeportivo evento, int idUsuario){
                
                var eventoAux = _repositorioEvento.BuscarPorId(evento.Id);

                if(!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.EventoModificacion)){
                    throw new FalloAutorizacionException("ERROR - No estas autorizado.");
                }
            
                if(eventoAux.FechaHoraInicio < DateTime.Now){
                    throw new OperacionInvalidaException("ERROR - La fecha expiro.");
                }

                if(evento.FechaHoraInicio < DateTime.Now){
                    throw new OperacionInvalidaException("ERROR - La fecha tiene que ser posterior al acrual");
                }

                _repositorioEvento.Agregar(evento);
            
            }
    }
}
