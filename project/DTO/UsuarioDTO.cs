using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsuarioDTO
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public UsuarioDTO() { }

        public UsuarioDTO(String username , String password) {
            this.Username = username;
            this.Password = password;
        }

    }
}
