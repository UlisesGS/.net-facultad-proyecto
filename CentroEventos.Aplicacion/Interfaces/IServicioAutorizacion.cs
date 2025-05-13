namespace CentroEventos.Aplicacion
{
    public interface IServicioAutorizacion 
    {
        bool PoseeElPermiso(int IdUsuario, EnumPermiso permiso);
    }
}
