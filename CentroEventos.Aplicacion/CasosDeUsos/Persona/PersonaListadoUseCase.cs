namespace CentroEventos.Aplicacion
{
    public class PersonaListarUseCase (IPersonaRepositorio repoPersona){
            private readonly IPersonaRepositorio _repositorioPersona = repoPersona;

        public List<Persona> Ejecutar(Persona persona){

            return _repositorioPersona.Listar();
        
        }
    }
}
