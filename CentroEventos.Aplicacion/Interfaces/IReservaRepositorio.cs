using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion;

public interface IReservaRepositorio
{
    public void Guardar(Reserva reserva);

    public void Modificar(Reserva reserva);

    public void Eliminar(int id);


    public Boolean VerifyReserva(int idEstudiante, int idActividad);  //no se si manejar la logica en el repo o en el validador

}
