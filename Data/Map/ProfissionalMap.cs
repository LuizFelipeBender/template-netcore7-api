using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entity;

namespace Data.Map
{
    public class ProfissionalMap : BaseMap<Profissional>
    {
        public ProfissionalMap() : base ("Profissional")
        {}

        public override void Configure(EntityTypeBuilder<Profissional> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("Ativo");

            builder.HasMany(x => x.TipoAtendimentos)
                .WithMany(x => x.Profissionais)
                .UsingEntity<ProfissionalTipoAtendimento>(
                    x => x.HasOne(p => p.TipoAtendimento).WithMany().HasForeignKey(x => x.TipoAtendimentoId),
                    x => x.HasOne(p => p.Profissionais).WithMany().HasForeignKey(x => x.ProfissionalId),
                    x =>
                    {
                        x.ToTable("Profissional_TipoAtendimento");

                        x.HasKey(p => new { p.TipoAtendimentoId, p.ProfissionalId });

                        x.Property(p => p.TipoAtendimentoId).HasColumnName("Id_tipoAtendimento").IsRequired();
                        x.Property(p => p.ProfissionalId).HasColumnName("Id_profissional").IsRequired();
                    }
                ); ;
        }
    }
}
