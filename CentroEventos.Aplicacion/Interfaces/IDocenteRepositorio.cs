namespace CentroEventos.Aplicacion;

public interface IDocenteRepositorio
{
    public void Guardar(Docente docente);

    public void Modificar(Docente docente);

    public void Eliminar(int id);


    public Docente GetById(int id);

    public List<Docente> GetAll();
    
    public Boolean VerifyCarnet(int carnet);
}
