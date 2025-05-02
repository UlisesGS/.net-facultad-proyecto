namespace CentroEventos.Aplicacion.Entidades;

public class Estudiante : Persona
{
    public int NumeroAlumno { get; set;} //string o int??

    public string Carrera { get; set;} = null!;
}
