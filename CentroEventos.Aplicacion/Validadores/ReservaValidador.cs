﻿using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.validadores
{
    public class ReservaValidador
    {
        private readonly IPersonaRepositorio _repoPersona;

        private readonly IEventoDeportivoRepositorio _repoEventoDeportivo;

        private readonly IReservaRepositorio _repoReserva;

        public ReservaValidador(IPersonaRepositorio repositorioPersona, IEventoDeportivoRepositorio repositorioEventoDeportivo, IReservaRepositorio repositorioReserva)
        {
            _repoPersona = repositorioPersona;
            _repoEventoDeportivo = repositorioEventoDeportivo;
            _repoReserva = repositorioReserva;
        }

        public void Validar(Reserva reserva)
        {

            if (_repoPersona.ExistsById(reserva.PersonaId)){
                throw new EntidadNotFoundException("ERROR - La Persona no es valida.");
            }

            if (_repoEventoDeportivo.ExistsById(reserva.EventoDeportivoId)){
                throw new EntidadNotFoundException("ERROR - El Evento Deportivo no es valido.");
            }

            if (_repoReserva.ExistsDuplicatePersona(reserva.PersonaId,reserva.EventoDeportivoId)){
                throw new DuplicadoException("ERROR - La Reserva ya esta registrada.");
            }

            if (_repoReserva.QuantityCupo(reserva.EventoDeportivoId) == _repoEventoDeportivo.CupoMaximo(reserva.EventoDeportivoId)){
                throw new CupoExcedidoException("ERROR - No hay Cupo disponible.");
            }
        }
    }
}
