﻿using Entity;
using Entity.Dtos.Profissional;

namespace Service.Interfaces
{
    public interface IProfissionalRepository : IBaseRepository
    {
        Task<IEnumerable<ProfissionalDto>> GetProfissionais();
        Task<Profissional> GetProfissionalById(int id);
        Task<ProfissionalTipoAtendimento> GetProfissionalTipoAtendimento(int profissionalId, int tipoAtendimentoId);
    }
}
