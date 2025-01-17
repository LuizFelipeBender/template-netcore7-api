﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Entity;
using DataAccess.Mappings;

namespace Data
{
    public class Contextdb : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        }
        public Contextdb(DbContextOptions<Contextdb> options) : base(options)
        {
        }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<TipoAtendimento> TipoAtendimentos { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Dono> Donos { get; set; }
        public DbSet<DonosPets> DonosPets1 { get; set; }

        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<ProfissionalTipoAtendimento> ProfissionaisTipoAtendimentos { get; set; }

    }
}

