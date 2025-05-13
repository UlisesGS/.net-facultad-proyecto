namespace CentroEventos.Aplicacion;

public interface IEventoDeportivoRepositorio
{
    public Boolean ExistsById(int idEventoDeportivo);

    public int CupoMaximo(int idEventoDeportivo);
    
}
