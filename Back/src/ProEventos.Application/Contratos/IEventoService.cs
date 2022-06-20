using ProEventos.Application.Dtos;
using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<EventoDto> addEventos(EventoDto model);
        Task<EventoDto> UpdateEvento(int eventoId, EventoDto model);
        Task<bool> DeleteEventos(int eventoId);

        Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync2(bool includePalestrantes = false);
        Task<EventoDto> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}
