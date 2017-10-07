using DAO.DAOImp;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DTO.Enums;

namespace Business
{
    public class BusinessLoginImpl
    {


        public DTO.Enums.ResultCheckLogin convertCheckLogin(int checkLogin)
        {
         return (DTO.Enums.ResultCheckLogin) checkLogin;
        }


       public LoginFormDTO checkLogin(UsuarioDTO usuarioDTO) {
           UsuarioDAO usuarioDAO = new UsuarioDAO();
           Usuario usuario = null;
           int checkLogin = usuarioDAO.execLogin(usuarioDTO.Username, usuarioDTO.Password);
           usuario = usuarioDAO.GetByLogin(usuarioDTO.Username, usuarioDTO.Password);
           LoginFormDTO loginFormDTO = new LoginFormDTO(usuarioDTO, convertCheckLogin(checkLogin));
           return loginFormDTO;
        }


       public Boolean userHaveOnlyOneRol(UsuarioDTO usuarioDTO) {
           //TODO : CLEAR
           /*RolDAO rolDAO= new RolDAO() ;
           List<Rol> listRol =rolDAO.getAllByUsername(usuarioDTO.Username).ToList();
           List<RolDTO> listRolDTO = new List<RolDTO>();
           listRol.ForEach(x => {if(x.Habilitado){listRolDTO.Add(new RolDTO(x.Nombre,x.Habilitado ));}});
           */
           BusinessRolImpl bussinesRolImpl = new BusinessRolImpl();
           List<RolDTO> listRolDTO = bussinesRolImpl.getEnabledRolesByUsuario(usuarioDTO);
           return listRolDTO.Count == 1;
       }


    }
}
