using AutoMapper;
using PetshopAPI.Models.Dtos;
using PetshopAPI.Models.Entities;
using PetshopAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _repository;
        private readonly IMapper _mapper;

        public PetController(IPetRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Pets = await _repository.GetPets();

            return Pets.Any()
                ? Ok(Pets)
                : NotFound("Pets não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Pet inválido");

            var dono = await _repository.GetPetById(id);

            var donoRetorno = _mapper.Map<PetDetalhesDto>(dono);

            return donoRetorno != null
                ? Ok(donoRetorno)
                : NotFound("Pet não existe na base de dados");
        }

        [HttpPost]
        public async Task<IActionResult> Post(PetAdicionarDto dono)
        {
            if (string.IsNullOrEmpty(dono.Nome)) return BadRequest("Dados inválidos");

            var donoAdicionar = _mapper.Map<Pet>(dono);

            _repository.Add(donoAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Pet adicionado")
                : BadRequest("Erro ao adicionar o Pet");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PetAtualizarDto dono)
        {
            if (id <= 0) return BadRequest("Pet inválido");

            var donoBanco = await _repository.GetPetById(id);

            if (donoBanco == null) 
                return NotFound("Pet não encontrado na base de dados");

            var donoAtualizar = _mapper.Map(dono, donoBanco);

            _repository.Update(donoAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Pet atualizado")
                : BadRequest("Erro ao atualizar o Pet");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Pet inválido");

            var donoBanco = await _repository.GetPetById(id);

            if (donoBanco == null)
                return NotFound("Pet não encontrado na base de dados");

            _repository.Delete(donoBanco);

            return await _repository.SaveChangesAsync()
                ? Ok("Pet deletado")
                : BadRequest("Erro ao deletar o Pet");
        }

        [HttpPost("adicionar-dono")]
        public async Task<IActionResult> PostPetDono(PetDonoAdicionarDto dono)
        {
            int petId = dono.PetId;
            int donoId = dono.DonoId;

            if (petId <= 0 || donoId <= 0) return BadRequest("Dados inválidos");

            var Dono = await _repository.GetDonoPets(petId, donoId);

            if (Dono != null) return Ok("Dono já cadastrado");

            var DonoAdicionar = new DonosPets
            {
                DonoId = donoId,
                PetId = petId
            };

            _repository.Add(DonoAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Dono adicionado")
                : BadRequest("Erro ao adicionar Dono");
        }

        [HttpDelete("{petId}/deletar-Dono/{donoId}")]
        public async Task<IActionResult> DeletePetDono(int petId, int donoId)
        {
            if (petId <= 0 || donoId <= 0) return BadRequest("Dados inválidos");

            var Dono = await _repository.GetDonoPets(petId, donoId);

            if (Dono == null) 
                return BadRequest("Dono não cadastrado");

            _repository.Delete(Dono);

            return await _repository.SaveChangesAsync()
                ? Ok("Dono deletado do pet")
                : BadRequest("Erro ao deletar dono do pet");
        }
    }
}
