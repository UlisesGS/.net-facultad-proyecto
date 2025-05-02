namespace CentroEventos.Aplicacion;

public class ActividadDeportiva
{
    public int Id { get; set;}

    public string Nombre { get; set;} = null!;

    public List<string> DiasDisponibles { get; set;} = new();

    public int CupoMaximo { get; set;}

}
