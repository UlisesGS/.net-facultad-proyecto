using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion;

public interface IReservaRepositorio
{
    public Boolean VerifyReserva(int idEstudiante, int idActividad);  //no se si manejar la logica en el repo o en el validador

}
