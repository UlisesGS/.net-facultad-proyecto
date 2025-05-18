using System.Reflection.Metadata;
using CentroEventos.Aplicacion;
using DotNetEnv;

namespace CentroEventos.Repositorios
{
    public class RepositorioReserva : IReservaRepositorio
    {
        private readonly string? archivoDatos;
        private readonly string? archivoUltimoId;

        public int AsignarId()
        {
            int idAux;
            using var leer = new StreamReader(archivoUltimoId!);
            idAux = int.Parse(leer.ReadToEnd());
            int id = idAux + 1;
            using var writer = new StreamWriter(archivoUltimoId!, false);
            writer.Write(id);
            return id;
        }

        private static string GuardarComoCadena(Reserva r)
        {
            return $"{r.Id};{r.PersonaId};{r.EventoDeportivoId};{r.FechaAltaReserva:yyyy-MM-dd HH:mm};{r.EstadoAsistencia}";
        }

        private static Reserva RestaurarDesdeTexto(string linea)
        {
            string[] partes = linea.Split(';');
            return new Reserva(
                int.Parse(partes[0]),
                int.Parse(partes[1]),
                int.Parse(partes[2]),
                DateTime.Parse(partes[3]),
                Enum.Parse<EnumEstadoAsistencia>(partes[4])
            );
        }

        public void Agregar(Reserva reserva)
        {
            reserva.Id = AsignarId();
            using var writer = new StreamWriter(archivoDatos!, true);
            writer.WriteLine(GuardarComoCadena(reserva));
        }

        public void Eliminar(int id)
        {
            List<string> newData = new List<string>();
            using var leer = new StreamReader(archivoDatos!);
            string? linea;
            while ((linea = leer.ReadLine()) != null)
            {
                Reserva r = RestaurarDesdeTexto(linea);
                if (r.Id != id)
                    newData.Add(linea);
            }
            using var escribir = new StreamWriter(archivoDatos!, false);
            foreach (string l in newData)
            {
                escribir.WriteLine(l);
            }
        }

        public bool ExistsById(int id)
        {
            using var leer = new StreamReader(archivoDatos!);
            string? linea;
            while ((linea = leer.ReadLine()) != null)
            {
                Reserva r = RestaurarDesdeTexto(linea);
                if (r.Id == id)
                    return true;
            }
            return false;
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