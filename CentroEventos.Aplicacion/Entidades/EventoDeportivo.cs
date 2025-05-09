namespace CentroEventos.Aplicacion;

public class EventoDeportivo
{
    public int Id { get; set;}

    public string Nombre { get; set;} = null!;

    public string Descripcion { get; set;} = null!;

    public DateTime FechaHoraInicio { get; set;} = new();

    public double DuracionHoras { get; set;} = new();

    public int CupoMaximo { get; set;}

    public int ResponsableId { get; set;}
}
