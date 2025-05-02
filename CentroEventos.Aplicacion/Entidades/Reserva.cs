namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int Id { get; set;}

    public int PersonaId { get; set;}

    public int ActividadId { get; set;}

    public DateTime FechaReserva { get; set;}

    public EnumEstadoAsistencia EstadoAsistencia { get; set;} = EnumEstadoAsistencia.pendiente;
}
