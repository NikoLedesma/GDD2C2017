using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoginFormDTO
    {

        public UsuarioDTO usuarioDTO { get; set; }
        public ResultCheckLogin resultCheckLogin;

        public LoginFormDTO(){
        
        }
        public LoginFormDTO(UsuarioDTO usuarioDTO, ResultCheckLogin resultCheckLogin)
        {
            this.usuarioDTO = usuarioDTO;
            this.resultCheckLogin = resultCheckLogin;
        }

        public Boolean isLoginSuccessful()
        {
            return resultCheckLogin == ResultCheckLogin.LOGIN_SUCCESSFUL;
        }

        public Boolean isIncorrectPassword()
        {
            return resultCheckLogin == ResultCheckLogin.INCORRECT_PASSWORD;
        }

        public Boolean isExcededAttempsLimit()
        {
            return resultCheckLogin == ResultCheckLogin.ATTEMPS_EXCEDED;
        }

        public Boolean notExistUsuario()
        {
            return resultCheckLogin == ResultCheckLogin.NOT_EXIST_USUARIO;
        }










    }
}
