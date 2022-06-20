using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Persistence.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using AutoMapper;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        private readonly IMapper _mappe;

        public EventoService(IGeralPersist geralPersist, 
                             IEventoPersist eventoPersist,
                             IMapper mappe) 
        {
            this._geralPersist = geralPersist;
            this._eventoPersist = eventoPersist;
            this._mappe = mappe;
        }

        public async Task<EventoDto> addEventos(EventoDto model)
        {
            try
            {
                var evento = _mappe.Map<Evento>(model);

                _geralPersist.Add<Evento>(evento);

                if (await _geralPersist.SaveChangeAsync())
                {
                    var eventoRetorno = await _eventoPersist.GetEventosByIdAsync(evento.Id, false);
                    return _mappe.Map<EventoDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id; // Caso não seha passado o model ele garante o recebimento do id


                _mappe.Map(model, evento);

                _geralPersist.Update<Evento>(evento);

                if (await _geralPersist.SaveChangeAsync())
                {
                    var eventoRetorno = await _eventoPersist.GetEventosByIdAsync(evento.Id, false);
                    return _mappe.Map<EventoDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEventos(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoId);
                if (evento == null) throw new Exception("Evento para delete não foi encontrado.");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync2(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;
                return _mappe.Map<EventoDto[]>(eventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoId, includePalestrantes);
                if (evento == null) return null;

                var resultado = _mappe.Map<EventoDto>(evento);
                return resultado;

                //var eventoRetorno = new EventoDto()
                //{
                //    Id = evento.Id,
                //    Local = evento.Local,
                //    DateEvento = evento.DateEvento.ToString(),
                //    Tema = evento.Tema,
                //    QtdPessoas = evento.QtdPessoas,
                //    ImagemURL = evento.ImagemURL,
                //    Telefone = evento.Telefone,
                //    Email = evento.Email
                //});

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;
                var resultado = _mappe.Map<EventoDto[]>(eventos);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
