using CentroEventos.Aplicacion;

namespace CentroEventos.Aplicacion;

public interface IReservaRepositorio
{
    public Boolean ExistsDuplicatePersona(int idPersona, int idEventoDeportivo);

    public int QuantityCupo(int idEventoDeportivo);

    public void Agregar(Reserva reserva);
}
