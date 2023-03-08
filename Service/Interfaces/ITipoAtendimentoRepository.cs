using Entity;
using Entity.Dtos.TipoAtendimento;
using PetshopAPI.Models.Dtos;

namespace Service.Interfaces
{
    public interface ITipoAtendimentoRepository : IBaseRepository
    {
        Task<IEnumerable<TipoAtendimentoDto>> GetTipoAtendimentos();
        Task<TipoAtendimento> GetTipoAtendimentoById(int id);
    }
}
