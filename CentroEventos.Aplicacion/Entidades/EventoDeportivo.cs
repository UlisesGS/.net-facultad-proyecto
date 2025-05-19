namespace CentroEventos.Aplicacion.Entidades
{
    public class EventoDeportivo(int id, int respondableId, int cupoMaximo, DateTime fechaHoraInicio, double duracionHoras, string nombre, string descripcion)
    {
        public int Id { get; set; } = id;

        public string Nombre { get; set; } = nombre;

        public string Descripcion { get; set; } = descripcion;

        public DateTime FechaHoraInicio { get; set; } = fechaHoraInicio;

        public double DuracionHoras { get; set; } = duracionHoras;

        public int CupoMaximo { get; set; } = cupoMaximo;

        public int ResponsableId { get; set; } = respondableId;

        public override string ToString()
        {
            return $"ID: {Id,-4} | Nombre: {Nombre,-20} | Inicio: {FechaHoraInicio:yyyy-MM-dd HH:mm} | Duración: {DuracionHoras,5:F2} h | Cupo: {CupoMaximo,-4} | Responsable ID: {ResponsableId,-4}";
        }
    }
}
