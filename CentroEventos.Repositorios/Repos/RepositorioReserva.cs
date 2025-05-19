
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;


namespace CentroEventos.Repositorios.repos
{
    public class RepositorioReserva : IReservaRepositorio
    {
        private readonly string archivoDatos = "C:/Users/ulise/OneDrive/Escritorio/Facu/.net-facultad-proyecto/CentroEventos.Repositorios/Data/reserva/reserva.txt";
        private readonly string archivoUltimoId = "C:/Users/ulise/OneDrive/Escritorio/Facu/.net-facultad-proyecto/CentroEventos.Repositorios/Data/reserva/reserva_ultimoId.txt";

        public int AsignarId()
        {
            int idAux;
            using var leer = new StreamReader(archivoUltimoId);
            idAux = int.Parse(leer.ReadToEnd());
            int id = idAux + 1;
            using var writer = new StreamWriter(archivoUltimoId, false);
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
            List<string> newData = [];
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
            using var leer = new StreamReader(archivoDatos!);
            string? linea;
            while ((linea = leer.ReadLine()) != null)
            {
                Reserva r = RestaurarDesdeTexto(linea);
                if (r.EventoDeportivoId == idEvento)
                    return true;
            }
            return false;
        }

        public bool ExistsByIdPersona(int idPersona)
        {
            using var leer = new StreamReader(archivoDatos!);
            string? linea;
            while ((linea = leer.ReadLine()) != null)
            {
                Reserva r = RestaurarDesdeTexto(linea);
                if (r.PersonaId == idPersona)
                    return true;
            }
            return false;
        }

        public bool ExistsDuplicatePersona(int idPersona, int idEventoDeportivo)
        {
            using var leer = new StreamReader(archivoDatos!);
            string? linea;
            while ((linea = leer.ReadLine()) != null)
            {
                Reserva r = RestaurarDesdeTexto(linea);
                if (r.EventoDeportivoId == idEventoDeportivo && r.PersonaId == idPersona)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Reserva> Listar()
        {
            List<Reserva> listaReserva = [];

            using var leer = new StreamReader(archivoDatos);
            string? linea;
            while ((linea = leer.ReadLine()) != null)
            {
                Reserva r = RestaurarDesdeTexto(linea);
                listaReserva.Add(r);
            }

            return listaReserva;
        }

        public List<Reserva> ListarPorEvento(int idEvento)
        {
            List<Reserva> listaReserva = [];
            using var leer = new StreamReader(archivoDatos!);
            string? linea;
            while ((linea = leer.ReadLine()) != null)
            {
                Reserva r = RestaurarDesdeTexto(linea);
                if (r.EventoDeportivoId == idEvento)
                {
                    listaReserva.Add(r);
                }
            }
            return listaReserva;
        }

        public void Modificar(Reserva reserva)
        {
            List<string> nuevasLineas = [];

            using (var leer = new StreamReader(archivoDatos))
            {
                string? linea;
                while ((linea = leer.ReadLine()) != null)
                {
                    var p = RestaurarDesdeTexto(linea);
                    nuevasLineas.Add(p.Id == reserva.Id ? GuardarComoCadena(reserva) : linea);
                }
            }

            using var escribir = new StreamWriter(archivoDatos, false);
            foreach (string l in nuevasLineas)
            {
                escribir.WriteLine(l);
            }
        }

        public int QuantityCupo(int idEventoDeportivo)
        {
            using var leer = new StreamReader(archivoDatos);
            string? linea;
            int contador = 0;
            while ((linea = leer.ReadLine()) != null)
            {
                Reserva r = RestaurarDesdeTexto(linea);
                if (r.EventoDeportivoId == idEventoDeportivo)
                    contador++;
            }
            return contador;
        }
    }
}