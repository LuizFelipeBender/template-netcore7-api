using Entity;

namespace Service.Interfaces
{
    public interface IConsultaRepository:IBaseRepository
    {
        Task<IEnumerable<Consulta>> GetConsultas();
    
        Task<Consulta> GetConsultaById(int id);
    }
}