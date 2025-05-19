using CentroEventos.Aplicacion.CasosDeUsos;
using CentroEventos.Aplicacion.CasosDeUsos.Evento;
using CentroEventos.Aplicacion.CasosDeUsos.Personas;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.validadores;
using CentroEventos.Repositorios.repos;

IServicioAutorizacion servicioAuth = new ServicioDeAutorizacionProvisorio();
RepositorioEvento eventoRepositorio= new RepositorioEvento();
RepositorioReserva reservaRepositorio = new RepositorioReserva();
RepositorioPersona personaRepositorio = new RepositorioPersona();
PersonaValidador personaVal = new PersonaValidador(personaRepositorio);
EventoDeportivoValidador eventoVal = new EventoDeportivoValidador(personaRepositorio);
ReservaValidador reservaVal = new ReservaValidador(personaRepositorio, eventoRepositorio, reservaRepositorio);

int idUsuario = 1;

void Continuar()
{
    Console.WriteLine("-- ENTER para continuar --");
    Console.ReadLine();
}

while (true)
{
    Console.WriteLine("///// CENTRO DE EVENTOS /////");
    Console.WriteLine("1. Personas");
    Console.WriteLine("2. Eventos Deportivos");
    Console.WriteLine("3. Reservas");
    Console.WriteLine("0. Salir");
    Console.Write("Elige una opcion: ");
    switch (Console.ReadLine())
    {
        case "1":
            MenuPersonas(personaRepositorio, personaVal, servicioAuth, idUsuario);
            break;
        case "2":
            MenuEventos(eventoRepositorio, personaRepositorio, reservaRepositorio, eventoVal, servicioAuth, idUsuario);
            break;
        case "3":
            MenuReservas(reservaRepositorio, personaRepositorio, eventoRepositorio, reservaVal, servicioAuth, idUsuario);
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Opcion invalida.");
            Continuar();
            break;
    }
}


void MenuPersonas(RepositorioPersona repositorio, PersonaValidador validador, IServicioAutorizacion servicioAuth, int id)
{
    while (true)
    {
        while (true)
        {
            Console.WriteLine("*** PERSONAS ***");
            Console.WriteLine("1. Alta");
            Console.WriteLine("2. Modificar");
            Console.WriteLine("3. Listar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Volver");
            Console.Write("Opcion: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("DNI: ");
                    int d = int.Parse(Console.ReadLine()!);
                    Console.Write("Nombre: ");
                    string n = Console.ReadLine()!;
                    Console.Write("Apellido: ");
                    string a = Console.ReadLine()!;
                    Console.Write("Email: ");
                    string e = Console.ReadLine()!;
                    Console.Write("Telefono: ");
                    string t = Console.ReadLine()!;
                    Persona p = new(0, d, n, a, e, t);
                    try
                    {
                        new PersonaAltaUseCase(repositorio, servicioAuth, validador).Ejecutar(p, id);
                        Console.WriteLine($"Creado Correctamente: {p}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    Continuar();
                    break;

                case "2":
                    Console.Write("Ingrese el id a modificar: ");
                    Persona p1 = null!;
                    p1.Id = int.Parse(Console.ReadLine()!);
                    Console.Write("DNI: ");
                    p1.DNI = Console.Read()!;
                    Console.Write("Nombre: ");
                    p1.Nombre = Console.ReadLine()!;
                    Console.Write("Apellido: ");
                    p1.Apellido = Console.ReadLine()!;
                    Console.Write("Email: ");
                    p1.Email = Console.ReadLine()!;
                    Console.Write("Telefono: ");
                    p1.Telefono = Console.ReadLine()!;
                    try
                    {
                        new PersonaModificacionUseCase(repositorio, servicioAuth).Ejecutar(p1, id);
                        Console.WriteLine($"Creado Correctamente: {p1}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    Continuar();
                    break;

                case "3":
                    Console.WriteLine("Listado de Personas:");
                    foreach (Persona per in new PersonaListarUseCase(repositorio).Ejecutar())
                        Console.WriteLine(per);
                    Continuar();
                    break;

                case "4":
                    Console.Write("ID a eliminar: "); int id1 = int.Parse(Console.ReadLine()!);
                    try
                    {
                        new PersonaBajaUseCase(repositorio, servicioAuth, new RepositorioEvento(), new RepositorioReserva())
                            .Ejecutar(id1, id);
                        Console.WriteLine("Eliminado Correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    Continuar();
                    break;

                case "0":
                    return;
                default:
                    Console.WriteLine("Invalido");
                    Continuar();
                    break;
            }
        }
    }
}



void MenuEventos(IEventoDeportivoRepositorio eventoRepositorio, IPersonaRepositorio personaRepositorio, IReservaRepositorio reservaRepositorio, EventoDeportivoValidador validador, IServicioAutorizacion auth, int id)
{
    while (true)
    {
            while (true)
        {
            Console.WriteLine("*** EVENTOS ***");
            Console.WriteLine("1. Alta");
            Console.WriteLine("2. Modificar");
            Console.WriteLine("3. Listar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Listar evento con cupo disponible");
            Console.WriteLine("6. Listar asistencia de evento pasado");
            Console.WriteLine("0. Volver");
            Console.Write("Opcion: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Nombre: ");
                    string n = Console.ReadLine()!;
                    Console.Write("Descripcion: ");
                    string d = Console.ReadLine()!;
                    Console.Write("Hora Inicio YYYY-MM-DD: ");
                    DateTime f = DateTime.Parse(Console.ReadLine()!);
                    Console.Write("Duracion Horas: ");
                    double dh = double.Parse(Console.ReadLine()!);
                    Console.Write("Cupo Maximo: ");
                    int c = int.Parse(Console.ReadLine()!);
                    Console.Write("Id Responsable: ");
                    int idR = int.Parse(Console.ReadLine()!);
                    EventoDeportivo e = new(0, idR, c, f, dh, n, d);
                    try
                    {
                        new EventoDeportivoAltaUseCase(eventoRepositorio, servicioAuth, validador).Ejecutar(e, id);
                        Console.WriteLine($"Creado Correctamente: {e}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    Continuar();
                    break;

                case "2":
                    Console.Write("Ingrese el id a modificar: ");
                    EventoDeportivo e1 = null!;
                    Console.Write("Nombre: ");
                    e1.Nombre = Console.ReadLine()!;
                    Console.Write("Descripcion: ");
                    e1.Descripcion = Console.ReadLine()!;
                    Console.Write("Hora Inicio YYYY-MM-DD HH:mm: ");
                    e1.FechaHoraInicio = DateTime.Parse(Console.ReadLine()!);
                    Console.Write("Duracion Horas: ");
                    e1.DuracionHoras = double.Parse(Console.ReadLine()!);
                    Console.Write("Cupo Maximo: ");
                    e1.CupoMaximo = int.Parse(Console.ReadLine()!);
                    Console.Write("Id Responsable: ");
                    e1.ResponsableId = int.Parse(Console.ReadLine()!);
                    try
                    {
                        new EventoDeportivoModificacionUseCase(eventoRepositorio, servicioAuth).Ejecutar(e1, id);
                        Console.WriteLine($"Creado Correctamente: {e1}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    Continuar();
                    break;

                case "3":
                    Console.WriteLine("Listado de Eventos:");
                    foreach (EventoDeportivo evento in new EventoDeportivoListarUseCase(eventoRepositorio).Ejecutar())
                        Console.WriteLine(evento);
                    Continuar();
                    break;

                case "4":
                    Console.Write("ID a eliminar: ");
                    int id1 = int.Parse(Console.ReadLine()!);
                    try
                    {
                        new EventoDeportivoBajaUseCase(eventoRepositorio, servicioAuth,new RepositorioReserva()).Ejecutar(id1, id);
                        Console.WriteLine("Eliminado Correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    Continuar();
                    break;

                case "5":
                    Console.WriteLine("Listado de Eventos con cupo disponible:");
                    try
                    {
                        foreach (EventoDeportivo evento in new ListarEventosConCupoDisponibleUseCase(reservaRepositorio, eventoRepositorio).Ejecutar())
                            Console.WriteLine(evento);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    Continuar();
                    break;
                
                case "6":
                    Console.Write("ID de evento a buscar: ");
                    int id2 = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Listado de Eventos con cupo disponible:");
                    try
                    {
                        foreach (Persona persona in new ListarAsistenciaAEventoUseCase(reservaRepositorio, eventoRepositorio, personaRepositorio).Ejecutar(id2))
                            Console.WriteLine(persona);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }   

                    Continuar();
                    break;

                case "0":
                        return;
                    default:
                        Console.WriteLine("Invalido");
                        Continuar();
                        break;
                    }
        }
    }
}