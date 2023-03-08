namespace Entity
{
    public class ProfissionalTipoAtendimento
    {
        public int ProfissionalId { get; set; }
        public Profissional? Profissionais { get; set; }
        public int TipoAtendimentoId { get; set; }
        public TipoAtendimento? TipoAtendimento { get; set; }
    }
}