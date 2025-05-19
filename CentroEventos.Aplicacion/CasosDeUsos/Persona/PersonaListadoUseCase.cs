namespace CentroEventos.Aplicacion
{
    public class PersonaListarUseCase (IPersonaRepositorio repoPersona){
            private readonly IPersonaRepositorio _repositorioPersona = repoPersona;

        public List<Persona> Ejecutar(){

            return _repositorioPersona.Listar();
        
        }
    }
}
