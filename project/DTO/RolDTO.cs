using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RolDTO
    {
        private String nombre;
        private Boolean habilitado;
        public String Nombre { get; set; }
        public Boolean Habilitado { get; set; }

        public RolDTO(){
        
        }
        public RolDTO(String nombre, Boolean habilitado){
            this.nombre = nombre;
            this.habilitado = habilitado;
        }

    }
    
}
