using DAO.GenericDAO;
using Entities;
using System;
using System.Collections.Generic;
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
            using (var command = new SqlCommand("INSERT INTO LOS_PUBERTOS.Pago (PAGO_IMPORTE,PAGO_NUMERO,PAGO_MEDIODEPAGO)  " +
                        "VALUES (@IMPORTE,@NUMERO,@MEDIODEPAGO) "))
            {
             
                //command.Parameters.AddWithValue("@FECHA", registroDePago.fecha);
                command.Parameters.AddWithValue("@IMPORTE", registroDePago.importe);
                //command.Parameters.AddWithValue("@SUCURSAL", registroDePago.);
                command.Parameters.AddWithValue("@NUMERO", registroDePago.numero);
                command.Parameters.AddWithValue("@MEDIODEPAGO", registroDePago.medioDePago.id);
                return save(command);
            }

        }

        public int saveFacturaToPago(Factura factura,int nroPago)
        {
            using (var command = new SqlCommand("INSERT INTO LOS_PUBERTOS.PF (PF_PAGO,PF_FACTURA) " +
                    "SELECT (SELECT P.PAGO_ID FROM LOS_PUBERTOS.PAGO P WHERE P.PAGO_NUMERO = @NROPAGO) ,F.FACT_ID FROM LOS_PUBERTOS.FACTURA F WHERE F.FACT_NUMERO = @NROFACTURA "))
            {
                command.Parameters.AddWithValue("@NROPAGO", nroPago );
                command.Parameters.AddWithValue("@NROFACTURA", factura.nroFact);
                return save(command);
            }

        }


    }
}
