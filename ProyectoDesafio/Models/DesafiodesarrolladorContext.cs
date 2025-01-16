using System;
using System.Collections.Generic;
using Brainary.Commons.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoDesafio.Models
{
    public partial class DesafiodesarrolladorContext : DbContext
    {
        public DesafiodesarrolladorContext(DbContextOptions<DesafiodesarrolladorContext> options)
            : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.SetMaxIdentifierLength(30); // Largo máximo de nombres de objeto.
            modelBuilder.RemovePluralizingTableName(); // Nombres de tabla según nombre de entidad sin pluralizar.
            modelBuilder.UseShortNamePk(); // Nombres de PK cortos.
            modelBuilder.UseShortNameFk(); // Nombres de FK cortos.
            modelBuilder.UseShortNameIx(); // Nombres de IX cortos.
            modelBuilder.UseStringEnumValues(); // Valores de enums como string.
            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasKey(t => t.Id);

                entity.HasIndex(e => e.Id, "IX_UsuarioTarea");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .HasColumnName("estado");

                entity.Property(e => e.Fechavencimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fechavencimiento");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .HasMaxLength(100)
                    .HasColumnName("clave");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .HasColumnName("correo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
