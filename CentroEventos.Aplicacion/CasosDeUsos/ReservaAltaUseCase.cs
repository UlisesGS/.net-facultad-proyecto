namespace CentroEventos.Aplicacion;

public class ReservaAltaUseCase 
{
    private readonly IReservaRepositorio _repositorioReserva;

    private readonly IEventoDeportivoRepositorio _repositorioEvento;

    private readonly IPersonaRepositorio _repositorioPersona;

    private readonly IServicioAutorizacion _servicioAutorizacion;

    private readonly ReservaValidador _validadorReserva;

    public ReservaAltaUseCase(IReservaRepositorio repoReserva, IEventoDeportivoRepositorio repoEvento, IPersonaRepositorio repoPersona, IServicioAutorizacion servicioAutorizacion){
        _repositorioReserva = repoReserva;
        _repositorioPersona = repoPersona;
        _repositorioEvento = repoEvento;
        _servicioAutorizacion = servicioAutorizacion;
        _validadorReserva = new ReservaValidador(_repositorioPersona, _repositorioEvento, _repositorioReserva);
    }

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
