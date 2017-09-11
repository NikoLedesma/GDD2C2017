using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public Boolean Habilitado { get; set; }
        public int CantIntentosFallidos { get; set; }
        public List<Rol> Roles { get; set; }
    }
}
