using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AnimalRaza
    {
        public int Id {  get; set; }
        public string Descripcion { get; set; }    

        public IList<AnimalTipo> Tipos { get; set; }
    }
}
