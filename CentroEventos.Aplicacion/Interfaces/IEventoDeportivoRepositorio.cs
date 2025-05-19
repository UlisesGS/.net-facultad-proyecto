using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IEventoDeportivoRepositorio
    {
        public Boolean ExistsById(int id);

        public Boolean ExistsByIdResponsable(int idPersona);

        public int CupoMaximo(int id);

        public void Agregar(EventoDeportivo evento);

        public void Eliminar(int id);

        public List<EventoDeportivo> Listar();

        public void Modificar(EventoDeportivo evento);

        public EventoDeportivo? BuscarPorId(int id);

        public List<EventoDeportivo> ListarFechaFutura();
    }
}
