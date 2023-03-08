using Data;
using Entity;
using Entity.Dtos.TipoAtendimento;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Interfaces;

namespace PetshopAPI.Repository
{
    public class TipoAtendimentoRepository : BaseRepository, ITipoAtendimentoRepository
    {
        private readonly Contextdb _context;

        public TipoAtendimentoRepository(Contextdb context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TipoAtendimentoDto>> GetTipoAtendimentos()
        {
            return await _context.TipoAtendimentos
                .Select(x => new TipoAtendimentoDto { Id = x.Id, Nome = x.Nome, Ativa = x.Ativa })
                .ToListAsync();
        }
        public async Task<TipoAtendimento> GetTipoAtendimentoById(int id)
        {
            return await _context.TipoAtendimentos
                .Include(x => x.Profissionais)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }        
    }
}
