using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    { 
        Task<Palestrante[]> GetAllPalestranteByNomeAsync(string Nome, bool includeEventos = false);
        Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos = false);
    }

}
