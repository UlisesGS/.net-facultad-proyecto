using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion;

public class ReservaValidador
{
    private readonly IPersonaRepositorio _repoPersona;

    private readonly IEventoDeportivoRepositorio _repoEventoDeportivo;

    private readonly IReservaRepositorio _repoReserva;

    public ReservaValidador(IPersonaRepositorio repositorioPersona, IEventoDeportivoRepositorio repositorioEventoDeportivo, IReservaRepositorio repositorioReserva)
    {
        _repoPersona = repositorioPersona;
        _repoEventoDeportivo = repositorioEventoDeportivo;
        _repoReserva = repositorioReserva;
    }

    public void Validar(Reserva reserva)
    {

        if (_repoPersona.ExistsById(reserva.PersonaId)){
            throw new EntidadNotFoundException("ERROR - La Persona no es valida.");
        }

        if (_repoEventoDeportivo.ExistsById(reserva.EventoDeportivoId)){
            throw new EntidadNotFoundException("ERROR - El Evento Deportivo no es valido.");
        }

        if (_repoReserva.ExistsDuplicatePersona(reserva.PersonaId,reserva.EventoDeportivoId)){
            throw new DuplicadoException("ERROR - La Reserva ya esta registrada.");
        }

        if (_repoEventoDeportivo.VerifyCupoMaximo(reserva.EventoDeportivoId)){ // por que dice llamas a IRepositorioReserva
            throw new CupoExcedidoException("ERROR - No hay Cupo disponible.");
        }
    }
}
