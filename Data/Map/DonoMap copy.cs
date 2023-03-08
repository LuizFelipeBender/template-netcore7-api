using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity;

namespace Data.Map
{
    public class DonoMap : BaseMap<Dono>
    {
        public DonoMap() : base ("Dono")
        {}

        public override void Configure(EntityTypeBuilder<Dono> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cpf).HasColumnName("Cpf").HasColumnType("varchar(11)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("varchar(50)");
            builder.Property(x => x.Celular).HasColumnName("Celular").HasColumnType("varchar(100)").IsRequired();
        }
    }
}
