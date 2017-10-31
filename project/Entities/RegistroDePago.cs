using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RegistroDePago
    {

        public int id { get; set; }
        public List<Factura> facturas { get; set; }
        public MedioDePago  medioDePago { get; set; }


        public float fecha { get; set; }

        public double importe { get; set; }

        public int numero { get; set; }
    }
}
