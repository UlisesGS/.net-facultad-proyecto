namespace CentroEventos.Aplicacion;

public interface IActividadDeportivaRepositorio
{
    public List<ActividadDeportiva> GetAll();

    public ActividadDeportiva GetById(int id);

}
