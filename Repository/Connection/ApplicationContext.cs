using System;
using Domain.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repository.Connection
{
    public partial class ApplicationContext : DbContext
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public ApplicationContext(IHostingEnvironment hostingEnvironment)
            => _hostingEnvironment = hostingEnvironment;

        public virtual DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseSqlServer(
                _hostingEnvironment.IsDevelopment()
                    ? Environment.GetEnvironmentVariable("CONNECTION_STRING_DEV")
                    : Environment.GetEnvironmentVariable("CONNECTION_STRING_PRO")
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.ToTable("Filme");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AnoLancamento)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
