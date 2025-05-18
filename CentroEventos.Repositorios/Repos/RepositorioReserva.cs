using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios
{
    public class RepositorioReserva : IReservaRepositorio
    {
        private readonly string archivoDatos = @"C:\Users\simon\OneDrive\Desktop\CentroEventos\CentroEventos.Repositorios\Data\reserva\reservas.txt";
        private readonly string archivoUltimoId = @"C:\Users\simon\OneDrive\Desktop\CentroEventos\CentroEventos.Repositorios\Data\reserva\reservas_ultimoId.txt";


        public void Agregar(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int idReserva)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByIdEvento(int idEvento)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByIdPersona(int idPersona)
        {
            throw new NotImplementedException();
        }

        public bool ExistsDuplicatePersona(int idPersona, int idEventoDeportivo)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Reserva> ListarPorEvento(int idEvento)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public int QuantityCupo(int idEventoDeportivo)
        {
            throw new NotImplementedException();
        }
    }
}