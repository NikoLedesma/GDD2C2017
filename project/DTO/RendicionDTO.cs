using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO
{
    public class RendicionDTO
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public float importe { get; set; }
        public int numero { get; set; }
        public float porcentaje { get; set; }
        public int empresa { get; set; }
        public DataTable idFact { get; set; }
        
    }
}
