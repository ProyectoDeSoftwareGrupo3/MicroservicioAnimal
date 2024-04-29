using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public int AnimalRazaId { get; set; }
        public string UsuarioId { get; set; }
        public string Nombre { get; set; }
        public bool Genero { get; set; }
        public int Edad {  get; set; }
        public decimal Peso { get; set; }
        public string Historia {  get; set; }
        public bool Adoptado { get; set; }

        public AnimalRaza Raza { get; set; }
        public List<Foto> Fotos { get; set; }

    }
}
