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

    }
}
