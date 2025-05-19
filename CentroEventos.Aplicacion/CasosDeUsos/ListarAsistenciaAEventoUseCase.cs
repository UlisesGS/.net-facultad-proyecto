using System.Data;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion
{

    public class ListarAsistenciaAEventoUseCase(IReservaRepositorio repoReserva, IEventoDeportivoRepositorio repoEvento, IPersonaRepositorio repoPersona){

        private readonly IReservaRepositorio _repositorioReserva = repoReserva;
        private readonly IEventoDeportivoRepositorio _repositorioEvento = repoEvento;
        private readonly IPersonaRepositorio _repositorioPersona = repoPersona;

        public List<Persona> Ejecutar(int idEvento){

            var evento = _repositorioEvento.BuscarPorId(idEvento);

            if(evento==null){
                throw new EntidadNotFoundException("ERROR - El evento no existe.");
            }
                
            if(!(evento.FechaHoraInicio.AddHours(evento.DuracionHoras) <= DateTime.Now)){
                throw new ValidacionException("ERROR - El evento debe haber terminado para realizar esta operacion."); 
            }

            List<Reserva> listaReserva = _repositorioReserva.ListarPorEvento(idEvento);

            if(!listaReserva.Any()){
                throw new ValidacionException("ERROR - No hay reservas para este evento.");
            }

            List<Persona> listaFinal = new();
        
            foreach(Reserva reserva in listaReserva){
                if(reserva.EstadoAsistencia==EnumEstadoAsistencia.presente){
                    Persona persona = _repositorioPersona.BuscarPorId(reserva.PersonaId) ?? throw new EntidadNotFoundException("ERROR - La persona no existe.");;
                    listaFinal.Add(persona);
                }
            }

            if(!listaFinal.Any()){
                throw new ValidacionException("ERROR - Nadie asistio al evento.");
            }

            return listaFinal;
        }
    }
}