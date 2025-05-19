using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUsos.Personas
{
    public class PersonaListarUseCase (IPersonaRepositorio repoPersona){
            private readonly IPersonaRepositorio _repositorioPersona = repoPersona;

        public List<Persona> Ejecutar(){

            return _repositorioPersona.Listar();
        
        }
    }
}
