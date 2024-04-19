using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AnimalDbContext: DbContext
    {
        public DbSet <Animal> Animales {  get; set; }
        public DbSet<AnimalGaleria> AnimalesGalerias {  get; set; }
        public DbSet<AnimalRaza> AnimalesRazas { get; set; }
        public DbSet<AnimalTipo> AnimalesTipos {  get; set; }
        
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalGaleria>(entity =>
            {
                entity.ToTable("AnimalGaleria");
                entity.HasKey(ag => ag.Id);
                entity.Property(ag => ag.Id).ValueGeneratedOnAdd();
                entity.Property(ag => ag.Foto).IsRequired();

                entity.HasMany(ag => ag.Animales)
                .WithOne(ag => ag.Galeria);
            });

            modelBuilder.Entity<AnimalRaza>(entity =>
            {
                entity.ToTable("AnimalRaza");
                entity.HasKey(ar => ar.Id);
                entity.Property(ar =>ar.Id).ValueGeneratedOnAdd();
                entity.Property(ar => ar.Descripcion).IsRequired();

                entity.HasMany(ar => ar.Tipos)
                .WithOne(at => at.Raza);
            });
            modelBuilder.Entity<AnimalTipo>(entity =>
            {
                entity.ToTable("AnimalTipo");
                entity.HasKey(at => at.Id);
                entity.Property(at => at.Id).ValueGeneratedOnAdd();
                entity.Property(at => at.Descripcion).IsRequired();

                entity.HasOne<AnimalRaza>(at => at.Raza)
                .WithMany(ar => ar.Tipos)
                .HasForeignKey(at => at.AnimalRazaId).IsRequired();
                
            });

            modelBuilder.Entity<Animal>(entity =>{
                entity.ToTable("Animal");
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).ValueGeneratedOnAdd();
                entity.Property(a => a.Nombre).HasMaxLength(50).IsRequired();
                entity.Property(a => a.Genero).HasMaxLength(10).IsRequired();
                entity.Property(a =>a.Edad).HasMaxLength(50).IsRequired();
                entity.Property(a => a.Peso).HasColumnType("decimal(3,2)").IsRequired();
                entity.Property(a => a.Adoptado).HasDefaultValue(false);
                
                entity.HasOne(a => a.Tipo)
                .WithMany(at => at.Animales)
                .HasForeignKey(a => a.AnimalTipoId);

                entity.HasOne(a => a.Galeria)
                .WithMany(ag => ag.Animales)
                .HasForeignKey(a => a.GaleriaId);
            });
            
            
        }
    }
}
