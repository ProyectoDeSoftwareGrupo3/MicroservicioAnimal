using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class DeleteAnimalResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Adoptado { get; set; }
        public CreateAnimalRazaResponse Raza { get; set; }
    }
}
