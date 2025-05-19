namespace CentroEventos.Repositorios;

using System.Collections.Generic;
using CentroEventos.Aplicacion;
using DotNetEnv;

public class RepositorioPersona : IPersonaRepositorio
{
    private readonly string archivoDatos = Env.GetString("ARCHIVO_DATOS_PERSONA");
    private readonly string archivoUltimoId = Env.GetString("ARCHIVO_ULTIMO_ID_PERSONA");

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

    private static string GuardarComoCadena(Persona p)
    {
        return $"{p.Id};{p.DNI};{p.Nombre};{p.Apellido};{p.Email};{p.Telefono}";
    }

    private static Persona RestaurarDesdeTexto(string linea)
    {
        string[] partes = linea.Split(';');
        return new Persona(
            int.Parse(partes[0]),
            int.Parse(partes[1]),
            partes[2],
            partes[3],
            partes[4],
            partes[5]
        );
    }



    public void Agregar(Persona persona)
    {
        persona.Id = AsignarId();
        using var escribir = new StreamWriter(archivoDatos, false);
        escribir.WriteLine(GuardarComoCadena(persona));
    }

    public Persona? BuscarPorId(int id)
    {
        using var leer = new StreamReader(archivoDatos);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            Persona p = RestaurarDesdeTexto(linea);
            if (p.Id == id)
                return p;
        }

        return null;
    }

    public void Eliminar(int id)
    {
        List<string> newData = [];
        using var leer = new StreamReader(archivoDatos);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            Persona p = RestaurarDesdeTexto(linea);
            if (p.Id != id)
                newData.Add(linea);
        }
        using var escribir = new StreamWriter(archivoDatos, false);
        foreach (string l in newData)
        {
            escribir.WriteLine(l);
        }
    }

    public bool ExistsByDNI(int dni)
    {
        using var leer = new StreamReader(archivoDatos);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            Persona p = RestaurarDesdeTexto(linea);
            if (p.DNI == dni)
                return true;
        }
        return false;
    }

    public bool ExistsByEmail(string email)
    {
        using var leer = new StreamReader(archivoDatos);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            Persona p = RestaurarDesdeTexto(linea);
            if (p.Email == email)
                return true;
        }
        return false;
    }

    public bool ExistsById(int id)
    {
        using var leer = new StreamReader(archivoDatos);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            Persona p = RestaurarDesdeTexto(linea);
            if (p.Id == id)
                return true;
        }
        return false;
    }

    public List<Persona> Listar()
    {
        List<Persona> listaPersona = [];

        using var leer = new StreamReader(archivoDatos);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            Persona p = RestaurarDesdeTexto(linea);
            listaPersona.Add(p);
        }

        return listaPersona;
    }

    public void Modificar(Persona persona)
    {
        List<string> nuevasLineas = [];

        using (var reader = new StreamReader(archivoDatos))
        {
            string? linea;
            while ((linea = reader.ReadLine()) != null)
            {
                var p = RestaurarDesdeTexto(linea);
                nuevasLineas.Add(p.Id == persona.Id ? GuardarComoCadena(persona) : linea);
            }
        }

        using var writer = new StreamWriter(archivoDatos, false);
        foreach (string l in nuevasLineas)
        {
            writer.WriteLine(l);
        }
    }
}
