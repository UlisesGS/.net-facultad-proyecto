namespace CentroEventos.Aplicacion;

public interface IEventoDeportivoRepositorio
{
    public Boolean ExistsById(int idEventoDeportivo);

    public Boolean VerifyCupoMaximo(int idEventoDeportivo);
    
}
