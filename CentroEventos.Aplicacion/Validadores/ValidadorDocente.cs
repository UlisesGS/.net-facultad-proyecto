using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion;

public class ValidadorDocente
{
    private readonly IDocenteRepositorio _repoDocente;

    public ValidadorDocente(IDocenteRepositorio repositorioDocente)
    {
        _repoDocente = repositorioDocente;
    }

    public void Validar(Docente docente)
    {
        if(_repoDocente.VerifyCarnet(docente.NumeroCarnet)){
            throw new ValidacionException("ERROR - Numero de carnet ya registrado.");
        }

        if(string.IsNullOrWhiteSpace(docente.Nombre)){
            throw new ValidacionException("ERROR - Nombre obligatorio.");
        }

        if(string.IsNullOrWhiteSpace(docente.CorreoElectronico)){
            throw new ValidacionException("ERROR - Correo electronico obligatorio.");
        }
    }
}
