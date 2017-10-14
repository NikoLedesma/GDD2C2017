using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FacturaDTO
    {
        public int id { get; set; }
        public String cliente { get; set; }
        public String empresa { get; set; }
        public int nroFact { get; set; }
        public DateTime fechaDeAlta { get; set; }
        public DateTime fechaDeVencimiento { get; set; }
        public float total { get; set; }

        //AGREGAR LOS ITEMS - MONTO - CANTIDAD

        public Boolean habilitado { get; set; }

    }

}
