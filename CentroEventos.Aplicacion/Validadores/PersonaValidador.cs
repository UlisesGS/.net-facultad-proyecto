using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.validadores
{
    public class PersonaValidador
    {

        private readonly IPersonaRepositorio _repoPersona;

        public PersonaValidador(IPersonaRepositorio repositorioPersona)
        {
            _repoPersona = repositorioPersona;
        }

        public void Validar(Persona persona) {

            if(string.IsNullOrWhiteSpace(persona.Nombre)){
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

            if(_repoPersona.ExistsByDNI(persona.DNI.Value)){
                throw new DuplicadoException("ERROR - DNI ya registrado.");
            }

            if(string.IsNullOrWhiteSpace(persona.Email)){
                throw new ValidacionException("ERROR - Email obligatorio.");
            }

            if(_repoPersona.ExistsByEmail(persona.Email)){
                throw new DuplicadoException("ERROR - Email ya registrado.");
            }
        }
    
    }
}
