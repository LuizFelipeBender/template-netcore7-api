
using Entity;
using Entity.Dtos.Dono;

namespace Service.Interfaces
{
    public interface IDonoRepository : IBaseRepository
    {
        Task<IEnumerable<DonoDto>> GetDonosAsync();
        Task<Dono> GetDonosByIdAsync(int id);
    }
}
