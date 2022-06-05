using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> addEventos(Evento model);
        Task<Evento> UpdateEventos(int eventoId, Evento model);
        Task<bool> DeleteEventos(int eventoId);

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}
