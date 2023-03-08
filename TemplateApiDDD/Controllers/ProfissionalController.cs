using AutoMapper;
using Entity;
using Entity.Dtos.Profissional;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace PetshopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepository _repository;
        private readonly IMapper _mapper;

        public ProfissionalController(IProfissionalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var prof = await _repository.GetProfissionais();

            return prof.Any()
                ? Ok(prof)
                : NotFound("Profissionais não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Profissional inválido");

            var profissional = await _repository.GetProfissionalById(id);

            var profissionalRetorno = _mapper.Map<ProfissionalDetalhesDto>(profissional);

            return profissionalRetorno != null
                ? Ok(profissionalRetorno)
                : NotFound("Profissional não existe na base de dados");
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProfissionalAdicionarDto profissional)
        {
            if (string.IsNullOrEmpty(profissional.Nome)) return BadRequest("Dados inválidos");

            var profissionalAdicionar = _mapper.Map<Profissional>(profissional);

            _repository.Add(profissionalAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Profissional adicionado")
                : BadRequest("Erro ao adicionar o Profissional");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProfissionalAtualizarDto profissional)
        {
            if (id <= 0) return BadRequest("Profissional inválido");

            var profissionalBanco = await _repository.GetProfissionalById(id);

            if (profissionalBanco == null) 
                return NotFound("Profissional não encontrado na base de dados");

            var profissionalAtualizar = _mapper.Map(profissional, profissionalBanco);

            _repository.Update(profissionalAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Profissional atualizado")
                : BadRequest("Erro ao atualizar o Profissional");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Profissional inválido");

            var profissionalBanco = await _repository.GetProfissionalById(id);

            if (profissionalBanco == null)
                return NotFound("Profissional não encontrado na base de dados");

            _repository.Delete(profissionalBanco);

            return await _repository.SaveChangesAsync()
                ? Ok("Profissional deletado")
                : BadRequest("Erro ao deletar o Profissional");
        }

        [HttpPost("adicionar-TipoDeAtendimentos")]
        public async Task<IActionResult> PostProfissionalTipoAtendimento(ProfissionalTipoAtendimentoAdicionarDto profissional)
        {
            int profissionalId = profissional.ProfissionalId;
            int tipoAtendimentoId = profissional.TipoAtendimentoId;

            if (profissionalId <= 0 || tipoAtendimentoId <= 0) return BadRequest("Dados inválidos");

            var profissionalTipoAtendimento = await _repository.GetProfissionalTipoAtendimento(profissionalId, tipoAtendimentoId);

            if (profissionalTipoAtendimento != null) return Ok("TipoAtendimento já cadastrada");

            var tipoAtendimentoAdicionar = new ProfissionalTipoAtendimento
            {
                TipoAtendimentoId = tipoAtendimentoId,
                ProfissionalId = profissionalId
            };

            _repository.Add(tipoAtendimentoAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Especialiadade adicionada")
                : BadRequest("Erro ao adicionar tipoAtendimento");
        }

        [HttpDelete("{profissionalId}/deletar-tipoAtendimento/{tipoAtendimentoId}")]
        public async Task<IActionResult> DeleteProfissionalTipoAtendimento(int profissionalId, int tipoAtendimentoId)
        {
            if (profissionalId <= 0 || tipoAtendimentoId <= 0) return BadRequest("Dados inválidos");

            var profissionalTipoAtendimento = await _repository.GetProfissionalTipoAtendimento(profissionalId, tipoAtendimentoId);

            if (profissionalTipoAtendimento == null) 
                return BadRequest("TipoAtendimento não cadastrada");

            _repository.Delete(profissionalTipoAtendimento);

            return await _repository.SaveChangesAsync()
                ? Ok("Especialiadade deletada do profissional")
                : BadRequest("Erro ao deletar tipoAtendimento do profissional");
        }
    }
}
