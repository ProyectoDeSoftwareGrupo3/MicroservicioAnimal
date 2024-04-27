using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class GetAnimalResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public decimal Peso { get; set; }
        public string Historia { get; set; }
        public bool Adoptado { get; set; }

        public CreateAnimalTipoResponse TipoAnimal { get; set; }
        public CreateAnimalGaleriaResponse Galeria { get; set; }
    }
}
