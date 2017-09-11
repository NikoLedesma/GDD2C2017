using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DTO;
using DAO.DAOImp;
namespace Business
{
    public class BusinessRolImpl
    {
        public List<RolDTO> getRolesByUsuario(UsuarioDTO usuarioDTO){
            RolDAO rolDAO = new RolDAO();
            List<Rol> listRol = null;
            List<RolDTO> listRolDTO = new List <RolDTO>();
            listRol = rolDAO.getAllByUsername(usuarioDTO.Username).ToList();
            listRol.ForEach(x => { listRolDTO.Add(new RolDTO(x.Nombre, x.Habilitado)); });
            return listRolDTO;
        }

    }
}
