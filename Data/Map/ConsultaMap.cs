using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Map
{
    public class ConsultaMap : BaseMap<Consulta>
    {
        public ConsultaMap() : base("Consulta")
        {}

        public override void Configure(EntityTypeBuilder<Consulta>builder)
        {
            builder.Property(x => x.Status).HasColumnName("Status");
            builder.Property(x => x.Preco).HasPrecision(7, 2).HasColumnName("Preco");
            builder.Property(x => x.Preco).HasColumnName("Preco");
            builder.Property(x => x.DataHorario).HasColumnName("Data_Horario").IsRequired();

            builder.Property(x => x.PetId).HasColumnName("Id_Pet").IsRequired();
            builder.HasOne(x => x.Pet).WithMany(x => x.Consultas).HasForeignKey(x => x.PetId);

            builder.Property(x => x.DonoId).HasColumnName("Id_Dono").IsRequired();
            builder.HasOne(x => x.Dono).WithMany(x => x.Consultas).HasForeignKey(x => x.PetId);

            builder.Property(x => x.ProfissionalId).HasColumnName("Id_profissional").IsRequired();
            builder.HasOne(x => x.Profissional).WithMany(x => x.Consultas).HasForeignKey(x => x.ProfissionalId);

            builder.Property(x => x.TipoAtendimentoId).HasColumnName("Id_tipoAtendimento").IsRequired();
            builder.HasOne(x => x.TipoAtendimento).WithMany(x => x.Consultas).HasForeignKey(x => x.TipoAtendimentoId);

        }
    }
}