using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RegistroDePagoDTO
    {

        public int id { get; set; }
        public float importe { get; set; }
        public int numero { get; set; }

        public List<FacturaDTO> facturasDTO { get; set; }
        public MedioDePagoDTO  medioDePagoDTO { get; set; }


        public int sucursalId { get; set; }

        public DateTime fecha { get; set; }
    }
}
