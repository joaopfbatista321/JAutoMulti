using jautomulti.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace jautomulti.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        /*
         * Criação da tabela de Base dados
         */

        public DbSet<Mecanicos> Mecanics { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Carros> Carros { get; set; }
        public DbSet<Fotografias> Fotografias { get;set; }

    }
}