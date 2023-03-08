using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Map
{
    public class TipoAtendimentoMap : BaseMap<TipoAtendimento>
    {
        public TipoAtendimentoMap() : base ("TipoAtendimento")
        {}

        public override void Configure(EntityTypeBuilder<TipoAtendimento> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("Nome").IsRequired();
            builder.Property(x => x.Ativa).HasColumnName("Ativa");
        }
    }
}
