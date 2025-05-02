using System.Data.Common;

namespace CentroEventos.Aplicacion;

public abstract class Persona
{
    public int Id { get; set;}
    public int NumeroCarnet { get; set;}
    public string Nombre { get; set;} = null!;//Si, esto esta null ahora, pero  va a tener un valor antes de usarse
    public string Apellido { get; set;} = null!;
    public string Direccion { get; set;} = null!;
    public string Facultad { get; set;} = null!;
    public string Telefono { get; set;} = null!;
    public string CorreoElectronico { get; set;} = null!;


    public override string ToString()
    {
        return $"{Nombre} {Apellido} ({NumeroCarnet})";
    }
}
