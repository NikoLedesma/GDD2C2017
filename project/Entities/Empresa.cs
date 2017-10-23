using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Empresa
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public int rubro { get; set; }
        public Boolean habilitado { get; set; }
        public String cuit { get; set; }
    }
}
