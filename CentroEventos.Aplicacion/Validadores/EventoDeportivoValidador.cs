using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion;

public class EventoDeportivoValidador
{
    private readonly IPersonaRepositorio _repoPersona;

    public EventoDeportivoValidador(IPersonaRepositorio repositorioPersona)
    {
        _repoPersona = repositorioPersona;
    }


    public void Validar(EventoDeportivo evento)
    {
        if (string.IsNullOrWhiteSpace(evento.Nombre)){
            throw new ValidacionException("ERROR - Nombre obligatorio.");
        }

        if (string.IsNullOrWhiteSpace(evento.Descripcion)){
            throw new ValidacionException("ERROR - Descripcion obligatoria.");
        }

        if (evento.CupoMaximo <= 0){
            throw new ValidacionException("ERROR - El cupo debe ser mayor a 0.");
        }

        if (evento.DuracionHoras <= 0){
            throw new ValidacionException("ERROR - La hora debe ser mayor a 0.");
        }

        if (!_repoPersona.ExistsById(evento.ResponsableId)){
            throw new EntidadNotFoundException("ERROR - EL Responsable no es valido.");
        }
    }
}
