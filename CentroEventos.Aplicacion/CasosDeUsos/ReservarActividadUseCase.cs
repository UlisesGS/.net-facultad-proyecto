using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion;

public class ReservarActividadUseCase
{
    private readonly IActividadDeportivaRepositorio _repositorioActividad;
    private readonly IReservaRepositorio _repositorioReserva;

    public ReservarActividadUseCase(IActividadDeportivaRepositorio repoActividad, IReservaRepositorio repoReserva){
        _repositorioActividad = repoActividad;
        _repositorioReserva = repoReserva;
    }

    public void Ejecutar(Reserva reserva){
        var actividad = _repositorioActividad.GetById(reserva.ActividadId);

        if(actividad==null){
            throw new ValidacionException ("ERROR - La actividad no es valida.");
        }

        List<ActividadDeportiva> listaActividad = _repositorioActividad.GetAll();

        if(listaActividad.Count>=actividad.CupoMaximo){
            throw new CupoExcedidoException ("ERROR - El cupo esta excedido.");
        }

        _repositorioReserva.Guardar(reserva);
    }
}