using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Dtos.Dono
{
    public class DonoAtualizarDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public string? Cpf { get; set; }
    }
}
