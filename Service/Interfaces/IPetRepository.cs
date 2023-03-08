using Entity;
using PetshopAPI.Models.Dtos;

namespace Service.Interfaces
{
    public interface IPetRepository : IBaseRepository
    {
        Task<IEnumerable<PetDto>> GetPets();
        Task<Pet> GetPetById(int id);
        Task<DonosPets> GetDonoPets(int PetId, int DonoId );
    }
}
