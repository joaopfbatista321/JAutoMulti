using jautomulti.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace jautomulti.Data {
    public class ApplicationDbContext : IdentityDbContext {

        /// <summary>
        /// Apresenta a Base de dados do projeto
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        /*protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>().HasData(new IdentityUser{
                Email = "joaopfbatista@gmail.com",
                NormalizedEmail = "JOAOPFBATISTA@GMAIL.COM",
                UserName = "joaopfbatista@gmail.com",
                NormalizedUserName = "JOAOPFBATISTA@GMAIL.COM",
                Id=Guid.NewGuid().ToString(),
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,"123")
            });
        }
        */
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