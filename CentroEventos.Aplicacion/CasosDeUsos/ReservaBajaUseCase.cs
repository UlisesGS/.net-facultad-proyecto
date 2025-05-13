namespace CentroEventos.Aplicacion;

public class ReservaBajaUseCase 
{
    private readonly IReservaRepositorio _repositorioReserva;

    private readonly IEventoDeportivoRepositorio _repositorioEvento;

    private readonly IPersonaRepositorio _repositorioPersona;

    private readonly IServicioAutorizacion _servicioAutorizacion;

    public ReservaBajaUseCase(IReservaRepositorio repoReserva, IEventoDeportivoRepositorio repoEvento, IPersonaRepositorio repoPersona, IServicioAutorizacion servicioAutorizacion){
        _repositorioReserva = repoReserva;
        _repositorioPersona = repoPersona;
        _repositorioEvento = repoEvento;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Reserva reserva, int idUsuario){

        if(!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.ReservaBaja)){
            throw new FalloAutorizacionException("ERROR - No estas autorizado.");
        }
        
        
        
    }
}
