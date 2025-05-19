using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUsos.Personas
{
    public class PersonaBajaUseCase(IPersonaRepositorio repoPersona, IServicioAutorizacion servicioAutorizacion, IEventoDeportivoRepositorio repoEvento, IReservaRepositorio repoReserva){
            private readonly IPersonaRepositorio _repositorioPersona = repoPersona;
            private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
            private readonly IEventoDeportivoRepositorio _repositorioEvento = repoEvento;
            private readonly IReservaRepositorio _repositorioReserva = repoReserva;
        

        public void Ejecutar(int idPersona, int idUsuario){

            if(!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.UsuarioBaja)){
                throw new FalloAutorizacionException("ERROR - No estas autorizado.");
            }

            if(_repositorioEvento.ExistsByIdResponsable(idPersona)){
                throw new OperacionInvalidaException("ERROR - Esta persona es responsable de un evento.");
            }

            if(_repositorioReserva.ExistsByIdPersona(idPersona)){
                throw new OperacionInvalidaException("ERROR - Esta persona esta vinculada a una reserva.");
            }

            _repositorioPersona.Eliminar(idPersona);
        
        }
    }
}
