using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Servicios
{
    public class ServicioDeAutorizacionProvisorio : IServicioAutorizacion
    {
        public bool PoseeElPermiso(int IdUsuario, EnumPermiso permiso){

            return IdUsuario==1;
        }
    }
}
