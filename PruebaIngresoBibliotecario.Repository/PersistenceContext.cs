using System;
using System.Reflection.Emit;
using System.Xml.Schema;
using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Domain;

namespace PruebaIngresoBibliotecario.Repository
{
    public class PersistenceContext : DbContext
    {
        public PersistenceContext(DbContextOptions<PersistenceContext> options) : base(options)
        {
        }

        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("mySchema");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.ToTable("Libros");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.ToTable("Usuarios");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.ToTable("Prestamos");
            });
        }
    }
}

