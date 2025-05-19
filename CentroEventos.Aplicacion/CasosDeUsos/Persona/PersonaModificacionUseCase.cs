using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion
{
    public class PersonaModificacionUseCase(IPersonaRepositorio repoPersona, IServicioAutorizacion servicioAutorizacion){
            private readonly IPersonaRepositorio _repositorioPersona = repoPersona;
            private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
        

        public void Ejecutar(Persona persona, int idUsuario){

            if(!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.UsuarioModificacion)){
                throw new FalloAutorizacionException("ERROR - No estas autorizado.");
            }
            
            var personaAux = _repositorioPersona.BuscarPorId(persona.Id) ?? throw new EntidadNotFoundException("ERROR - La persona no existe.");

            //NO PUEDO REPETIR EL VALIDADOR PORQUE PUEDE SER QUE EL EMAIL Y EL DNI SEAN LOS MISMOS
            if (string.IsNullOrWhiteSpace(persona.Nombre))
            {
                throw new ValidacionException("ERROR - Nombre obligatorio.");
            }

            if(string.IsNullOrWhiteSpace(persona.Apellido)){
                throw new ValidacionException("ERROR - Apellido Obligatorio.");
            }

            if(persona.DNI == null){
                throw new ValidacionException("ERROR - DNI obligatorio.");
            }

            if(persona.DNI.Value.ToString().Length != 8){ //c# no detecta el if anterior
                throw new ValidacionException("ERROR - La longitud tiene que ser de 8.");
            }

            if(string.IsNullOrWhiteSpace(persona.Email)){
                throw new ValidacionException("ERROR - Email obligatorio.");
            }

            if(_repositorioPersona.ExistsByDNI(persona.DNI.Value) && persona.DNI != personaAux.DNI){
                throw new DuplicadoException("ERROR - DNI ya registrado.");
            }

            if(_repositorioPersona.ExistsByEmail(persona.Email) && persona.Email != personaAux.Email){
                throw new DuplicadoException("ERROR - Email ya registrado.");
            }

            _repositorioPersona.Modificar(persona);
        
        }
    }
}
