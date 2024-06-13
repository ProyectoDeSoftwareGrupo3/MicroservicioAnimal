using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AnimalDbContext : DbContext
    {
        public DbSet<Animal> Animales { get; set; }
        public DbSet<AnimalRaza> AnimalesRazas { get; set; }
        public DbSet<AnimalTipo> AnimalesTipos { get; set; }
        public DbSet<Media> Medias { get; set; }

        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Media>(entity => {
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
                entity.Property(ar => ar.Id).ValueGeneratedOnAdd();
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

            modelBuilder.Entity<Animal>(entity => {
                entity.ToTable("Animal");
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).ValueGeneratedOnAdd();
                entity.Property(a => a.Nombre).HasMaxLength(50).IsRequired();
                entity.Property(a => a.Genero).IsRequired();
                entity.Property(a => a.Edad).HasMaxLength(50).IsRequired();
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

                new AnimalRaza { Id = 1, Descripcion = "Mestizo", TipoId = 1 },
                new AnimalRaza { Id = 2, Descripcion = "Otro", TipoId = 1 },
                new AnimalRaza { Id = 3, Descripcion = "Labrador Retriever", TipoId = 1 },
                new AnimalRaza { Id = 4, Descripcion = "Bulldog", TipoId = 1 },
                new AnimalRaza { Id = 5, Descripcion = "Beagle", TipoId = 1 },
                new AnimalRaza { Id = 6, Descripcion = "Caniche", TipoId = 1 },
                new AnimalRaza { Id = 7, Descripcion = "Pastor Aleman", TipoId = 1 },
                new AnimalRaza { Id = 8, Descripcion = "Golden Retriever", TipoId = 1 },
                new AnimalRaza { Id = 9, Descripcion = "Chihuahua", TipoId = 1 },
                new AnimalRaza { Id = 10, Descripcion = "Boxer", TipoId = 1 },


                new AnimalRaza { Id = 11, Descripcion = "Mestizo", TipoId = 2 },
                new AnimalRaza { Id = 12, Descripcion = "Otro", TipoId = 2 },
                new AnimalRaza { Id = 13, Descripcion = "Siamese", TipoId = 2 },
                new AnimalRaza { Id = 14, Descripcion = "Persa", TipoId = 2 },
                new AnimalRaza { Id = 15, Descripcion = "Maine Coon", TipoId = 2 },
                new AnimalRaza { Id = 16, Descripcion = "Ragdoll", TipoId = 2 },
                new AnimalRaza { Id = 17, Descripcion = "Bengal", TipoId = 2 },
                new AnimalRaza { Id = 18, Descripcion = "Sphynx", TipoId = 2 },
                new AnimalRaza { Id = 19, Descripcion = "Russian Blue", TipoId = 2 },
                new AnimalRaza { Id = 20, Descripcion = "Scottish Fold", TipoId = 2 }
                
            );

            modelBuilder.Entity<Animal>().HasData(
                new Animal
                {
                    Id = 1,
                    AnimalRazaId = 1,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Max",
                    Genero = true,
                    Edad = 5,
                    Peso = 30.5m,
                    Historia = "Max es un perrito muy amigable que adora jugar a buscar la pelota. Le encanta estar rodeado de personas y siempre está dispuesto a hacer nuevos amigos. Es un perro leal y muy cariñoso.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 2,
                    AnimalRazaId = 1,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Bella",
                    Genero = false,
                    Edad = 4,
                    Peso = 28.3m,
                    Historia = "Bella es una perra juguetona que disfruta de largos paseos y caricias en la barriga. Es muy sociable y le encanta interactuar con otros perros y personas. Bella es perfecta para una familia activa.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 3,
                    AnimalRazaId = 2,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Charlie",
                    Genero = true,
                    Edad = 6,
                    Peso = 24.1m,
                    Historia = "Charlie es un perro leal que adora estar cerca de su familia. A pesar de su aspecto robusto, es muy cariñoso y disfruta de los momentos de tranquilidad. Es un excelente compañero para cualquier hogar.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 4,
                    AnimalRazaId = 2,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Lucy",
                    Genero = false,
                    Edad = 3,
                    Peso = 21.7m,
                    Historia = "Lucy es una perrita muy tranquila que se lleva bien con los niños. Le encanta pasar el tiempo en casa y recibir mimos. Es una perrita muy leal y cariñosa, perfecta para cualquier familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 5,
                    AnimalRazaId = 3,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Buddy",
                    Genero = true,
                    Edad = 6,
                    Peso = 30.5m,
                    Historia = "Buddy es un Labrador Retriever lleno de energía y entusiasmo. Le encanta jugar y hacer ejercicio al aire libre. Es muy inteligente y siempre está dispuesto a aprender nuevos trucos.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 6,
                    AnimalRazaId = 3,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Daisy",
                    Genero = false,
                    Edad = 4,
                    Peso = 28.3m,
                    Historia = "Daisy es una perrita muy cariñosa que disfruta de largas caminatas y caricias. Es perfecta para una familia que le guste el aire libre y pasar tiempo juntos. Daisy es muy leal y protectora.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 7,
                    AnimalRazaId = 4,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Rocky",
                    Genero = true,
                    Edad = 5,
                    Peso = 24.1m,
                    Historia = "Rocky es un Bulldog robusto y amigable. Le gusta mucho jugar con otros perros y es muy sociable. Es un perro tranquilo que disfruta de los momentos de relajación junto a su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 8,
                    AnimalRazaId = 4,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Molly",
                    Genero = false,
                    Edad = 3,
                    Peso = 21.7m,
                    Historia = "Molly es una Bulldog muy tranquila y se lleva bien con niños. Es perfecta para un hogar con niños, ya que es muy paciente y cariñosa. Molly disfruta de las siestas y de la compañía de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 9,
                    AnimalRazaId = 5,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Jack",
                    Genero = true,
                    Edad = 4,
                    Peso = 15.5m,
                    Historia = "Jack es un Beagle curioso y lleno de vida. Siempre está buscando aventuras y le encanta explorar su entorno. Es muy inteligente y disfruta de los juegos de olfateo y búsqueda.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 10,
                    AnimalRazaId = 5,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Luna",
                    Genero = false,
                    Edad = 2,
                    Peso = 13.8m,
                    Historia = "Luna es muy juguetona y le encanta olfatear todo a su alrededor. Es ideal para paseos largos y actividades al aire libre. Luna es muy cariñosa y siempre está dispuesta a jugar.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 11,
                    AnimalRazaId = 6,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Cooper",
                    Genero = true,
                    Edad = 5,
                    Peso = 10.2m,
                    Historia = "Cooper es un Caniche inteligente y muy entrenado. Es perfecto para un hogar que le dedique tiempo y atención. Cooper disfruta de los juegos de inteligencia y siempre está listo para aprender.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 12,
                    AnimalRazaId = 6,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Sophie",
                    Genero = false,
                    Edad = 3,
                    Peso = 9.7m,
                    Historia = "Sophie es muy cariñosa y le encanta acurrucarse. Es ideal para un hogar tranquilo y amoroso. Sophie disfruta de las caricias y siempre está buscando la compañía de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 13,
                    AnimalRazaId = 7,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Bear",
                    Genero = true,
                    Edad = 6,
                    Peso = 35.4m,
                    Historia = "Bear es un Pastor Alemán muy protector. Es excelente para seguridad y compañía. Bear es muy leal y siempre está dispuesto a cuidar de su familia. Disfruta de los juegos y el ejercicio.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 14,
                    AnimalRazaId = 7,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Zoe",
                    Genero = false,
                    Edad = 4,
                    Peso = 32.8m,
                    Historia = "Zoe es muy leal y amigable. Le encanta estar activa y siempre está lista para jugar. Es una compañera perfecta para actividades al aire libre y disfruta de la compañía de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 15,
                    AnimalRazaId = 8,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Toby",
                    Genero = true,
                    Edad = 5,
                    Peso = 29.3m,
                    Historia = "Toby es un Golden Retriever muy cariñoso y sociable. Es perfecto para cualquier familia que busque un perro leal y amigable. Toby disfruta de los juegos y de las largas caminatas.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 16,
                    AnimalRazaId = 8,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Chloe",
                    Genero = false,
                    Edad = 3,
                    Peso = 27.5m,
                    Historia = "Chloe es muy dulce y se lleva bien con todos. Es ideal para un hogar con otros animales. Chloe es muy cariñosa y siempre está buscando la atención y el cariño de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 17,
                    AnimalRazaId = 9,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Oscar",
                    Genero = true,
                    Edad = 4,
                    Peso = 6.5m,
                    Historia = "Oscar es un Chihuahua muy valiente y enérgico. Le encanta estar cerca de su dueño y es muy protector. Es ideal para una persona que busque un compañero pequeño pero lleno de carácter.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 18,
                    AnimalRazaId = 9,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Lola",
                    Genero = false,
                    Edad = 2,
                    Peso = 5.8m,
                    Historia = "Lola es muy juguetona y le encanta ser el centro de atención. Es perfecta para un hogar que le guste la compañía de un perro pequeño y enérgico. Lola es muy cariñosa y siempre está lista para jugar.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 19,
                    AnimalRazaId = 10,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Duke",
                    Genero = true,
                    Edad = 5,
                    Peso = 28.2m,
                    Historia = "Duke es un Boxer muy activo y lleno de energía. Le encanta correr y jugar al aire libre. Es muy leal y protector, ideal para una familia que disfrute de las actividades físicas.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 20,
                    AnimalRazaId = 10,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Ruby",
                    Genero = false,
                    Edad = 3,
                    Peso = 26.4m,
                    Historia = "Ruby es una perrita muy juguetona y llena de vida. Disfruta de los juegos y de pasar tiempo con su familia. Es muy cariñosa y siempre está lista para una nueva aventura.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 21,
                    AnimalRazaId = 11,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Rex",
                    Genero = true,
                    Edad = 4,
                    Peso = 25.0m,
                    Historia = "Rex es un gato muy amigable y leal. Le encanta estar cerca de las personas y siempre está dispuesto a jugar. Es un gatito muy adaptable y se lleva bien con otros animales.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 22,
                    AnimalRazaId = 11,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Lily",
                    Genero = false,
                    Edad = 3,
                    Peso = 23.5m,
                    Historia = "Lily es una gatita Mestiza muy dulce y cariñosa. Es perfecta para una familia que busque un compañero leal y lleno de amor. Lily disfruta de los juegos y de la compañía de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 23,
                    AnimalRazaId = 12,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Sam",
                    Genero = true,
                    Edad = 4,
                    Peso = 20.5m,
                    Historia = "Sam es un michi muy curioso y juguetón. Le encanta explorar su entorno y hacer nuevos amigos. Es muy inteligente y siempre está dispuesto a aprender nuevas cosas.... y hacer desastres",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 24,
                    AnimalRazaId = 12,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Michifuzz",
                    Genero = false,
                    Edad = 2,
                    Peso = 18.9m,
                    Historia = "Michifuzz es una gatita muy dulce y cariñosa. Disfruta de los juegos y de pasar tiempo con su familia. Es perfecta para un hogar amoroso y paciente.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 25,
                    AnimalRazaId = 13,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Simba",
                    Genero = true,
                    Edad = 3,
                    Peso = 4.5m,
                    Historia = "Simba es un gato Siamese muy curioso y lleno de energía. Le encanta explorar y jugar con juguetes interactivos. Es muy cariñoso y disfruta de la compañía de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 26,
                    AnimalRazaId = 13,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Nala",
                    Genero = false,
                    Edad = 2,
                    Peso = 4.2m,
                    Historia = "Nala es una gatita Siamese muy juguetona y cariñosa. Disfruta de los juegos y de acurrucarse con su familia. Es perfecta para un hogar que le guste la compañía de un gato activo.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 27,
                    AnimalRazaId = 14,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Leo",
                    Genero = true,
                    Edad = 4,
                    Peso = 5.0m,
                    Historia = "Leo es un gato Persa muy tranquilo y cariñoso. Le encanta pasar tiempo en casa y recibir mimos. Es ideal para un hogar que busque un compañero tranquilo y amoroso.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 28,
                    AnimalRazaId = 14,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Mia",
                    Genero = false,
                    Edad = 3,
                    Peso = 4.7m,
                    Historia = "Mia es una gatita Persa muy dulce y cariñosa. Disfruta de la tranquilidad del hogar y de la compañía de su familia. Es perfecta para un hogar que le guste la compañía de un gato cariñoso.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 29,
                    AnimalRazaId = 15,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Oscar",
                    Genero = true,
                    Edad = 5,
                    Peso = 6.8m,
                    Historia = "Oscar es un gato Maine Coon muy juguetón y curioso. Le encanta explorar su entorno y jugar con otros gatos. Es muy cariñoso y disfruta de la compañía de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 30,
                    AnimalRazaId = 15,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Maggie",
                    Genero = false,
                    Edad = 3,
                    Peso = 6.5m,
                    Historia = "Maggie es una gatita Maine Coon muy juguetona y le encanta estar en compañía de otros gatos. Disfruta de los juegos y de acurrucarse con su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 31,
                    AnimalRazaId = 16,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Zeus",
                    Genero = true,
                    Edad = 4,
                    Peso = 5.9m,
                    Historia = "Zeus es un gato Ragdoll muy cariñoso. Le encanta ser el centro de atención y recibir mimos. Es muy tranquilo y disfruta de la compañía de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 32,
                    AnimalRazaId = 16,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Daisy",
                    Genero = false,
                    Edad = 2,
                    Peso = 5.7m,
                    Historia = "Daisy es una gatita Ragdoll muy dulce que busca un hogar donde pueda recibir mucho cariño. Es muy tranquila y le encanta estar cerca de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 33,
                    AnimalRazaId = 17,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Thor",
                    Genero = true,
                    Edad = 5,
                    Peso = 6.2m,
                    Historia = "Thor es un gato Bengala muy activo y juguetón. Le encanta explorar y jugar con juguetes interactivos. Es muy inteligente y disfruta de la compañía de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 34,
                    AnimalRazaId = 17,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Luna",
                    Genero = false,
                    Edad = 3,
                    Peso = 5.9m,
                    Historia = "Luna es una gatita Bengala muy curiosa y llena de energía. Le encanta explorar y jugar con otros gatos. Es muy cariñosa y disfruta de la compañía de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 35,
                    AnimalRazaId = 18,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Coco",
                    Genero = true,
                    Edad = 4,
                    Peso = 6.0m,
                    Historia = "Coco es un gato Sphynx muy curioso y juguetón. Le encanta estar en compañía de otros gatos y explorar su entorno. Es muy cariñoso y disfruta de la atención de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 36,
                    AnimalRazaId = 18,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Milo",
                    Genero = true,
                    Edad = 3,
                    Peso = 5.5m,
                    Historia = "Milo es un gato Sphynx muy tranquilo y amoroso. Disfruta de los momentos de calma en casa y de recibir mimos. Es perfecto para un hogar que busque un gato cariñoso y tranquilo.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 37,
                    AnimalRazaId = 19,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Misha",
                    Genero = false,
                    Edad = 4,
                    Peso = 5.8m,
                    Historia = "Misha es una gatita Russian Blue muy afectuosa y leal. Disfruta de los momentos tranquilos en casa y de la compañía de su familia. Es muy cariñosa y siempre está lista para recibir mimos.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 38,
                    AnimalRazaId = 19,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Oliver",
                    Genero = true,
                    Edad = 3,
                    Peso = 5.4m,
                    Historia = "Oliver es un gato Russian Blue muy juguetón y lleno de energía. Le encanta jugar con juguetes y explorar su entorno. Es muy cariñoso y disfruta de la compañía de su familia.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 39,
                    AnimalRazaId = 20,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Milo",
                    Genero = true,
                    Edad = 4,
                    Peso = 6.2m,
                    Historia = "Milo es un gato Scottish Fold muy tranquilo y cariñoso. Disfruta de los momentos de calma en casa y de recibir mimos. Es perfecto para un hogar que busque un compañero tranquilo y amoroso.",
                    Adoptado = false
                },
                new Animal
                {
                    Id = 40,
                    AnimalRazaId = 20,
                    UsuarioId = "19BB7F593372433FB34300E75953D3A3",
                    Nombre = "Luna",
                    Genero = false,
                    Edad = 3,
                    Peso = 5.9m,
                    Historia = "Luna es una gatita Scottish Fold muy juguetona y llena de vida. Disfruta de los juegos y de pasar tiempo con su familia. Es perfecta para un hogar amoroso y paciente.",
                    Adoptado = false
                }
            );

            modelBuilder.Entity<Media>().HasData(
                new Media
                {
                    Id = 1,
                    url = "https://live-mascotas-sanas-duenos-felices-blogs.cphostaccess.com/posts/easset_upload_file32027_708883_e.jpg",
                    AnimalId = 1,
                },
                new Media
                {
                    Id = 2,
                    url = "https://www.lt9.com.ar/uploads/s_fed89b6e647b9af00dcadfe.jpg",
                    AnimalId = 2,
                },
                new Media
                {
                    Id = 3,
                    url = "https://i0.wp.com/mascotass.com/wp-content/uploads/2011/12/Los-perros-mestizos.jpg",
                    AnimalId = 3,
                },
                new Media
                {
                    Id = 4,
                    url = "https://easyladys.com/f/7f0757e7c299623abf9089fb4d7697a5.jpg",
                    AnimalId = 4,
                },
                new Media
                {
                    Id = 5,
                    url = "https://trofeocaza.com/wp-content/uploads/2016/05/Labrador-mayor-2.jpg",
                    AnimalId = 5,
                },
                new Media
                {
                    Id = 6,
                    url = "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjPm9icVOxLUGQZ7Rrae8HQR7pL0-7x0RhZr4Iy4Dtgb1DZANkMVqQkjpV-SHZ7Juio1-MELiq5h6TgUusG2QyjyaLTpwRwC3IZGfRF8nvyCcHPqIl6OZYmPNMVY1z9SXeRfCAWV5r9qtsO/s1600/10426282_807773819303512_1190001946492475051_n.jpg",
                    AnimalId = 6,
                },
                new Media
                {
                    Id = 7,
                    url = "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjPm9icVOxLUGQZ7Rrae8HQR7pL0-7x0RhZr4Iy4Dtgb1DZANkMVqQkjpV-SHZ7Juio1-MELiq5h6TgUusG2QyjyaLTpwRwC3IZGfRF8nvyCcHPqIl6OZYmPNMVY1z9SXeRfCAWV5r9qtsO/s1600/10426282_807773819303512_1190001946492475051_n.jpg",
                    AnimalId = 7,
                },
                new Media
                {
                    Id = 8,
                    url = "https://ninos.kiddle.co/images/5/56/Black_French_Bull_Dog.png",
                    AnimalId = 8,
                },
                new Media
                {
                    Id = 9,
                    url = "https://scontent.feze8-1.fna.fbcdn.net/v/t1.6435-9/48087963_2105103709551142_3668719407355396096_n.jpg?stp=dst-jpg_s600x600&_nc_cat=111&ccb=1-7&_nc_sid=5f2048&_nc_ohc=jmjYRCLoOisQ7kNvgGqjcBw&_nc_ht=scontent.feze8-1.fna&oh=00_AYDAFytU_FRHEXZvN2CIJySg0K6qwiCokTIcIoLYrP1K0g&oe=6692F80D",
                    AnimalId = 9,
                },
                new Media
                {
                    Id = 10,
                    url = "https://www.tuperromiperro.com/wp-content/uploads/2022/09/Perro-Beagle.jpg",
                    AnimalId = 10,
                },
                new Media
                {
                    Id = 11,
                    url = "https://scontent.feze8-1.fna.fbcdn.net/v/t1.6435-9/174801457_5588061661211518_8542369355131170408_n.jpg?_nc_cat=110&ccb=1-7&_nc_sid=5f2048&_nc_ohc=YnlvHl_cxrIQ7kNvgFsnN1L&_nc_ht=scontent.feze8-1.fna&oh=00_AYAYOjZ9qEe3inYjgPIXppacuO_K-9oR1DFg7X73IT0RsQ&oe=6692D40D",
                    AnimalId = 11,
                },
                new Media
                {
                    Id = 12,
                    url = "https://www.montecaserosonline.com/galeria/caniche_toy_jazm%C3%ADn.jpg",
                    AnimalId = 12,
                },
                new Media
                {
                    Id = 13,
                    url = "https://scontent.feze8-2.fna.fbcdn.net/v/t1.6435-9/134137059_1089190208161564_1338613731253060802_n.jpg?stp=dst-jpg_p526x296&_nc_cat=101&ccb=1-7&_nc_sid=5f2048&_nc_ohc=VehxKDLYl24Q7kNvgFFk-53&_nc_ht=scontent.feze8-2.fna&oh=00_AYAF2eUmtc5Cp3rXI67zrO_F6eKcSsInPBLv70qFgGhmdw&oe=6692CF93",
                    AnimalId = 13,
                },
                new Media
                {
                    Id = 14,
                    url = "https://pbs.twimg.com/media/ELMjoz5WkAABJLx?format=jpg&name=large",
                    AnimalId = 14,
                },
                new Media
                {
                    Id = 15,
                    url = "https://blog.dogbuddy.com/wp-content/uploads/2015/10/golden-retriever.png",
                    AnimalId = 15,
                },
                new Media
                {
                    Id = 16,
                    url = "https://eldiariodeliamrg.wordpress.com/wp-content/uploads/2013/11/imag1350.jpg",
                    AnimalId = 16,
                },
                new Media
                {
                    Id = 17,
                    url = "https://st4.depositphotos.com/25936512/38340/i/450/depositphotos_383405312-stock-photo-dog-car-funny-chihuahua-tiny.jpg",
                    AnimalId = 17,
                },
                new Media
                {
                    Id = 18,
                    url = "https://i.pinimg.com/564x/aa/0d/2d/aa0d2d89bc94573e7022caeac64301d2.jpg",
                    AnimalId = 18,
                },
                new Media
                {
                    Id = 19,
                    url = "https://www.101razasdeperros.com/images/raza-boxer-p.jpg",
                    AnimalId = 19,
                },
                new Media
                {
                    Id = 20,
                    url = "https://www.101razasdeperros.com/images/imagenes-perros-boxer-p.jpg",
                    AnimalId = 20,
                },
                new Media
                {
                    Id = 21,
                    url = "https://gatos.plus/wp-content/uploads/2021/11/gatos-mestizos-800x450.jpg",
                    AnimalId = 21,
                },
                new Media
                {
                    Id = 22,
                    url = "https://scontent.feze8-1.fna.fbcdn.net/v/t1.6435-9/119518205_10159199208425639_1796140183011601986_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=5f2048&_nc_ohc=LRb2jTOvBl4Q7kNvgFAms6G&_nc_ht=scontent.feze8-1.fna&oh=00_AYArE8GmNJn_NB0MtJXTC2DeyavFSSC5rcAyAqw4PuZLjw&oe=6692E698",
                    AnimalId = 22,
                },
                new Media
                {
                    Id = 23,
                    url = "https://scontent.feze8-2.fna.fbcdn.net/v/t1.18169-9/30704753_1792654484125840_3212093920598404223_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=5f2048&_nc_ohc=30pzPupOdw8Q7kNvgEByEKT&_nc_ht=scontent.feze8-2.fna&oh=00_AYDsaORC1ckXc5gMJLNALhPxMMgwuKd48H7mSfc4rTKs8w&oe=6693005A",
                    AnimalId = 23,
                },
                new Media
                {
                    Id = 24,
                    url = "https://static.theclinic.cl/media/2023/04/02-211346_5man_gatos-naranjas-foto-principal-880x500.jpg",
                    AnimalId = 24,
                },
                new Media
                {
                    Id = 25,
                    url = "https://i.imgur.com/Nc6U4LF.jpeg",
                    AnimalId = 25,
                },
                new Media
                {
                    Id = 26,
                    url = "https://c.pxhere.com/images/fa/bb/06a0b6b803cb94cc543a29e96301-1630931.jpg!d",
                    AnimalId = 26,
                },
                new Media
                {
                    Id = 27,
                    url = "https://i.pinimg.com/564x/04/eb/87/04eb87c409b33f7ded40583ca984f196.jpg",
                    AnimalId = 27,
                },
                new Media
                {
                    Id = 28,
                    url = "https://previews.123rf.com/images/saianoo/saianoo2206/saianoo220600234/187545230-juguet%C3%B3n-gato-de-pelo-largo-chinchilla-persa-color-gris-mascota-casera-gato-travieso.jpg",
                    AnimalId = 28,
                },
                new Media
                {
                    Id = 29,
                    url = "https://cdn.wamiz.fr/article/images/wysiwyg/2018/12/maine-coon-maullido.jpg",
                    AnimalId = 29,
                },
                new Media
                {
                    Id = 30,
                    url = "https://cdn.wamiz.fr/article/images/wysiwyg/2018/12/maine-coon-viento.jpg",
                    AnimalId = 30,
                },
                new Media
                {
                    Id = 31,
                    url = "https://images.ctfassets.net/denf86kkcx7r/1k77P07O7ZcULWVVj4Q9vM/5a6e81c983c037660911e2faf13235e0/ragdoll_seguro_gato_santevet-0?fm=webp&w=913",
                    AnimalId = 31,
                },
                new Media
                {
                    Id = 32,
                    url = "https://cdn.shopify.com/s/files/1/0268/6861/files/cat-2201013_960_720_grande.jpg?v=1530888986",
                    AnimalId = 32,
                },
                new Media
                {
                    Id = 33,
                    url = "https://protectorabcn.es/wp-content/uploads/2021/05/Michi-5-600x600.jpg",
                    AnimalId = 33,
                },
                new Media
                {
                    Id = 34,
                    url = "https://gatoanimal.com/wp-content/uploads/2020/04/gato-bengali-1024x768.jpg",
                    AnimalId = 34,
                },
                new Media
                {
                    Id = 35,
                    url = "https://i.pinimg.com/564x/96/e5/bd/96e5bd432f867f9818b4e467e3ce1a9f.jpg",
                    AnimalId = 35,
                },
                new Media
                {
                    Id = 36,
                    url = "https://t2.ea.ltmcdn.com/es/posts/8/4/8/cuidados_de_un_gato_sphynx_21848_600.webp",
                    AnimalId = 36,
                },
                new Media
                {
                    Id = 37,
                    url = "https://www.zooplus.es/magazine/wp-content/uploads/2017/10/Gato-azul-ruso.jpg",
                    AnimalId = 37,
                },
                new Media
                {
                    Id = 38,
                    url = "https://i.pinimg.com/564x/c8/d4/5d/c8d45d6f816341957b0265d154759988.jpg",
                    AnimalId = 38,
                },
                new Media
                {
                    Id = 39,
                    url = "https://previews.123rf.com/images/irrmago/irrmago1806/irrmago180600194/103504744-gato-scottish-fold-mojado-durante-el-ba%C3%B1o-gracioso-gato-crema-triste-con-orejas-dobladas-se-sienta.jpg",
                    AnimalId = 39,
                },
                new Media
                {
                    Id = 40,
                    url = "https://scontent.feze8-1.fna.fbcdn.net/v/t1.18169-9/11665701_1173980795961480_3603978141588056168_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=5f2048&_nc_ohc=rdBxOm4wflIQ7kNvgHPmu2n&_nc_ht=scontent.feze8-1.fna&oh=00_AYC8eP4fr-EpC8ylnHqkSMfzo5TPBhmbRU6wqXSK9GuWcg&oe=669304F8",
                    AnimalId = 40,
                }
            );

        }
    } 
}
