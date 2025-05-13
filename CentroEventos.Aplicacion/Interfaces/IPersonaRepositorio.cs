namespace CentroEventos.Aplicacion
{
    public interface IPersonaRepositorio
    {
        public Boolean ExistsById(int idPersona);

        public Boolean ExistsByDNI(int dni); // POR AHORA LO DEJAMOS CON ID DE PERSONA PARA BUSCAR

        public Boolean ExistsByEmail(string email);

        public void Agregar(Persona persona);

        public void Eliminar(int id);

        public List<Persona> Listar();

        public void Modificar(Persona persona);

        public Persona BuscarPorId(int id);
    }
}
