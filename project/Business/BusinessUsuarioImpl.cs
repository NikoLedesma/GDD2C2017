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
    public class BusinessUsuarioImpl
    {
       public Boolean checkLogin(UsuarioDTO usuarioDTO) {
           UsuarioDAO usuarioDAO = new UsuarioDAO();
           Usuario usuario= usuarioDAO.GetByLogin(usuarioDTO.Username,usuarioDTO.Password); 
           return usuario!=null? true:false;
        }
    }
}
