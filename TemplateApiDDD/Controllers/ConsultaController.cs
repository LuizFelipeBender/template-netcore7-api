using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetshopAPI.Models.Dtos;
using PetshopAPI.Models.Entities;
using PetShopApi.Models.Dtos;
using PetShopApi.Repository;

namespace PetShopApi.Controllers
{
    [Route("[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _repository ;
        private readonly IMapper _mapper ;


        public ConsultaController(IConsultaRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consulta = await _repository.GetConsultas();
            var consultaRetorno = _mapper.Map<IEnumerable<ConsultaDetalhesDto>>(consulta);
            return  consultaRetorno.Any()
            ? Ok(consultaRetorno)
            : BadRequest("Consulta não encontrada.");     
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id <= 0) BadRequest("Consulta inválida");
            var consulta = await _repository.GetConsultaById(id);
            var consultaRetorno = _mapper.Map<ConsultaDetalhesDto>(consulta);
            return  consultaRetorno != null
            ? Ok(consultaRetorno)
            : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post( ConsultaAdicionarDto consulta)
        {
            try
            {
            if (consulta==null) return BadRequest("Dados inválidos");

            var consultaAdicionar = _mapper.Map<Consulta>(consulta);
            _repository.Add(consultaAdicionar);

            return await _repository.SaveChangesAsync()
            ? Ok("Consulta finalizada")
            :BadRequest("Erro ao finalizar Consulta");   
            }
            catch (System.Exception e)
            {
              throw new Exception("Erro favor verifique os dados prenchidos" + e);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>Put(int id, ConsultaAtulizarDto consulta)
        {
        if (consulta == null) return BadRequest("Dados inválidos");
        var consutaBanco = await _repository.GetConsultaById(id);

        if (consutaBanco == null) BadRequest("Consulta não existe no banco de dados");
        if (consulta.DataHorario == new DateTime()) consulta.DataHorario = consutaBanco.DataHorario;
        if (consulta.ProfissionalId <= 0) consulta.ProfissionalId = consutaBanco.ProfissionalId;
        var consultarAtualizar = _mapper.Map(consulta,consutaBanco);
        _repository.Update(consultarAtualizar);

        return await _repository.SaveChangesAsync()
        ? Ok("dados da consulta atulizado")
        :BadRequest("Erro ao atualizar agendamento da consulta");
        }
        

    }
}