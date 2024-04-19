using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Animal
    {
        public Guid Id { get; set; }
        public int AnimalTipoId { get; set; }
        public Guid UsuarioId { get; set; }
        public int GaleriaId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad {  get; set; }
        public decimal Peso { get; set; }
        public string Historia {  get; set; }
        public bool Adoptado { get; set; }

        public AnimalGaleria Galeria { get; set; }
        public AnimalTipo Tipo { get; set; }

    }
}
