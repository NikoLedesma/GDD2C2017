using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.UTILS
{
     static public class GlobalUtils
    {
            public static UsuarioDTO usuarioGlobalDTO { get; set; }
            public static RolDTO rolGlobalDTO { get; set; }
            public static SucursalDTO sucursalGlobalDTO{ get; set; }

            public static String GetSHA256(String input) {
                SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashedBytes = provider.ComputeHash(inputBytes);
                StringBuilder output = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                    output.Append(hashedBytes[i].ToString("x2").ToLower());
                return output.ToString();
            }
    }
}
