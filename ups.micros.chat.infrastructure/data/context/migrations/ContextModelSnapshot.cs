﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ups.micros.chat.infrastructure.data.context;

#nullable disable

namespace ups.micros.chat.infrastructure.data.context.migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ups.micros.chat.domain.entities.mensaje.Mensaje", b =>
                {
                    b.Property<Guid>("IdMensaje")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContenidoMensaje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.HasKey("IdMensaje");

                    b.ToTable("Mensajes");
                });

            modelBuilder.Entity("ups.micros.chat.domain.entities.usuario.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Usuario");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ups.micros.chat.domain.entities.usuario.UsuarioChat", b =>
                {
                    b.Property<Guid>("IdUsuarioChat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<Guid>("IdentificadorGrupo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuarioChat");

                    b.HasIndex("IdUsuario");

                    b.ToTable("UsuarioChat");
                });

            modelBuilder.Entity("ups.micros.chat.domain.entities.usuario.UsuarioChat", b =>
                {
                    b.HasOne("ups.micros.chat.domain.entities.usuario.Usuario", "UsuariosNav")
                        .WithMany("UsuarioChatNav")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuariosNav");
                });

            modelBuilder.Entity("ups.micros.chat.domain.entities.usuario.Usuario", b =>
                {
                    b.Navigation("UsuarioChatNav");
                });
#pragma warning restore 612, 618
        }
    }
}
