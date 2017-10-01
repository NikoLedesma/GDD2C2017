using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SelectedFuncRolDTO
    {
        public String NombreRol { get; set; }
        public String NombreFuncionalidad { get; set; }

        public static SelectedFuncRolDTO create( String nombreRol , String nombreFuncionalidad)
        {
            SelectedFuncRolDTO selectedFuncRolDTO = new SelectedFuncRolDTO();
            selectedFuncRolDTO.NombreRol = nombreRol;
            selectedFuncRolDTO.NombreFuncionalidad = nombreFuncionalidad;
            return selectedFuncRolDTO;
        } 


    }
}
