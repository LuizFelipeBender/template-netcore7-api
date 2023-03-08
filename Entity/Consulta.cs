namespace Entity
{
    public class Consulta : Template
    {
        public DateTime DataHorario { get; set; }
        public string? Diagnostico{get;set;} 
        public string? Comentarios{get;set;} 
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public string? Descricao { get; set; }
        public int PetId { get; set; }
        public Pet? Pet { get; set; }
        public int TipoAtendimentoId { get; set; }
        public TipoAtendimento? TipoAtendimento { get; set; }
        public int ProfissionalId { get; set; }
        public Profissional? Profissional { get; set; }
        public int DonoId { get; set; }
        public Dono? Dono { get; set; }
    }
}