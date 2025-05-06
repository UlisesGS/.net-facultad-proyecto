using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion;

public interface IEstudianteRepositorio
{
    public void Guardar(Estudiante estudiante);

    public void Modificar(Estudiante estudiante);

    public void Eliminar(int id);


    public Estudiante GetById(int id);

    public List<Estudiante> GetAll();

    public Boolean VerifyCarnet(int carnet);
}
