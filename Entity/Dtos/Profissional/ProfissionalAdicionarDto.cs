﻿namespace Entity.Dtos.Profissional
{
    public class ProfissionalAdicionarDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public string? Cpf { get; set; }

        public uint CRV {get;set;}
    }
}
