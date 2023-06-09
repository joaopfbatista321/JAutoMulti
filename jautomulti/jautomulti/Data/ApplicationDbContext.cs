﻿using jautomulti.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace jautomulti.Data {
    /// <summary>
    /// classe com os dados particulares do utilizador registado
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// nome de batismo do utilizador
        /// </summary>
        public string NomeDoUtilizador { get; set; }

        /// <summary>
        /// data em que o utilizador se registou
        /// </summary>
        public DateTime DataRegisto { get; set; }

    }



    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>{

        /// <summary>
        /// Apresenta a Base de dados do projeto
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        // <summary>
        /// este método é executado imediatamente antes 
        /// da criação do Modelo.
        /// É utilizado para adicionar as últimas instruções
        /// à criação do modelo
        /// </summary>
        /// <param name="modelBuilder"></param>

        protected override void OnModelCreating(ModelBuilder builder) {
            // 'importa' todo o comportamento do método, 
            // aquando da sua definição na SuperClasse
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "adm", Name = "Admin", NormalizedName = "ADMINISTRADOR" },
                new IdentityRole { Id = "prof", Name = "Profissional", NormalizedName = "PROFISSIONAL" },
                new IdentityRole { Id = "cli", Name = "Cliente", NormalizedName = "CLIENTE" }
             );
            

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Email = "joaopfbatista@gmail.com",
                NormalizedEmail = "JOAOPFBATISTA@GMAIL.COM",
                UserName = "joaopfbatista@gmail.com",
                NormalizedUserName = "JOAOPFBATISTA@GMAIL.COM",
                Id=Guid.NewGuid().ToString(),
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null,"Joaopaulo123456789!")
            });



            // adicionar registos que serão adicionados às
            // tabelas da BD
            builder.Entity<Profissionais>().HasData(
               new Profissionais()
               {
                   Id = 1,
                   Nome = "José Silva",
                   Especializacao = "Eletricista",
                   Email ="jjj@gmail.com",
                   Telemovel ="951357852"
                  // Fotografia = "Jose.jpg"
               },
               new Profissionais()
               {
                   Id = 2,
                   Nome = "Maria Gomes dos Santos",
                   Especializacao = "Pintura",
                   Email = "jjj@gmail.com",
                   Telemovel = "951357852"
                   // Fotografia = "Maria.jpg"
               },
               new Profissionais()
               {
                   Id = 3,
                   Nome = "Ricardo Sousa",
                   Especializacao = "Mecanica",
                   Email = "jjj@gmail.com",
                   Telemovel = "951357852"
                   //Fotografia = "Ricardo.jpg"
               }
            );

            builder.Entity<Proprietarios>().HasData(
               new Proprietarios { Id = 1, Nome = "Luís Freitas", Sexo = "M", NIF = "813635582", Email ="Luis@gmail.com", Telemovel = "123456789" },
               new Proprietarios { Id = 2, Nome = "Andreia Gomes", Sexo = "F", NIF = "854613462" ,Email = "As@gmail.com", Telemovel = "123456789" },
               new Proprietarios { Id = 3, Nome = "Cristina Sousa", Sexo = "F", NIF = "265368715", Email = "Cris@gmail.com", Telemovel = "123456789" },
               new Proprietarios { Id = 4, Nome = "Sónia Rosa", Sexo = "F", NIF = "835623190", Email = "so@gmail.com", Telemovel = "123456789" }
            );

            


        }
        
        /*
         * Criação da tabela de Base dados
         */

        public DbSet<Profissionais> Profissionais { get; set; }
        public DbSet<Reparacoes> Reparacoes { get; set; }
        public DbSet<Proprietarios> Proprietarios { get; set; }
        public DbSet<Carros> Carros { get; set; }
        public DbSet<Fotografias> Fotografias { get; set; }


    }
}