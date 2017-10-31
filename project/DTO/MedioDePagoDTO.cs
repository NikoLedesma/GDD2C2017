using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MedioDePagoDTO
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public float importe { get; set; }

        public MedioDePagoDTO()
        {
        }

        public MedioDePagoDTO(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

    }
}
