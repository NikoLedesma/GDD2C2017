using DAO.GenericDAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAOImp
{
    
    public class RegistroDePagoDAO : GenericDAO<RegistroDePago>
    {
        //TODO crear pago, FALTA LA SUCURSAL
        public int savePago(RegistroDePago registroDePago)
        {
            using (var command = new SqlCommand("INSERT INTO LOS_PUBERTOS.Pago (PAGO_FECHA,PAGO_IMPORTE,PAGO_SUCURSAL,PAGO_NUMERO,PAGO_MEDIODEPAGO)  " +
                        "VALUES (@FECHA,@IMPORTE,@SUCURSAL,@NUMERO,@MEDIODEPAGO) "))
            {
                DateTime a = registroDePago.fecha;
                command.Parameters.AddWithValue("@FECHA", a);
                command.Parameters.AddWithValue("@IMPORTE", registroDePago.importe);
                command.Parameters.AddWithValue("@SUCURSAL", registroDePago.sucursalId);
                command.Parameters.AddWithValue("@NUMERO", registroDePago.numero);
                command.Parameters.AddWithValue("@MEDIODEPAGO", registroDePago.medioDePago.id);
                return save(command);
            }

        }
        public List<string> getAllTrimestres()
        {
            using (var command = new SqlCommand("SELECT CONCAT(DATEPART ( YEAR , pago_fecha ),CONCAT('-T:',DATEPART ( QUARTER , pago_fecha ))) FROM [LOS_PUBERTOS].[Pago] GROUP BY CONCAT(DATEPART ( YEAR , pago_fecha ),CONCAT('-T:',DATEPART ( QUARTER , pago_fecha )))"))
            {
                return GetArray(command);
            }
        }

        public int saveFacturaToPago(Factura factura,int nroPago)
        {
            using (var command = new SqlCommand("INSERT INTO LOS_PUBERTOS.PF (PF_PAGO,PF_FACTURA) " +
                    "SELECT (SELECT TOP 1 P.PAGO_ID FROM LOS_PUBERTOS.PAGO P WHERE P.PAGO_NUMERO = @NROPAGO ORDER BY P.PAGO_ID DESC) ,F.FACT_ID FROM LOS_PUBERTOS.FACTURA F WHERE F.FACT_NUMERO = @NROFACTURA "))
            {
                command.Parameters.AddWithValue("@NROPAGO", nroPago );
                command.Parameters.AddWithValue("@NROFACTURA", factura.nroFact);
                return save(command);
            }

        }


    }
}
