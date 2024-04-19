using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class CreateAnimalRazaRequest
    {
        public int TipoId {get;set;}
        public string Descripcion { get; set; }
    }
}
