using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using ProEventos.Persistence.Contextos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;

        public PalestrantePersist(ProEventosContext context) 
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
                .Include(p=> p.RedeSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
                .Include(p => p.RedeSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
                         .Where(p => p.Nome.ToLower()
                         .Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
                .Include(p => p.RedeSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
                         .Where(p => p.Id == palestranteId);
                         

            return await query.FirstOrDefaultAsync();
        }
    }
}
