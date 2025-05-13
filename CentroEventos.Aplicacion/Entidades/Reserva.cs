namespace CentroEventos.Aplicacion
{
    public class Reserva
    {
        public int Id { get; set;}

        public int PersonaId { get; set;}

        public int EventoDeportivoId { get; set;}

        public DateTime FechaAltaReserva { get; set;}

        public EnumEstadoAsistencia EstadoAsistencia { get; set;} = EnumEstadoAsistencia.pendiente;
    }
}
