using Entity.Dtos.Dono;
using Entity.Dtos.Pet;
using Entity.Dtos.Profissional;
using Entity.Dtos.TipoAtendimento;

namespace Entity.Dtos.Consulta
{
    public class ConsultaDetalhesDto
    {
        public int Id { get; set; }
        public DateTime DataHorario { get; set;} 
        public string? Descricao { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public TipoAtendimentoDto? TipoAtendimento { get; set; }
        public ProfissionalDto? Profissional { get; set; }
        public PetDto? Pet { get; set; }
        public DonoDto? Dono { get; set; }

    }
}
