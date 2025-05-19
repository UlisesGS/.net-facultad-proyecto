namespace CentroEventos.Repositorios;

using System.Collections.Generic;
using CentroEventos.Aplicacion;
using DotNetEnv;

public class RepositorioEvento : IEventoDeportivoRepositorio
{
    private readonly string archivoDatos = Env.GetString("ARCHIVO_DATOS_EVENTO");
    private readonly string archivoUltimoId = Env.GetString("ARCHIVO_ULTIMO_ID_EVENTO");

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

    private static string GuardarComoCadena(EventoDeportivo e)
    {
        return $"{e.Id};{e.ResponsableId};{e.CupoMaximo};{e.FechaHoraInicio:yyyy-MM-dd HH:mm};{e.DuracionHoras};{e.Nombre};{e.Descripcion}";
    }

    private static EventoDeportivo RestaurarDesdeTexto(string linea)
    {
        string[] partes = linea.Split(';');
        return new EventoDeportivo(
            int.Parse(partes[0]),
            int.Parse(partes[1]),
            int.Parse(partes[2]),
            DateTime.Parse(partes[3]),
            double.Parse(partes[4]),
            partes[5],
            partes[6]
        );
    }
    public void Agregar(EventoDeportivo evento)
    {
        evento.Id = AsignarId();
        using var writer = new StreamWriter(archivoDatos, true);
        writer.WriteLine(GuardarComoCadena(evento));
    }

    public EventoDeportivo? BuscarPorId(int id)
    {
        using var leer = new StreamReader(archivoDatos!);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            EventoDeportivo e = RestaurarDesdeTexto(linea);
            if (e.Id == id)
                return e;
        }
        return null;
    }

    public int CupoMaximo(int id)
    {
        using var leer = new StreamReader(archivoDatos!);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            EventoDeportivo e = RestaurarDesdeTexto(linea);
            if (e.Id == id)
                return e.CupoMaximo;
        }
        return 0;
    }

    public void Eliminar(int id)
    {
        List<string> newData = [];
        using var leer = new StreamReader(archivoDatos);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            EventoDeportivo e = RestaurarDesdeTexto(linea);
            if (e.Id != id)
            {
                newData.Add(linea);
            }
        }
        using var escribir = new StreamWriter(archivoDatos, false);
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
            EventoDeportivo e = RestaurarDesdeTexto(linea);
            if (e.Id == id)
            {
                return true;
            }
        }
        return false;
    }

    public List<EventoDeportivo> Listar()
    {
        List<EventoDeportivo> lista = [];
        using var leer = new StreamReader(archivoDatos);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            EventoDeportivo e = RestaurarDesdeTexto(linea);
            lista.Add(e);
        }
        return lista;
    }

    public void Modificar(EventoDeportivo evento)
    {
        List<string> nuevasLineas = [];

        using (var reader = new StreamReader(archivoDatos))
        {
            string? linea;
            while ((linea = reader.ReadLine()) != null)
            {
                var p = RestaurarDesdeTexto(linea);
                nuevasLineas.Add(p.Id == evento.Id ? GuardarComoCadena(evento) : linea);
            }
        }

        using var writer = new StreamWriter(archivoDatos, false);
        foreach (string l in nuevasLineas)
        {
            writer.WriteLine(l);
        }
    }

    public List<EventoDeportivo> ListarFechaFutura()
    {
        List<EventoDeportivo> lista = [];
        using var leer = new StreamReader(archivoDatos);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            EventoDeportivo e = RestaurarDesdeTexto(linea);
            if (e.FechaHoraInicio > DateTime.Now)
            {
                lista.Add(e);
            }
        }
        return lista;
    }
}
