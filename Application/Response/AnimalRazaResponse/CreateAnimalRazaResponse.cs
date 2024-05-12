using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class CreateAnimalRazaResponse
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public GetAnimalTipoResponse Tipo { get; set; }
    }
}
