using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Dtos.Consulta
{
    public class ConsultaAtulizarDto
    {
        public DateTime DataHorario { get; set; }
        public int Status { get; set; }
        public string? Diagnostico{get;set;} 
        public string? Comentarios{get;set;} 
        public decimal Preco { get; set; }
        public string? Descricao { get; set; }

        public int ProfissionalId {get;set;}
    }
}