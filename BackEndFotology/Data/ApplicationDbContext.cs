using BackEndFotology.Models;
using BackEndFotology.Modelos;
using BackEndFotology.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BackEndFotology.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fotografo> Fotografos { get; set; }
        public DbSet<Portafolio> Portafolios { get; set; }
        public DbSet<Fotografia> Fotografias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<AppUser> AppUser { get; set; }

    }
}
