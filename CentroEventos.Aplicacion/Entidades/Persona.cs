
namespace CentroEventos.Aplicacion.Entidades
{
    public class Persona(int id, int dni, string nombre, string apellido, string email, string telefono)
    {
        public int Id { get; set; } = id;
        public int? DNI { get; set; } = dni;
        public string Nombre { get; set;} = nombre;
        public string Apellido { get; set;} = apellido;
        public string Email { get; set;} = email!;
        public string Telefono { get; set;} = telefono;

        public override string ToString()
        {
            return $"{Nombre} {Apellido} ({DNI})";
        }
    }
}
