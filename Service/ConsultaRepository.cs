using Microsoft.EntityFrameworkCore;
using Entity;
using Service;
using Data;
using Service.Interfaces;

namespace PetShopApi.Repository
{
    public class ConsultaRepository : BaseRepository, IConsultaRepository
    {
        private readonly Contextdb _context;

        public ConsultaRepository(Contextdb context) : base(context)
        {
            _context = context;
        }
        public async  Task<Consulta> GetConsultaById(int Id)
        {
            return await _context.Consultas
            .Include(x => x.Pet)
            .Include(x => x.Dono)
            .Include(x => x.Profissional)
            .Include(x => x.TipoAtendimento)
            .Where(x => x.Id == x.Id)
            .FirstOrDefaultAsync();         }

        public async Task<IEnumerable<Consulta>> GetConsultas()
        {
            return await _context.Consultas
            .Include(x => x.Pet)
            .Include(x => x.Dono)
            .Include(x => x.Profissional)
            .Include(x => x.TipoAtendimento)
            .ToListAsync();        }
    }
}