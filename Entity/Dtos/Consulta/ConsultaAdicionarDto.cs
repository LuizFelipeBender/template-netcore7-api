using Newtonsoft.Json;

namespace Entity.Dtos.Consulta
{
    public class ConsultaAdicionarDto
    {
        public DateTime DataHorario { get; set; }
      
        public int Status { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? Diagnostico{get;set;} 
        public string? Comentarios{get;set;} 
        public int PetId { get; set; }
        public int TipoAtendimentoId { get; set; }
        public int ProfissionalId { get; set; }
        public int DonoId { get; set; }
    }
}