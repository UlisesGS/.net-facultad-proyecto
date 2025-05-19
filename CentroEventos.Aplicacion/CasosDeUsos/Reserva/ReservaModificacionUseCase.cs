using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion
{
    public class ReservaModificacionUseCase(IReservaRepositorio repoReserva, IServicioAutorizacion servicioAutorizacion, IPersonaRepositorio repoPersona, IEventoDeportivoRepositorio repoEvento){
            private readonly IReservaRepositorio _repositorioReserva = repoReserva;
            private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
            private readonly IPersonaRepositorio _repositorioPersona = repoPersona;

            private readonly IEventoDeportivoRepositorio _repositorioEventoDeportivo = repoEvento;
        

        public void Ejecutar(Reserva reserva, int idUsuario){

            if(!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.ReservaModificacion)){
                throw new FalloAutorizacionException("ERROR - No estas autorizado.");
            }

            var personaAux = _repositorioPersona.BuscarPorId(reserva.PersonaId) ?? throw new EntidadNotFoundException("ERROR - La persona no existe.");;

            if(!_repositorioPersona.ExistsById(reserva.PersonaId)){
                throw new EntidadNotFoundException("ERROR - La Persona no es valida.");
            }
            //POSIBLE PROBLEMA DE QUE NUNCA SE VA A PODER MODIFICAR
            if(_repositorioReserva.ExistsByIdPersona(reserva.PersonaId) && reserva.PersonaId != personaAux.Id){
                throw new DuplicadoException("ERROR - La Persona ya esta registrada.");
            }

            //NO ENTENDEMOS SI SE PUEDE MODIFICAR EN LA RESERVA SOLO LA PERSONA: OSEA SI YO YA TENGO
            //UN EVENTO LLENO, Y SOLO QUIERO COMO ADMIN SACAR Y PONER OTRA PERSONA, AUNQUE EL CUPO
            //ME DE QUE ESTA LLENO, TENDRIA QUE DEJARME, NOSE SI ESTE CASO PODRIA PASAR, LO TOMAMOS COMO QUE NO
            if (_repositorioReserva.QuantityCupo(reserva.EventoDeportivoId) >= _repositorioEventoDeportivo.CupoMaximo(reserva.EventoDeportivoId)){
                throw new CupoExcedidoException("ERROR - No hay Cupo disponible.");
            }

            _repositorioReserva.Modificar(reserva);
        
        }
    }
}
