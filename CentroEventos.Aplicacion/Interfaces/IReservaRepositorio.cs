using CentroEventos.Aplicacion;

namespace CentroEventos.Aplicacion
{
    public interface IReservaRepositorio
    {
        public Boolean ExistsDuplicatePersona(int idPersona, int idEventoDeportivo);

        public int QuantityCupo(int idEventoDeportivo); // lo contamos aca, porque no hay registro de como se va llenanado

        public Boolean ExistsById(int id);

        public Boolean ExistsByIdPersona(int idPersona);

        public Boolean ExistsByIdEvento(int idEvento);

        public void Agregar(Reserva reserva);

        public void Eliminar(int idReserva);

        public List<Reserva> Listar();

        public List<Reserva> ListarPorEvento(int idEvento);
        public void Modificar(Reserva reserva);
    }
}
