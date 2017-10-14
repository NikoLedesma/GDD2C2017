using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sucursal
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }  
        public String codPostal { get; set; }
        public Boolean habilitado { get; set; }
    }

}
