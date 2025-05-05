using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion;

public class ValidadorActividadDeportiva
{
    public void Validar(ActividadDeportiva actividad) //PDF A QUE SE REFIERE CON DESCRIPCION
    {
        if (string.IsNullOrWhiteSpace(actividad.Nombre)){
            throw new ValidacionException("ERROR - Nombre obligatorio.");
        }

        if (actividad.DiasDisponibles == null || !actividad.DiasDisponibles.All(fecha => fecha >= DateTime.Today)){
            throw new FechaInvalidaException("ERROR - Todas las fechas deben ser iguales o posteriores a la fecha actual.");
        }

        if (actividad.CupoMaximo <= 0){
            throw new ValidacionException("ERROR - El cupo tiene que ser mayor a 0.");
        }

    }
}
