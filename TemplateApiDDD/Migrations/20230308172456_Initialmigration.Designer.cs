﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TemplateApiDDD.Migrations
{
    [DbContext(typeof(Contextdb))]
    [Migration("20230308172456_Initialmigration")]
    partial class Initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entity.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comentarios")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataHorario")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Data_Horario");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Diagnostico")
                        .HasColumnType("longtext");

                    b.Property<int>("DonoId")
                        .HasColumnType("int")
                        .HasColumnName("Id_Dono");

                    b.Property<int>("PetId")
                        .HasColumnType("int")
                        .HasColumnName("Id_Pet");

                    b.Property<decimal>("Preco")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)")
                        .HasColumnName("Preco");

                    b.Property<int>("ProfissionalId")
                        .HasColumnType("int")
                        .HasColumnName("Id_profissional");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.Property<int>("TipoAtendimentoId")
                        .HasColumnType("int")
                        .HasColumnName("Id_tipoAtendimento");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.HasIndex("ProfissionalId");

                    b.HasIndex("TipoAtendimentoId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("Entity.Dono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Celular");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Dono", (string)null);
                });

            modelBuilder.Entity("Entity.DonosPets", b =>
                {
                    b.Property<int>("DonoId")
                        .HasColumnType("int")
                        .HasColumnName("Id_Dono");

                    b.Property<int>("PetId")
                        .HasColumnType("int")
                        .HasColumnName("Id_Pet");

                    b.HasKey("DonoId", "PetId");

                    b.HasIndex("PetId");

                    b.ToTable("Pets_Donos", (string)null);
                });

            modelBuilder.Entity("Entity.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Altura")
                        .HasColumnType("longtext")
                        .HasColumnName("Altura");

                    b.Property<int>("Idade")
                        .HasColumnType("int")
                        .HasColumnName("Idade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Peso")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Peso");

                    b.Property<string>("Raca")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Raca");

                    b.HasKey("Id");

                    b.ToTable("Pet", (string)null);
                });

            modelBuilder.Entity("Entity.Profissional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Ativo");

                    b.Property<uint>("CRV")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Celular")
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Profissional", (string)null);
                });

            modelBuilder.Entity("Entity.ProfissionalTipoAtendimento", b =>
                {
                    b.Property<int>("TipoAtendimentoId")
                        .HasColumnType("int")
                        .HasColumnName("Id_tipoAtendimento");

                    b.Property<int>("ProfissionalId")
                        .HasColumnType("int")
                        .HasColumnName("Id_profissional");

                    b.HasKey("TipoAtendimentoId", "ProfissionalId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Profissional_TipoAtendimento", (string)null);
                });

            modelBuilder.Entity("Entity.TipoAtendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<bool>("Ativa")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Ativa");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("TipoAtendimento", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entity.Consulta", b =>
                {
                    b.HasOne("Entity.Dono", "Dono")
                        .WithMany("Consultas")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Pet", "Pet")
                        .WithMany("Consultas")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Profissional", "Profissional")
                        .WithMany("Consultas")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.TipoAtendimento", "TipoAtendimento")
                        .WithMany("Consultas")
                        .HasForeignKey("TipoAtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dono");

                    b.Navigation("Pet");

                    b.Navigation("Profissional");

                    b.Navigation("TipoAtendimento");
                });

            modelBuilder.Entity("Entity.DonosPets", b =>
                {
                    b.HasOne("Entity.Dono", "Donos")
                        .WithMany()
                        .HasForeignKey("DonoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Pet", "Pets")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donos");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Entity.ProfissionalTipoAtendimento", b =>
                {
                    b.HasOne("Entity.Profissional", "Profissionais")
                        .WithMany()
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.TipoAtendimento", "TipoAtendimento")
                        .WithMany()
                        .HasForeignKey("TipoAtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profissionais");

                    b.Navigation("TipoAtendimento");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.Dono", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("Entity.Pet", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("Entity.Profissional", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("Entity.TipoAtendimento", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
