namespace CentroEventos.Aplicacion
{
    public class ServicioDeAutorizacionProvisorio : IServicioAutorizacion
    {
        public bool PoseeElPermiso(int IdUsuario, EnumPermiso permiso){

            return IdUsuario==1;
        }
    }
}
