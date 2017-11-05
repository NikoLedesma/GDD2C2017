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
            using (var command = new SqlCommand("[LOS_PUBERTOS].crearFactura"))/*new SqlCommand("INSERT INTO LOS_PUBERTOS.Factura " +
                                    "(fact_cliente,fact_empresa, fact_numero,fact_fecha_alta, fact_fecha_vencimiento, fact_total) " +
                                    "VALUES (@CLIENTE,@EMPRESA,@NRO_FACT,@FECHA_ALTA,@FECHA_VENCIMIENTO,@TOTAL)"))*/
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", factura.id);
                command.Parameters.AddWithValue("@CLIENTE", factura.cliente);
                command.Parameters.AddWithValue("@EMPRESA", factura.empresa); //todo ver seleccion acotada
                command.Parameters.AddWithValue("@NUMERO", factura.nroFact);
                command.Parameters.AddWithValue("@FECHAALTA", factura.fechaDeAlta);
                command.Parameters.AddWithValue("@FECHAVENC", factura.fechaDeVencimiento);
                command.Parameters.AddWithValue("@TOTAL", factura.total);
                command.Parameters.AddWithValue("@ITEMS", factura.items);
                command.Parameters.AddWithValue("@HABILITADA", factura.habilitado);
                command.Parameters.AddWithValue("@RESULT", 0);

                
                return save(command);

            }
        }
        public IEnumerable<Factura> getAllByUsername(int cliente, int empresa)
        {
            String str = "";
            if (cliente > 0) { str += " AND fact_cliente = @CLIENTE "; }
            if (empresa > 0) { str += " AND fact_empresa = @EMPRESA "; }


            using (var command = new SqlCommand("SELECT [fact_id], [fact_cliente], [fact_empresa], [fact_numero], [fact_fecha_alta], [fact_fecha_vencimiento], [fact_total], [fact_inactiva] " +
                          "FROM  LOS_PUBERTOS.Factura  WHERE 1=1 " + str))
            {
                if (cliente > 0) { command.Parameters.AddWithValue("@CLIENTE", cliente); }
                if (empresa > 0) { command.Parameters.AddWithValue("@EMPRESA", empresa); }
                
                return GetRecords(command);
            }
            throw new NotImplementedException();
        }
        public IEnumerable<Factura> getAllByUsernamePagas(int cliente, int empresa)
        {
            String str = "";
            if (cliente > 0) { str += " AND fact_cliente = @CLIENTE "; }
            if (empresa > 0) { str += " AND fact_empresa = @EMPRESA "; }


            using (var command = new SqlCommand("SELECT [fact_id], [fact_cliente], [fact_empresa], [fact_numero], [fact_fecha_alta], [fact_fecha_vencimiento], [fact_total], [fact_inactiva] " +
                          "FROM  LOS_PUBERTOS.Factura JOIN LOS_PUBERTOS.PF ON pf_factura = fact_id JOIN LOS_PUBERTOS.Pago ON pago_id = pf_pago	 WHERE 1=1 " + str))
            {
                if (cliente > 0) { command.Parameters.AddWithValue("@CLIENTE", cliente); }
                if (empresa > 0) { command.Parameters.AddWithValue("@EMPRESA", empresa); }

                return GetRecords(command);
            }
            throw new NotImplementedException();
        }


        public IEnumerable<Factura> getAllFactARendir(int empresa)
        {
        /*    String str = "";
            String str2 = "";
            str2 += " WHERE NOT EXISTS( SELECT * FROM LOS_PUBERTOS.Rf rf WHERE rf.rf_factura = f.fact_id ) AND " +
                    " NOT EXISTS( SELECT * FROM LOS_PUBERTOS.fd fd WHERE fd.fd_factura = f.fact_id ) AND " +
                    " EXISTS( SELECT * FROM LOS_PUBERTOS.PF pf WHERE pf.pf_factura = f.fact_id ) AND fact_inactiva = 1 ";
            if (empresa > 0) { str += " AND fact_empresa = @EMPRESA "; } */
            using (var command = new SqlCommand(" SELECT [fact_id], [fact_cliente], [fact_empresa], [fact_numero], [fact_fecha_alta], [fact_fecha_vencimiento], " +
                                    		           " [fact_total], [fact_inactiva] FROM LOS_PUBERTOS.Factura f " +
                                              "  WHERE NOT EXISTS( SELECT * FROM LOS_PUBERTOS.Rf rf WHERE rf.rf_factura = f.fact_id ) AND " +
	                                                 " EXISTS( SELECT * FROM LOS_PUBERTOS.PF pf WHERE pf.pf_factura = f.fact_id ) AND " +
  	                                                  " fact_inactiva = 1 AND fact_empresa = @EMPRESA " +
                                                " UNION " +
                                                " SELECT [fact_id], [fact_cliente], [fact_empresa], [fact_numero], [fact_fecha_alta], [fact_fecha_vencimiento], " +
		                                          "       [fact_total], [fact_inactiva] FROM LOS_PUBERTOS.Factura f " +
	                                               " JOIN LOS_PUBERTOS.Rf ON rf_factura = fact_id " +
	                                               " JOIN LOS_PUBERTOS.Rendicion ON rend_ID = rf_rendicion " +
	                                               " JOIN LOS_PUBERTOS.rd ON rd_rendicion = rend_id " +
                                                " WHERE  NOT EXISTS (select * from LOS_PUBERTOS.Rf where rf_factura = fact_id AND NOT EXISTS (select * from LOS_PUBERTOS.Rd where rd_rendicion = rf_rendicion)) AND fact_empresa = @EMPRESA AND fact_inactiva = 1   "))
            {
                if (empresa > 0) { command.Parameters.AddWithValue("@EMPRESA", empresa); }

                return GetRecords(command);
            }
            throw new NotImplementedException();
        }
        
       
        public Factura getFacturaById(int nroFactura)
        {
            using (var command = new SqlCommand(" SELECT fact_id,fact_cliente,fact_empresa,fact_numero,fact_fecha_alta, " +
                                                "fact_fecha_vencimiento,fact_total,fact_inactiva FROM LOS_PUBERTOS.Factura " +
                                                "WHERE fact_numero = @NROFACTURA"))
            {
                command.Parameters.AddWithValue("@NROFACTURA", nroFactura);
                return GetRecord(command);
            }
        }

        public List<string> getAllTrimestres()
        {
            using (var command = new SqlCommand("SELECT CONCAT(DATEPART ( YEAR , fact_fecha_alta ),CONCAT('-T:',DATEPART ( QUARTER , fact_fecha_alta ))) FROM [LOS_PUBERTOS].[Factura] GROUP BY CONCAT(DATEPART ( YEAR , fact_fecha_alta ),CONCAT('-T:',DATEPART ( QUARTER , fact_fecha_alta )))"))
            {
                return GetArray(command);
            }
        }


        public int verifiedFacturaById(int nroFactura)
        {
            using (var command = new SqlCommand("LOS_PUBERTOS.SP_VERIFICAR_FACTURA"))
            {
                command.Parameters.AddWithValue("@NUMERO_DE_FACTURA", nroFactura);
                command.Parameters.Add("@ESTADO_FACTURA", SqlDbType.Int).Direction = ParameterDirection.Output;
                ExecuteSP(command);
                return Convert.ToInt32(command.Parameters["@ESTADO_FACTURA"].Value);
            }
        }

        public override Factura PopulateRecord(SqlDataReader reader)
        {
            Factura factura = new Factura();
            if (!reader.IsDBNull(0))
                factura.id = reader.GetInt32(0);
            if (!reader.IsDBNull(1))
                factura.cliente = reader.GetInt32(1);
            if (!reader.IsDBNull(2))
                factura.empresa = reader.GetInt32(2);
            if (!reader.IsDBNull(3))
                factura.nroFact = reader.GetInt32(3);
            if (!reader.IsDBNull(4))
                factura.fechaDeAlta = reader.GetDateTime(4);
            if (!reader.IsDBNull(5))
                factura.fechaDeVencimiento = reader.GetDateTime(5);
            if (!reader.IsDBNull(6))
            {
                float readerResult = (float)reader.GetDouble(6);

                factura.total = readerResult;
            }
            if (!reader.IsDBNull(7))
                factura.habilitado = reader.GetBoolean(7);
            return factura;
        }
        
    }

}
