using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion;

public interface IEstudianteRepositorio
{
    public Estudiante GetById(int id);

    public List<Estudiante> GetAll();

}
