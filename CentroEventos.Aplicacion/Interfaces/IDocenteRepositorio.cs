namespace CentroEventos.Aplicacion;

public interface IDocenteRepositorio
{
    public Docente GetById(int id);

    public List<Docente> GetAll();
    
}
