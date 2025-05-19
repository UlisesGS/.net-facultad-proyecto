using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Entidades
{
    public class Reserva(int id, int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, EnumEstadoAsistencia estadoAsistencia)
    {
        public int Id { get; set; } = id;

        public int PersonaId { get; set; } = personaId;

        public int EventoDeportivoId { get; set; } = eventoDeportivoId;

        public DateTime FechaAltaReserva { get; set; } = fechaAltaReserva;

        public EnumEstadoAsistencia EstadoAsistencia { get; set;} = estadoAsistencia;
    }
}
