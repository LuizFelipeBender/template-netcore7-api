using AutoMapper;
using Entity;
using Entity.Dtos.TipoAtendimento;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace PetshopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposDeAtendimentosController : ControllerBase
    {
        private readonly ITipoAtendimentoRepository _repository;
        private readonly IMapper _mapper;

        public TiposDeAtendimentosController(ITipoAtendimentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tipoAtendimentos = await _repository.GetTipoAtendimentos();

            return tipoAtendimentos.Any()
                ? Ok(tipoAtendimentos)
                : NotFound("Tipo de atendimento não encontradas");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest("Dados inválidos.");

            var tipoAtendimento = await _repository.GetTipoAtendimentoById(id);

            var tipoAtendimentoRetorno = _mapper.Map<TipoAtendimentoDetalhesDto>(tipoAtendimento);

            return tipoAtendimentoRetorno != null
                ? Ok(tipoAtendimentoRetorno)
                : NotFound("Tipo de Atendimento não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(TipoAtendimentoAdicionarDto tipoAtendimento)
        {
            if (string.IsNullOrEmpty(tipoAtendimento.Nome)) return BadRequest("Nome inválido");

            var tipoAtendimentoAdicionar = new TipoAtendimento
            {
                Nome = tipoAtendimento.Nome,
                Ativa = tipoAtendimento.Ativa
            };

            _repository.Add(tipoAtendimentoAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Tipo de Atendimento adicionado")
                : BadRequest("Erro ao adicionar o tipo atendimento");
        }

        [HttpPut("{id}/atualizar-status/")]
        public async Task<IActionResult> Put(int id, bool ativo)
        {
            if (id <= 0) return BadRequest("Tipo de atendimento inválida.");

            var tipoAtendimento = await _repository.GetTipoAtendimentoById(id);

            if (tipoAtendimento == null) return NotFound("Tipo de atendimento não existe na base de dados");

            string status = ativo ? "ativa" : "inativa";
            if (tipoAtendimento.Ativa == ativo) return Ok("O tipo de atendimento já está " + status);

            tipoAtendimento.Ativa = ativo;

            _repository.Update(tipoAtendimento);

            return await _repository.SaveChangesAsync()
                ? Ok("Status atualizado")
                : BadRequest("Erro ao atualizar status");
        }
    }
}
