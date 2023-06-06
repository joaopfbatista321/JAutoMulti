﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using jautomulti.Data;

#nullable disable

namespace jautomulti.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230606113411_DadosUpdate")]
    partial class DadosUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

                    b.HasData(
                        new
                        {
                            Id = "adm",
                            Name = "Admin",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = "prof",
                            Name = "Profissional",
                            NormalizedName = "PROFISSIONAL"
                        },
                        new
                        {
                            Id = "cli",
                            Name = "Cliente",
                            NormalizedName = "CLIENTE"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = "e48629eb-cbf6-4edc-9cee-ffe31b042104",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3182f07e-98fb-4ca6-aa3e-a841c5e81703",
                            Email = "joaopfbatista@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "JOAOPFBATISTA@GMAIL.COM",
                            NormalizedUserName = "JOAOPFBATISTA@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEG4ob8OPZKhxQSg94HdUxprutMIvi4rKmg8evFEAzee5QKGL1idugoakythCixgIzw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d60e4a2e-24d8-4d7c-a452-7e2658ea756f",
                            TwoFactorEnabled = false,
                            UserName = "joaopfbatista@gmail.com"
                        });
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
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProfissionaisReparacoes", b =>
                {
                    b.Property<int>("ListaProfissionaisNaReparacaoId")
                        .HasColumnType("int");

                    b.Property<int>("ListaReparacoesId")
                        .HasColumnType("int");

                    b.HasKey("ListaProfissionaisNaReparacaoId", "ListaReparacoesId");

                    b.HasIndex("ListaReparacoesId");

                    b.ToTable("ProfissionaisReparacoes");
                });

            modelBuilder.Entity("jautomulti.Models.Carros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DataCompra")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataMatricula")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext");

                    b.Property<string>("Matricula")
                        .HasColumnType("longtext");

                    b.Property<string>("Modelo")
                        .HasColumnType("longtext");

                    b.Property<int>("ProprietarioFK")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("longtext");

                    b.Property<string>("VIN")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProprietarioFK");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("jautomulti.Models.Fotografias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarroFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFotografia")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Local")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeFicheiro")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CarroFK");

                    b.ToTable("Fotografias");
                });

            modelBuilder.Entity("jautomulti.Models.Profissionais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Alcunha")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CodPostal")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Especializacao")
                        .HasColumnType("longtext");

                    b.Property<string>("Morada")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.HasKey("Id");

                    b.ToTable("Profissionais");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jjj@gmail.com",
                            Especializacao = "Eletricista",
                            Nome = "José Silva",
                            Telemovel = "951357852"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jjj@gmail.com",
                            Especializacao = "Pintura",
                            Nome = "Maria Gomes dos Santos",
                            Telemovel = "951357852"
                        },
                        new
                        {
                            Id = 3,
                            Email = "jjj@gmail.com",
                            Especializacao = "Mecanica",
                            Nome = "Ricardo Sousa",
                            Telemovel = "951357852"
                        });
                });

            modelBuilder.Entity("jautomulti.Models.Proprietarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("NIF")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("Sexo")
                        .HasColumnType("longtext");

                    b.Property<string>("Telemovel")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Proprietarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Luis@gmail.com",
                            NIF = "813635582",
                            Nome = "Luís Freitas",
                            Sexo = "M",
                            Telemovel = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            Email = "As@gmail.com",
                            NIF = "854613462",
                            Nome = "Andreia Gomes",
                            Sexo = "F",
                            Telemovel = "123456789"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Cris@gmail.com",
                            NIF = "265368715",
                            Nome = "Cristina Sousa",
                            Sexo = "F",
                            Telemovel = "123456789"
                        },
                        new
                        {
                            Id = 4,
                            Email = "so@gmail.com",
                            NIF = "835623190",
                            Nome = "Sónia Rosa",
                            Sexo = "F",
                            Telemovel = "123456789"
                        });
                });

            modelBuilder.Entity("jautomulti.Models.Reparacoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarroFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Observacoes")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarroFK");

                    b.ToTable("Reparacoes");
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

            modelBuilder.Entity("ProfissionaisReparacoes", b =>
                {
                    b.HasOne("jautomulti.Models.Profissionais", null)
                        .WithMany()
                        .HasForeignKey("ListaProfissionaisNaReparacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("jautomulti.Models.Reparacoes", null)
                        .WithMany()
                        .HasForeignKey("ListaReparacoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("jautomulti.Models.Carros", b =>
                {
                    b.HasOne("jautomulti.Models.Proprietarios", "Proprietario")
                        .WithMany("ListaCarros")
                        .HasForeignKey("ProprietarioFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proprietario");
                });

            modelBuilder.Entity("jautomulti.Models.Fotografias", b =>
                {
                    b.HasOne("jautomulti.Models.Carros", "Carro")
                        .WithMany("Fotografia")
                        .HasForeignKey("CarroFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carro");
                });

            modelBuilder.Entity("jautomulti.Models.Reparacoes", b =>
                {
                    b.HasOne("jautomulti.Models.Carros", "Carro")
                        .WithMany("ListaReparacoes")
                        .HasForeignKey("CarroFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carro");
                });

            modelBuilder.Entity("jautomulti.Models.Carros", b =>
                {
                    b.Navigation("Fotografia");

                    b.Navigation("ListaReparacoes");
                });

            modelBuilder.Entity("jautomulti.Models.Proprietarios", b =>
                {
                    b.Navigation("ListaCarros");
                });
#pragma warning restore 612, 618
        }
    }
}
