using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entity;

namespace Data.Map
{
    public class PetMap : BaseMap<Pet>
    {
        public PetMap() : base ("Pet")
        {}

        public override void Configure(EntityTypeBuilder<Pet> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Raca).HasColumnName("Raca").HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Altura).HasColumnName("Altura");
            builder.Property(x => x.Peso).HasColumnName("Peso").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Idade).HasColumnName("Idade");

             builder.HasMany(x => x.Donos)
                .WithMany(x => x.Pets)
                .UsingEntity<DonosPets>(
                    x => x.HasOne(p => p.Donos).WithMany().HasForeignKey(x => x.DonoId),
                    x => x.HasOne(p => p.Pets).WithMany().HasForeignKey(x => x.PetId),
                    x =>
                    {
                        x.ToTable("Pets_Donos");

                        x.HasKey(p => new { p.DonoId, p.PetId });

                        x.Property(p => p.DonoId).HasColumnName("Id_Dono").IsRequired();
                        x.Property(p => p.PetId).HasColumnName("Id_Pet").IsRequired();
                                    }
                ); ;


        }
    }
}






