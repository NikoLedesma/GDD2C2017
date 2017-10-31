using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Enums
{

    public enum ResultCheckLogin
    {
        NOT_EXIST_USUARIO = 1,
        ATTEMPS_EXCEDED = 2,
        LOGIN_SUCCESSFUL = 3,
        INCORRECT_PASSWORD = 4
    };

    public enum ResultCheckFactura
    {
        NOT_EXIST_FACTURA = 1,
        EXIST_FACTURA_NO_PAGADA = 2,
        EXIST_FACTURA_PAGADA = 3
    };

    public interface IEnumsLogin
    {
        IEnumsLogin status { get; }
    }
}
