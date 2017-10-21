using DAO.GenericDAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAO.DAOImp
{
    public class FacturaDAO : GenericDAO<Factura>
    {
        public int saveFactura(Factura factura)
        {
            using (var command = new SqlCommand("[NO_TENGO_IDEA].crearFactura"))/*new SqlCommand("INSERT INTO NO_TENGO_IDEA.Factura " +
                                    "(fact_cliente,fact_empresa, fact_numero,fact_fecha_alta, fact_fecha_vencimiento, fact_total) " +
                                    "VALUES (@CLIENTE,@EMPRESA,@NRO_FACT,@FECHA_ALTA,@FECHA_VENCIMIENTO,@TOTAL)"))*/
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CLIENTE", factura.cliente);
                command.Parameters.AddWithValue("@EMPRESA", factura.empresa); //todo ver seleccion acotada
                command.Parameters.AddWithValue("@NUMERO", factura.nroFact);
                command.Parameters.AddWithValue("@FECHAALTA", factura.fechaDeAlta);
                command.Parameters.AddWithValue("@FECHAVENC", factura.fechaDeVencimiento);
                command.Parameters.AddWithValue("@TOTAL", factura.total);
                command.Parameters.AddWithValue("@ITEMS", factura.items);
                command.Parameters.AddWithValue("@RESULT", 0);

                
                return save(command);

            }
        }
        
    }

}
