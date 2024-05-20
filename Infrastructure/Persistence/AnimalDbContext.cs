using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AnimalDbContext: DbContext
    {
        public DbSet <Animal> Animales {  get; set; }
        public DbSet<AnimalRaza> AnimalesRazas { get; set; }
        public DbSet<AnimalTipo> AnimalesTipos {  get; set; }
        public DbSet<Media> Medias {get;set;}
        
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Media>(entity =>{
                entity.ToTable("Media");
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Id).ValueGeneratedOnAdd();
                entity.Property(f => f.url).IsRequired();

                entity.HasOne(f => f.Animal)
                .WithMany(a => a.Media)
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

                entity.HasMany(a => a.Media)
                .WithOne(f => f.Animal);
            });

            modelBuilder.Entity<AnimalTipo>().HasData(
                new AnimalTipo
                {
                    Id = 1,
                    Descripcion = "Perro"
                },
                new AnimalTipo
                {
                    Id = 2,
                    Descripcion = "Gato"
                }
            );

            modelBuilder.Entity<AnimalRaza>().HasData(
              
                new AnimalRaza { Id = 3, Descripcion = "Labrador Retriever", TipoId = 1 },
                new AnimalRaza { Id = 4, Descripcion = "Bulldog", TipoId = 1 },
                new AnimalRaza { Id = 5, Descripcion = "Beagle", TipoId = 1 },
                new AnimalRaza { Id = 6, Descripcion = "Poodle", TipoId = 1 },
                new AnimalRaza { Id = 7, Descripcion = "German Shepherd", TipoId = 1 },
                new AnimalRaza { Id = 8, Descripcion = "Golden Retriever", TipoId = 1 },
                new AnimalRaza { Id = 9, Descripcion = "Chihuahua", TipoId = 1 },
                new AnimalRaza { Id = 10, Descripcion = "Boxer", TipoId = 1 },
                new AnimalRaza { Id = 1, Descripcion = "Mestizo", TipoId = 1 },
                new AnimalRaza { Id = 2, Descripcion = "Otro", TipoId = 1 },

              
                new AnimalRaza { Id = 13, Descripcion = "Siamese", TipoId = 2 },
                new AnimalRaza { Id = 14, Descripcion = "Persian", TipoId = 2 },
                new AnimalRaza { Id = 15, Descripcion = "Maine Coon", TipoId = 2 },
                new AnimalRaza { Id = 16, Descripcion = "Ragdoll", TipoId = 2 },
                new AnimalRaza { Id = 17, Descripcion = "Bengal", TipoId = 2 },
                new AnimalRaza { Id = 18, Descripcion = "Sphynx", TipoId = 2 },
                new AnimalRaza { Id = 19, Descripcion = "Russian Blue", TipoId = 2 },
                new AnimalRaza { Id = 20, Descripcion = "Scottish Fold", TipoId = 2 },
                new AnimalRaza { Id = 11, Descripcion = "Mestizo", TipoId = 2 },
                new AnimalRaza { Id = 12, Descripcion = "Otro", TipoId = 2 }
            );


        }
    }
}
