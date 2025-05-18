namespace CentroEventos.Aplicacion
{
    public interface IEventoDeportivoRepositorio
    {
        public Boolean ExistsById(int idEventoDeportivo);

        public Boolean ExistsByIdResponsable(int idPersona);

        public int CupoMaximo(int idEventoDeportivo);

        public void Agregar(EventoDeportivo evento);

        public void Eliminar(int idEvento);

        public List<EventoDeportivo> Listar();

        public EventoDeportivo BuscarPorId(int id);

        public List<EventoDeportivo> ListarFechaFutura();
    }
}
