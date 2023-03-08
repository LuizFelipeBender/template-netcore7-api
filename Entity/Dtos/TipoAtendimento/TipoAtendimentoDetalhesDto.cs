using System.Collections.Generic;
using Entity.Dtos.Profissional;

namespace Entity.Dtos.TipoAtendimento
{
    public class TipoAtendimentoDetalhesDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public bool Ativa { get; set; }
        public List<ProfissionalDto>? Profissionais { get; set; }
    }
}
