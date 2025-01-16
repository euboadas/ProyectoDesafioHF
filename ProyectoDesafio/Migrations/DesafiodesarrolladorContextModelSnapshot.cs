﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoDesafio.Models;

#nullable disable

namespace ProyectoDesafio.Migrations
{
    [DbContext(typeof(DesafiodesarrolladorContext))]
    partial class DesafiodesarrolladorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 30);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoDesafio.Models.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("descripcion");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("estado");

                    b.Property<DateTime>("Fechavencimiento")
                        .HasColumnType("datetime")
                        .HasColumnName("fechavencimiento");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("titulo");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Tarea");

                    b.HasIndex("UsuarioId")
                        .HasDatabaseName("IX_Tarea_6B09");

                    b.HasIndex(new[] { "Id" }, "IX_UsuarioTarea");

                    b.ToTable("Tarea");

                    b.HasAnnotation("RemovePluralizingTableName", true);
                });

            modelBuilder.Entity("ProyectoDesafio.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("clave");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("correo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PK_Usuario");

                    b.ToTable("Usuario");

                    b.HasAnnotation("RemovePluralizingTableName", true);
                });

            modelBuilder.Entity("ProyectoDesafio.Models.Tarea", b =>
                {
                    b.HasOne("ProyectoDesafio.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Tarea_Usuario_6B09");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
