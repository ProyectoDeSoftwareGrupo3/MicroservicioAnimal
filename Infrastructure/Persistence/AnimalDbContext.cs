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
        public DbSet<AnimalRaza> AnimalesRazas { get; set; }
        public DbSet<AnimalTipo> AnimalesTipos {  get; set; }
        public DbSet<Foto> Fotos {get;set;}
        
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Foto>(entity =>{
                entity.ToTable("Foto");
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Id).ValueGeneratedOnAdd();
                entity.Property(f => f.url).IsRequired();

                entity.HasOne(f => f.Animal)
                .WithMany(a => a.Fotos)
                .HasForeignKey(f => f.AnimalId);
            });

            modelBuilder.Entity<AnimalRaza>(entity =>
            {
                entity.ToTable("AnimalRaza");
                entity.HasKey(ar => ar.Id);
                entity.Property(ar =>ar.Id).ValueGeneratedOnAdd();
                entity.Property(ar => ar.Descripcion).IsRequired();

                entity.HasOne(ar => ar.Tipo)
                .WithMany(at => at.Razas)
                .HasForeignKey(at => at.TipoId);

                entity.HasMany(ar => ar.Animales)
                .WithOne(a => a.Raza);
            });
            modelBuilder.Entity<AnimalTipo>(entity =>
            {
                entity.ToTable("AnimalTipo");
                entity.HasKey(at => at.Id);
                entity.Property(at => at.Id).ValueGeneratedOnAdd();
                entity.Property(at => at.Descripcion).IsRequired();

                entity.HasMany(at => at.Razas)
                .WithOne(ar => ar.Tipo);
                
            });

            modelBuilder.Entity<Animal>(entity =>{
                entity.ToTable("Animal");
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).ValueGeneratedOnAdd();
                entity.Property(a => a.Nombre).HasMaxLength(50).IsRequired();
                entity.Property(a => a.Genero).IsRequired();
                entity.Property(a =>a.Edad).HasMaxLength(50).IsRequired();
                entity.Property(a => a.Peso).HasColumnType("decimal(5,2)").IsRequired();
                entity.Property(a => a.Adoptado).HasDefaultValue(false);

                entity.HasOne(a => a.Raza)
                .WithMany(r => r.Animales)
                .HasForeignKey(a => a.AnimalRazaId);

                entity.HasMany(a => a.Fotos)
                .WithOne(f => f.Animal);
            });

            modelBuilder.Entity<AnimalTipo>().HasData(
                new AnimalTipo
                {
                    Id = 1,
                    Descripcion="Perro"
                },
                new AnimalTipo
                {
                    Id=2,
                    Descripcion = "Gato"
                }
                );
            
            
        }
    }
}
