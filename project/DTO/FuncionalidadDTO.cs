using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FuncionalidadDTO
    {
        public String Nombre { get; set; }

        public FuncionalidadDTO()
        {

        }

        public FuncionalidadDTO(String nombre)
        {
            this.Nombre = nombre;
        }

    }
}
