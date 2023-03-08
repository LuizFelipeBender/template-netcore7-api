using AutoMapper;
using Entity.Dtos.Dono;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace PetshopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonoController : ControllerBase
    {
        private readonly IDonoRepository _repository;
        private readonly IMapper _mapper;

        public DonoController(IDonoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Donos = await _repository.GetDonosAsync();

            return Donos.Any()
                    ? Ok(Donos)
                    : BadRequest("Dono não encontrado.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dono = await _repository.GetDonosByIdAsync(id);

            var DonoRetorno = _mapper.Map<DonoDetalhesDto>(Dono);

            return DonoRetorno != null
                    ? Ok(DonoRetorno)
                    : BadRequest("Dono não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(DonoAdicionarDto Dono)
        {
            if (Dono == null) return BadRequest("Dados Inválidos");

            var DonoAdicionar = _mapper.Map<Entity.Dono>(Dono);

            _repository.Add(DonoAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Dono adicionado com sucesso")
                : BadRequest("Erro ao salvar o Dono");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DonoAtualizarDto Dono)
        {
            if (id <= 0) return BadRequest("Usuário não informado");

            var DonoBanco = await _repository.GetDonosByIdAsync(id);

            var DonoAtualizar = _mapper.Map(Dono, DonoBanco);

            _repository.Update(DonoAtualizar);

            return await _repository.SaveChangesAsync()
                 ? Ok("Dono atualizado com sucesso")
                 : BadRequest("Erro ao atualizar o Dono");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Dono inválido");

            var DonoExclui = await _repository.GetDonosByIdAsync(id);

            if (DonoExclui == null) return NotFound("Dono não encontrado");

            _repository.Delete(DonoExclui);

            return await _repository.SaveChangesAsync()
                 ? Ok("Dono deletado com sucesso")
                 : BadRequest("Erro ao deletar o Dono");
        }
    }
}
