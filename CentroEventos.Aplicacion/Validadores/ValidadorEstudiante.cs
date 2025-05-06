using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion;

public class ValidadorEstudiante
{
    private readonly IEstudianteRepositorio _repoEstudiante;

    public ValidadorEstudiante(IEstudianteRepositorio repositorioEstudiante)
    {
        _repoEstudiante = repositorioEstudiante;
    }

    public void Validar(Estudiante estudiante)
    {
        if(_repoEstudiante.VerifyCarnet(estudiante.NumeroCarnet)){
            throw new ValidacionException("ERROR - Numero de carnet ya registrado.");
        }

        if(string.IsNullOrWhiteSpace(estudiante.Nombre)){
            throw new ValidacionException("ERROR - Nombre obligatorio.");
        }

        if(string.IsNullOrWhiteSpace(estudiante.CorreoElectronico)){
            throw new ValidacionException("ERROR - Correo electronico obligatorio.");
        }
    }
}
