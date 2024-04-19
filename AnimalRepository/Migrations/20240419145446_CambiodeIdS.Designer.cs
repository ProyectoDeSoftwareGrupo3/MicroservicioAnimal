﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimalRepository.Migrations
{
    [DbContext(typeof(AnimalDbContext))]
    [Migration("20240419145446_CambiodeIdS")]
    partial class CambiodeIdS
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Adoptado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("AnimalTipoId")
                        .HasColumnType("int");

                    b.Property<int>("Edad")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<Guid>("GaleriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Historia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(3,2)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AnimalTipoId");

                    b.HasIndex("GaleriaId")
                        .IsUnique();

                    b.ToTable("Animal", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AnimalGaleria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AnimalGaleria", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AnimalRaza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoId");

                    b.ToTable("AnimalRaza", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AnimalTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimalTipo", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("GaleriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GaleriaId");

                    b.ToTable("Foto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Animal", b =>
                {
                    b.HasOne("Domain.Entities.AnimalTipo", "Tipo")
                        .WithMany("Animales")
                        .HasForeignKey("AnimalTipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.AnimalGaleria", "Galeria")
                        .WithOne("Animal")
                        .HasForeignKey("Domain.Entities.Animal", "GaleriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Galeria");

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("Domain.Entities.AnimalRaza", b =>
                {
                    b.HasOne("Domain.Entities.AnimalTipo", "Tipo")
                        .WithMany("Razas")
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("Domain.Entities.Foto", b =>
                {
                    b.HasOne("Domain.Entities.AnimalGaleria", "Galeria")
                        .WithMany("Fotos")
                        .HasForeignKey("GaleriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Galeria");
                });

            modelBuilder.Entity("Domain.Entities.AnimalGaleria", b =>
                {
                    b.Navigation("Animal")
                        .IsRequired();

                    b.Navigation("Fotos");
                });

            modelBuilder.Entity("Domain.Entities.AnimalTipo", b =>
                {
                    b.Navigation("Animales");

                    b.Navigation("Razas");
                });
#pragma warning restore 612, 618
        }
    }
}
