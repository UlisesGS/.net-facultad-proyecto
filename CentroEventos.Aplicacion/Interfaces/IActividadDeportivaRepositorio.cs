namespace CentroEventos.Aplicacion;

public interface IActividadDeportivaRepositorio
{
    public void Guardar(ActividadDeportiva actividadDeportiva);

    public void Modificar(ActividadDeportiva actividadDeportiva);

    public void Eliminar(int id);


    public List<ActividadDeportiva> GetAll();

    public ActividadDeportiva GetById(int id);
    
}
