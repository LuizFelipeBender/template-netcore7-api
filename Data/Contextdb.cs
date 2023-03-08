using DataAccess.Mappings;
using Entity;
using Microsoft.EntityFrameworkCore;
namespace Data;
public class Contextdb: DbContext
    {

        public Contextdb(DbContextOptions<Contextdb> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new TemplateMappings());

        }

        
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<TipoAtendimento> TipoAtendimentos { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Dono> Donos { get; set; }
        public DbSet<DonosPets> DonosPets1 { get; set; }

        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<ProfissionalTipoAtendimento> ProfissionaisTipoAtendimentos { get; set; }




    }

