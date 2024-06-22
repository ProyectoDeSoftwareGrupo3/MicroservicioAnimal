using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalRepository.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AnimalRaza",
                columns: new[] { "Id", "Descripcion", "TipoId" },
                values: new object[,]
                {
                    { 1, "Mestizo", 1 },
                    { 2, "Otro", 1 },
                    { 3, "Labrador Retriever", 1 },
                    { 4, "Bulldog", 1 },
                    { 5, "Beagle", 1 },
                    { 6, "Caniche", 1 },
                    { 7, "Pastor Aleman", 1 },
                    { 8, "Golden Retriever", 1 },
                    { 9, "Chihuahua", 1 },
                    { 10, "Boxer", 1 },
                    { 11, "Mestizo", 2 },
                    { 12, "Otro", 2 },
                    { 13, "Siamese", 2 },
                    { 14, "Persa", 2 },
                    { 15, "Maine Coon", 2 },
                    { 16, "Ragdoll", 2 },
                    { 17, "Bengal", 2 },
                    { 18, "Sphynx", 2 },
                    { 19, "Russian Blue", 2 },
                    { 20, "Scottish Fold", 2 }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "AnimalRazaId", "Edad", "Genero", "Historia", "Nombre", "Peso", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, 5, true, "Max es un perrito muy amigable que adora jugar a buscar la pelota. Le encanta estar rodeado de personas y siempre está dispuesto a hacer nuevos amigos. Es un perro leal y muy cariñoso.", "Max", 30.5m, "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { 2, 1, 4, false, "Bella es una perra juguetona que disfruta de largos paseos y caricias en la barriga. Es muy sociable y le encanta interactuar con otros perros y personas. Bella es perfecta para una familia activa.", "Bella", 28.3m, "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { 3, 2, 6, true, "Charlie es un perro leal que adora estar cerca de su familia. A pesar de su aspecto robusto, es muy cariñoso y disfruta de los momentos de tranquilidad. Es un excelente compañero para cualquier hogar.", "Charlie", 24.1m, "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { 4, 2, 3, false, "Lucy es una perrita muy tranquila que se lleva bien con los niños. Le encanta pasar el tiempo en casa y recibir mimos. Es una perrita muy leal y cariñosa, perfecta para cualquier familia.", "Lucy", 21.7m, "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { 5, 3, 6, true, "Buddy es un Labrador Retriever lleno de energía y entusiasmo. Le encanta jugar y hacer ejercicio al aire libre. Es muy inteligente y siempre está dispuesto a aprender nuevos trucos.", "Buddy", 30.5m, "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { 6, 3, 4, false, "Daisy es una perrita muy cariñosa que disfruta de largas caminatas y caricias. Es perfecta para una familia que le guste el aire libre y pasar tiempo juntos. Daisy es muy leal y protectora.", "Daisy", 28.3m, "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { 7, 4, 5, true, "Rocky es un Bulldog robusto y amigable. Le gusta mucho jugar con otros perros y es muy sociable. Es un perro tranquilo que disfruta de los momentos de relajación junto a su familia.", "Rocky", 24.1m, "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { 8, 4, 3, false, "Molly es una Bulldog muy tranquila y se lleva bien con niños. Es perfecta para un hogar con niños, ya que es muy paciente y cariñosa. Molly disfruta de las siestas y de la compañía de su familia.", "Molly", 21.7m, "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { 9, 5, 4, true, "Jack es un Beagle curioso y lleno de vida. Siempre está buscando aventuras y le encanta explorar su entorno. Es muy inteligente y disfruta de los juegos de olfateo y búsqueda.", "Jack", 15.5m, "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { 10, 5, 2, false, "Luna es muy juguetona y le encanta olfatear todo a su alrededor. Es ideal para paseos largos y actividades al aire libre. Luna es muy cariñosa y siempre está dispuesta a jugar.", "Luna", 13.8m, "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { 11, 6, 5, true, "Cooper es un Caniche inteligente y muy entrenado. Es perfecto para un hogar que le dedique tiempo y atención. Cooper disfruta de los juegos de inteligencia y siempre está listo para aprender.", "Cooper", 10.2m, "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { 12, 6, 3, false, "Sophie es muy cariñosa y le encanta acurrucarse. Es ideal para un hogar tranquilo y amoroso. Sophie disfruta de las caricias y siempre está buscando la compañía de su familia.", "Sophie", 9.7m, "3D0F1848-5354-4CED-A125-525218044370" },
                    { 13, 7, 6, true, "Bear es un Pastor Alemán muy protector. Es excelente para seguridad y compañía. Bear es muy leal y siempre está dispuesto a cuidar de su familia. Disfruta de los juegos y el ejercicio.", "Bear", 35.4m, "3D0F1848-5354-4CED-A125-525218044370" },
                    { 14, 7, 4, false, "Zoe es muy leal y amigable. Le encanta estar activa y siempre está lista para jugar. Es una compañera perfecta para actividades al aire libre y disfruta de la compañía de su familia.", "Zoe", 32.8m, "3D0F1848-5354-4CED-A125-525218044370" },
                    { 15, 8, 5, true, "Toby es un Golden Retriever muy cariñoso y sociable. Es perfecto para cualquier familia que busque un perro leal y amigable. Toby disfruta de los juegos y de las largas caminatas.", "Toby", 29.3m, "3D0F1848-5354-4CED-A125-525218044370" },
                    { 16, 8, 3, false, "Chloe es muy dulce y se lleva bien con todos. Es ideal para un hogar con otros animales. Chloe es muy cariñosa y siempre está buscando la atención y el cariño de su familia.", "Chloe", 27.5m, "3D0F1848-5354-4CED-A125-525218044370" },
                    { 17, 9, 4, true, "Oscar es un Chihuahua muy valiente y enérgico. Le encanta estar cerca de su dueño y es muy protector. Es ideal para una persona que busque un compañero pequeño pero lleno de carácter.", "Oscar", 6.5m, "3D0F1848-5354-4CED-A125-525218044370" },
                    { 18, 9, 2, false, "Lola es muy juguetona y le encanta ser el centro de atención. Es perfecta para un hogar que le guste la compañía de un perro pequeño y enérgico. Lola es muy cariñosa y siempre está lista para jugar.", "Lola", 5.8m, "3D0F1848-5354-4CED-A125-525218044370" },
                    { 19, 10, 5, true, "Duke es un Boxer muy activo y lleno de energía. Le encanta correr y jugar al aire libre. Es muy leal y protector, ideal para una familia que disfrute de las actividades físicas.", "Duke", 28.2m, "3D0F1848-5354-4CED-A125-525218044370" },
                    { 20, 10, 3, false, "Ruby es una perrita muy juguetona y llena de vida. Disfruta de los juegos y de pasar tiempo con su familia. Es muy cariñosa y siempre está lista para una nueva aventura.", "Ruby", 26.4m, "3D0F1848-5354-4CED-A125-525218044370" },
                    { 21, 11, 4, true, "Rex es un gato muy amigable y leal. Le encanta estar cerca de las personas y siempre está dispuesto a jugar. Es un gatito muy adaptable y se lleva bien con otros animales.", "Rex", 25.0m, "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0" },
                    { 22, 11, 3, false, "Lily es una gatita Mestiza muy dulce y cariñosa. Es perfecta para una familia que busque un compañero leal y lleno de amor. Lily disfruta de los juegos y de la compañía de su familia.", "Lily", 23.5m, "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0" },
                    { 23, 12, 4, true, "Sam es un michi muy curioso y juguetón. Le encanta explorar su entorno y hacer nuevos amigos. Es muy inteligente y siempre está dispuesto a aprender nuevas cosas.... y hacer desastres", "Sam", 20.5m, "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0" },
                    { 24, 12, 2, false, "Michifuzz es una gatita muy dulce y cariñosa. Disfruta de los juegos y de pasar tiempo con su familia. Es perfecta para un hogar amoroso y paciente.", "Michifuzz", 18.9m, "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0" },
                    { 25, 13, 3, true, "Simba es un gato Siamese muy curioso y lleno de energía. Le encanta explorar y jugar con juguetes interactivos. Es muy cariñoso y disfruta de la compañía de su familia.", "Simba", 4.5m, "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0" },
                    { 26, 13, 2, false, "Nala es una gatita Siamese muy juguetona y cariñosa. Disfruta de los juegos y de acurrucarse con su familia. Es perfecta para un hogar que le guste la compañía de un gato activo.", "Nala", 4.2m, "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0" },
                    { 27, 14, 4, true, "Leo es un gato Persa muy tranquilo y cariñoso. Le encanta pasar tiempo en casa y recibir mimos. Es ideal para un hogar que busque un compañero tranquilo y amoroso.", "Leo", 5.0m, "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0" },
                    { 28, 14, 3, false, "Mia es una gatita Persa muy dulce y cariñosa. Disfruta de la tranquilidad del hogar y de la compañía de su familia. Es perfecta para un hogar que le guste la compañía de un gato cariñoso.", "Mia", 4.7m, "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0" },
                    { 29, 15, 5, true, "Oscar es un gato Maine Coon muy juguetón y curioso. Le encanta explorar su entorno y jugar con otros gatos. Es muy cariñoso y disfruta de la compañía de su familia.", "Oscar", 6.8m, "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0" },
                    { 30, 15, 3, false, "Maggie es una gatita Maine Coon muy juguetona y le encanta estar en compañía de otros gatos. Disfruta de los juegos y de acurrucarse con su familia.", "Maggie", 6.5m, "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0" },
                    { 31, 16, 4, true, "Zeus es un gato Ragdoll muy cariñoso. Le encanta ser el centro de atención y recibir mimos. Es muy tranquilo y disfruta de la compañía de su familia.", "Zeus", 5.9m, "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA" },
                    { 32, 16, 2, false, "Daisy es una gatita Ragdoll muy dulce que busca un hogar donde pueda recibir mucho cariño. Es muy tranquila y le encanta estar cerca de su familia.", "Daisy", 5.7m, "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA" },
                    { 33, 17, 5, true, "Thor es un gato Bengala muy activo y juguetón. Le encanta explorar y jugar con juguetes interactivos. Es muy inteligente y disfruta de la compañía de su familia.", "Thor", 6.2m, "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA" },
                    { 34, 17, 3, false, "Luna es una gatita Bengala muy curiosa y llena de energía. Le encanta explorar y jugar con otros gatos. Es muy cariñosa y disfruta de la compañía de su familia.", "Luna", 5.9m, "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA" },
                    { 35, 18, 4, true, "Coco es un gato Sphynx muy curioso y juguetón. Le encanta estar en compañía de otros gatos y explorar su entorno. Es muy cariñoso y disfruta de la atención de su familia.", "Coco", 6.0m, "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA" },
                    { 36, 18, 3, true, "Milo es un gato Sphynx muy tranquilo y amoroso. Disfruta de los momentos de calma en casa y de recibir mimos. Es perfecto para un hogar que busque un gato cariñoso y tranquilo.", "Milo", 5.5m, "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA" },
                    { 37, 19, 4, false, "Misha es una gatita Russian Blue muy afectuosa y leal. Disfruta de los momentos tranquilos en casa y de la compañía de su familia. Es muy cariñosa y siempre está lista para recibir mimos.", "Misha", 5.8m, "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA" },
                    { 38, 19, 3, true, "Oliver es un gato Russian Blue muy juguetón y lleno de energía. Le encanta jugar con juguetes y explorar su entorno. Es muy cariñoso y disfruta de la compañía de su familia.", "Oliver", 5.4m, "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA" },
                    { 39, 20, 4, true, "Milo es un gato Scottish Fold muy tranquilo y cariñoso. Disfruta de los momentos de calma en casa y de recibir mimos. Es perfecto para un hogar que busque un compañero tranquilo y amoroso.", "Milo", 6.2m, "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA" },
                    { 40, 20, 3, false, "Luna es una gatita Scottish Fold muy juguetona y llena de vida. Disfruta de los juegos y de pasar tiempo con su familia. Es perfecta para un hogar amoroso y paciente.", "Luna", 5.9m, "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA" }
                });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "AnimalId", "url" },
                values: new object[,]
                {
                    { 1, 1, "https://live-mascotas-sanas-duenos-felices-blogs.cphostaccess.com/posts/easset_upload_file32027_708883_e.jpg" },
                    { 2, 2, "https://www.lt9.com.ar/uploads/s_fed89b6e647b9af00dcadfe.jpg" },
                    { 3, 3, "https://i0.wp.com/mascotass.com/wp-content/uploads/2011/12/Los-perros-mestizos.jpg" },
                    { 4, 4, "https://easyladys.com/f/7f0757e7c299623abf9089fb4d7697a5.jpg" },
                    { 5, 5, "https://trofeocaza.com/wp-content/uploads/2016/05/Labrador-mayor-2.jpg" },
                    { 6, 6, "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjPm9icVOxLUGQZ7Rrae8HQR7pL0-7x0RhZr4Iy4Dtgb1DZANkMVqQkjpV-SHZ7Juio1-MELiq5h6TgUusG2QyjyaLTpwRwC3IZGfRF8nvyCcHPqIl6OZYmPNMVY1z9SXeRfCAWV5r9qtsO/s1600/10426282_807773819303512_1190001946492475051_n.jpg" },
                    { 7, 7, "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjPm9icVOxLUGQZ7Rrae8HQR7pL0-7x0RhZr4Iy4Dtgb1DZANkMVqQkjpV-SHZ7Juio1-MELiq5h6TgUusG2QyjyaLTpwRwC3IZGfRF8nvyCcHPqIl6OZYmPNMVY1z9SXeRfCAWV5r9qtsO/s1600/10426282_807773819303512_1190001946492475051_n.jpg" },
                    { 8, 8, "https://ninos.kiddle.co/images/5/56/Black_French_Bull_Dog.png" },
                    { 9, 9, "https://scontent.feze8-1.fna.fbcdn.net/v/t1.6435-9/48087963_2105103709551142_3668719407355396096_n.jpg?stp=dst-jpg_s600x600&_nc_cat=111&ccb=1-7&_nc_sid=5f2048&_nc_ohc=jmjYRCLoOisQ7kNvgGqjcBw&_nc_ht=scontent.feze8-1.fna&oh=00_AYDAFytU_FRHEXZvN2CIJySg0K6qwiCokTIcIoLYrP1K0g&oe=6692F80D" },
                    { 10, 10, "https://www.tuperromiperro.com/wp-content/uploads/2022/09/Perro-Beagle.jpg" },
                    { 11, 11, "https://scontent.feze8-1.fna.fbcdn.net/v/t1.6435-9/174801457_5588061661211518_8542369355131170408_n.jpg?_nc_cat=110&ccb=1-7&_nc_sid=5f2048&_nc_ohc=YnlvHl_cxrIQ7kNvgFsnN1L&_nc_ht=scontent.feze8-1.fna&oh=00_AYAYOjZ9qEe3inYjgPIXppacuO_K-9oR1DFg7X73IT0RsQ&oe=6692D40D" },
                    { 12, 12, "https://www.montecaserosonline.com/galeria/caniche_toy_jazm%C3%ADn.jpg" },
                    { 13, 13, "https://scontent.feze8-2.fna.fbcdn.net/v/t1.6435-9/134137059_1089190208161564_1338613731253060802_n.jpg?stp=dst-jpg_p526x296&_nc_cat=101&ccb=1-7&_nc_sid=5f2048&_nc_ohc=VehxKDLYl24Q7kNvgFFk-53&_nc_ht=scontent.feze8-2.fna&oh=00_AYAF2eUmtc5Cp3rXI67zrO_F6eKcSsInPBLv70qFgGhmdw&oe=6692CF93" },
                    { 14, 14, "https://pbs.twimg.com/media/ELMjoz5WkAABJLx?format=jpg&name=large" },
                    { 15, 15, "https://blog.dogbuddy.com/wp-content/uploads/2015/10/golden-retriever.png" },
                    { 16, 16, "https://eldiariodeliamrg.wordpress.com/wp-content/uploads/2013/11/imag1350.jpg" },
                    { 17, 17, "https://st4.depositphotos.com/25936512/38340/i/450/depositphotos_383405312-stock-photo-dog-car-funny-chihuahua-tiny.jpg" },
                    { 18, 18, "https://i.pinimg.com/564x/aa/0d/2d/aa0d2d89bc94573e7022caeac64301d2.jpg" },
                    { 19, 19, "https://www.101razasdeperros.com/images/raza-boxer-p.jpg" },
                    { 20, 20, "https://www.101razasdeperros.com/images/imagenes-perros-boxer-p.jpg" },
                    { 21, 21, "https://gatos.plus/wp-content/uploads/2021/11/gatos-mestizos-800x450.jpg" },
                    { 22, 22, "https://scontent.feze8-1.fna.fbcdn.net/v/t1.6435-9/119518205_10159199208425639_1796140183011601986_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=5f2048&_nc_ohc=LRb2jTOvBl4Q7kNvgFAms6G&_nc_ht=scontent.feze8-1.fna&oh=00_AYArE8GmNJn_NB0MtJXTC2DeyavFSSC5rcAyAqw4PuZLjw&oe=6692E698" },
                    { 23, 23, "https://scontent.feze8-2.fna.fbcdn.net/v/t1.18169-9/30704753_1792654484125840_3212093920598404223_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=5f2048&_nc_ohc=30pzPupOdw8Q7kNvgEByEKT&_nc_ht=scontent.feze8-2.fna&oh=00_AYDsaORC1ckXc5gMJLNALhPxMMgwuKd48H7mSfc4rTKs8w&oe=6693005A" },
                    { 24, 24, "https://static.theclinic.cl/media/2023/04/02-211346_5man_gatos-naranjas-foto-principal-880x500.jpg" },
                    { 25, 25, "https://i.imgur.com/Nc6U4LF.jpeg" },
                    { 26, 26, "https://c.pxhere.com/images/fa/bb/06a0b6b803cb94cc543a29e96301-1630931.jpg!d" },
                    { 27, 27, "https://i.pinimg.com/564x/04/eb/87/04eb87c409b33f7ded40583ca984f196.jpg" },
                    { 28, 28, "https://previews.123rf.com/images/saianoo/saianoo2206/saianoo220600234/187545230-juguet%C3%B3n-gato-de-pelo-largo-chinchilla-persa-color-gris-mascota-casera-gato-travieso.jpg" },
                    { 29, 29, "https://cdn.wamiz.fr/article/images/wysiwyg/2018/12/maine-coon-maullido.jpg" },
                    { 30, 30, "https://cdn.wamiz.fr/article/images/wysiwyg/2018/12/maine-coon-viento.jpg" },
                    { 31, 31, "https://images.ctfassets.net/denf86kkcx7r/1k77P07O7ZcULWVVj4Q9vM/5a6e81c983c037660911e2faf13235e0/ragdoll_seguro_gato_santevet-0?fm=webp&w=913" },
                    { 32, 32, "https://cdn.shopify.com/s/files/1/0268/6861/files/cat-2201013_960_720_grande.jpg?v=1530888986" },
                    { 33, 33, "https://protectorabcn.es/wp-content/uploads/2021/05/Michi-5-600x600.jpg" },
                    { 34, 34, "https://gatoanimal.com/wp-content/uploads/2020/04/gato-bengali-1024x768.jpg" },
                    { 35, 35, "https://i.pinimg.com/564x/96/e5/bd/96e5bd432f867f9818b4e467e3ce1a9f.jpg" },
                    { 36, 36, "https://t2.ea.ltmcdn.com/es/posts/8/4/8/cuidados_de_un_gato_sphynx_21848_600.webp" },
                    { 37, 37, "https://www.zooplus.es/magazine/wp-content/uploads/2017/10/Gato-azul-ruso.jpg" },
                    { 38, 38, "https://i.pinimg.com/564x/c8/d4/5d/c8d45d6f816341957b0265d154759988.jpg" },
                    { 39, 39, "https://previews.123rf.com/images/irrmago/irrmago1806/irrmago180600194/103504744-gato-scottish-fold-mojado-durante-el-ba%C3%B1o-gracioso-gato-crema-triste-con-orejas-dobladas-se-sienta.jpg" },
                    { 40, 40, "https://scontent.feze8-1.fna.fbcdn.net/v/t1.18169-9/11665701_1173980795961480_3603978141588056168_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=5f2048&_nc_ohc=rdBxOm4wflIQ7kNvgHPmu2n&_nc_ht=scontent.feze8-1.fna&oh=00_AYC8eP4fr-EpC8ylnHqkSMfzo5TPBhmbRU6wqXSK9GuWcg&oe=669304F8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
