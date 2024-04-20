using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AnimalTipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<AnimalRaza> Razas { get; set;}
        public List<Animal> Animales { get; set; }
    }
}
