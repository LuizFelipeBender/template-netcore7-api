using Microsoft.EntityFrameworkCore;
using Service;
using Service.Interfaces;
using Data;
using Entity;
using Entity.Dtos.Dono;

namespace PetshopAPI.Repository
{
    public class DonoRepository : BaseRepository, IDonoRepository
    {
        private readonly Contextdb _context;

        public DonoRepository(Contextdb context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DonoDto>> GetDonosAsync()
        {
            return await _context.Donos
                .Select(x => new DonoDto { Id = x.Id, Nome = x.Nome })
                .ToListAsync();
        }

        public async Task<Dono> GetDonosByIdAsync(int id)
        {
            return await _context.Donos.Include(x => x.Pets)
                         .ThenInclude(c => c.Consultas)
                        .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
