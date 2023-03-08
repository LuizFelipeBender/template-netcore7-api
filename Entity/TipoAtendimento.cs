using System.Collections.Generic;

namespace Entity
{
    public class TipoAtendimento : Template
    {
        public string? Nome { get; set; }
        public bool Ativa { get; set; }
        public List<Profissional>? Profissionais { get; set; }
        public List<Consulta>? Consultas { get; set; }
    }
}