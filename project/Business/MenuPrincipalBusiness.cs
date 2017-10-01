using DAO.DAOImp;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MenuPrincipalBusiness
    {
        private FuncionalidadDAO funcionalidadDAO;


        public List<FuncionalidadDTO> getFuncionalidadByRol(RolDTO rolDTO)
        {
            funcionalidadDAO = new FuncionalidadDAO();
            List <Funcionalidad> listFuncionalidad = funcionalidadDAO.getFuncionalidadByRolName(rolDTO.Nombre).ToList();
            List<FuncionalidadDTO> listFuncionalidadDTO = new List<FuncionalidadDTO>();
            listFuncionalidad.ForEach(x => { listFuncionalidadDTO.Add(new FuncionalidadDTO(x.Nombre)); });
            return listFuncionalidadDTO;
        }
    }
}
