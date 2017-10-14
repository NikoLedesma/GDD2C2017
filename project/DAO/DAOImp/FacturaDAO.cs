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
    public class FacturaDAO : GenericDAO<Factura>
    {
        public int saveFactura(Factura factura)
        {
            using (var command = new SqlCommand("INSERT INTO NO_TENGO_IDEA.Factura " +
                                    "(fact_cliente,fact_empresa, fact_numero,fact_fecha_alta, fact_fecha_vencimiento, fact_total) " +
                                    "VALUES (@CLIENTE,@EMPRESA,@NRO_FACT,@FECHA_ALTA,@FECHA_VENCIMIENTO,@TOTAL)"))
            {
                command.Parameters.AddWithValue("@CLIENTE", factura.cliente);
                command.Parameters.AddWithValue("@EMPRESA", factura.empresa); //todo ver seleccion acotada
                command.Parameters.AddWithValue("@NRO_FACT", factura.nroFact);
                command.Parameters.AddWithValue("@FECHA_ALTA", factura.fechaDeAlta);
                command.Parameters.AddWithValue("@FECHA_VENCIMIENTO", factura.fechaDeVencimiento);
                command.Parameters.AddWithValue("@TOTAL", factura.total);
              //  command.Parameters.AddWithValue("@HABILITADO", factura.habilitado);
                
                return save(command);

            }
        }
        
    }

}
