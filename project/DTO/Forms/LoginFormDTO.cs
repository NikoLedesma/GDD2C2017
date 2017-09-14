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

    }
}
