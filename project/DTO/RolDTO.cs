using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RolDTO
    {
        public String Nombre { get; set; }
        public Boolean Habilitado { get; set; }
        public List <FuncionalidadDTO> listFuncionalidadDTO { get; set; }

        public RolDTO(){
        
        }
        public RolDTO(String nombre, Boolean habilitado){
            this.Nombre = nombre;
            this.Habilitado = habilitado;
        }

        public RolDTO(String nombre, Boolean habilitado, List<FuncionalidadDTO> listFuncionalidadDTO)
        {
            this.Nombre = nombre;
            this.Habilitado = habilitado;
            this.listFuncionalidadDTO = listFuncionalidadDTO;
        }

    }
    
}
