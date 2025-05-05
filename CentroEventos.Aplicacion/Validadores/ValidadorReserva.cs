using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion;

public class ValidadorReserva
{
    private readonly IActividadDeportivaRepositorio _repoActividadDeportiva;

    private readonly IReservaRepositorio _repoReserva;
    private readonly IDocenteRepositorio _repoDocente;

    public ValidadorReserva(IActividadDeportivaRepositorio repositorioActividadDeportiva, IDocenteRepositorio repositorioDocente, IReservaRepositorio repositorioReserva)
    {
        _repoActividadDeportiva = repositorioActividadDeportiva;
        _repoDocente = repositorioDocente;
        _repoReserva = repositorioReserva;
    }

    public void Validar(Reserva reserva)
    {
        var actividad = _repoActividadDeportiva.GetById(reserva.ActividadId);

        if (actividad == null){
            throw new ValidacionException ("ERROR - La actividad no es valida.");
        }

        var docente = _repoDocente.GetById(reserva.PersonaId);

        if (docente == null){
            throw new ValidacionException ("ERROR - El responsable no es valido.");
        }

        if(_repoReserva.VerifyReserva(reserva.PersonaId, reserva.ActividadId)){ // NOS QUEDAMOS POR ACAAAA!!

        }

        List<DateTime> dias = actividad.DiasDisponibles;

        if (dias.All( fecha=> fecha.Date != reserva.FechaReserva.Date)){
            throw new FechaInvalidaException("ERROR - La fecha no es valida.");
        }


    }
}
