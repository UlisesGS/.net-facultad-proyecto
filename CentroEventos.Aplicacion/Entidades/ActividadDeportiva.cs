namespace CentroEventos.Aplicacion;

public class ActividadDeportiva
{
    public int Id { get; set;}

    public string Nombre { get; set;} = null!;

    public List<DateTime> DiasDisponibles { get; set;} = new();

    public int CupoMaximo { get; set;}

}
