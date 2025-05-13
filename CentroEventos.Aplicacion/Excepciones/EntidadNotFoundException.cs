namespace CentroEventos.Aplicacion
{
    public class EntidadNotFoundException : Exception
    {
        public EntidadNotFoundException(string mensaje) : base(mensaje) { }
    }
}