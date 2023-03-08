using Microsoft.EntityFrameworkCore;
using Service;
using Service.Interfaces;
using Data;
using Entity.Dtos.Pet;
using Entity;

namespace PetshopAPI.Repository
{
    public class PetRepository : BaseRepository, IPetRepository
    {
        private readonly Contextdb _context;

        public PetRepository(Contextdb context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PetDto>> GetPets()
        {
            return await _context.Pets
                .Select(x => new PetDto {Id = x.Id, Nome = x.Nome}).ToListAsync();
        }

        public async Task<Pet> GetPetById(int id)
        {
            return await _context.Pets
                .Include(x => x.Consultas)
                .Include(x => x.Donos)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<DonosPets> GetDonoPets(int petId, int donoId)
        {
            return await _context.DonosPets1
                .Where(x => x.PetId == petId && x.DonoId == donoId)
                .FirstOrDefaultAsync();
        }
    }
}
