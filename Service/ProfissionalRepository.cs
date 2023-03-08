using PetshopAPI.Data;
using PetshopAPI.Models.Dtos;
using PetshopAPI.Models.Entities;
using PetshopAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service;
using Service.Interfaces;
using Data;

namespace PetshopAPI.Repository
{
    public class ProfissionalRepository : BaseRepository, IProfissionalRepository
    {
        private readonly Contextdb _context;

        public ProfissionalRepository(Contextdb context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProfissionalDto>> GetProfissionais()
        {
            return await _context.Profissionais
                .Select(x => new ProfissionalDto {Id = x.Id, Nome = x.Nome, Ativo = x.Ativo}).ToListAsync();
        }

        public async Task<Profissional> GetProfissionalById(int id)
        {
            return await _context.Profissionais
                .Include(x => x.Consultas)
                .Include(x => x.TipoAtendimentos)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProfissionalTipoAtendimento> GetProfissionalTipoAtendimento(int profissionalId, int tipoAtendimentoId)
        {
            return await _context.ProfissionaisTipoAtendimentos
                .Where(x => x.ProfissionalId == profissionalId && x.TipoAtendimentoId == tipoAtendimentoId)
                .FirstOrDefaultAsync();
        }
    }
}
