using DAO.GenericDAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO.DAOImp
{
    public class ListEstadisticoDAO : GenericDAO<ListEstadistico>
    {
        public IEnumerable<ListEstadistico> getAllPorcFactCobradas(string trimestre)
        {
            using (var command = new SqlCommand("DECLARE @Quarter varchar(100);"+
                                                "Set @Quarter = @TRIMESTRE; " +
                                                "select	FactPagadas.fact_empresa,"+ 
		                                                "empr_nombre, "+
		                                                "empr_cuit, "+
		                                                "count(*)*100/ (select count(*) from LOS_PUBERTOS.Factura as Fact where Fact.fact_empresa = FactPagadas.fact_empresa AND CONCAT(DATEPART ( YEAR , Fact.fact_fecha_vencimiento ),CONCAT('-T:',DATEPART ( QUARTER , Fact.fact_fecha_vencimiento ))) LIKE @QUARTER  group by Fact.fact_empresa) "+
		                                                "from LOS_PUBERTOS.Pago "+
			                                                 "JOIN LOS_PUBERTOS.PF ON Pago.pago_id = pf.pf_pago "+
			                                                 "JOIN LOS_PUBERTOS.Factura as FactPagadas ON pf_factura = fact_id "+
			                                                 "JOIN LOS_PUBERTOS.Empresa AS emp ON fact_empresa = emp.empr_id "+
                                                        "where CONCAT(DATEPART ( YEAR , pago_fecha ),CONCAT('-T:',DATEPART ( QUARTER , pago_fecha ))) LIKE  @QUARTER " +
		                                                "group by fact_empresa, empr_nombre, empr_cuit"))
            {
                command.Parameters.Add("@TRIMESTRE", SqlDbType.VarChar).Value = trimestre;
               
                return GetRecords(command);
            }
        }
        public override ListEstadistico PopulateRecord(SqlDataReader reader)
        {
            ListEstadistico objListEstadistico = new ListEstadistico();
            if (!reader.IsDBNull(0))
                objListEstadistico.id = reader.GetInt32(0);
            if (!reader.IsDBNull(1))
                objListEstadistico.nombre = reader.GetString(1);
            if (!reader.IsDBNull(2))
                objListEstadistico.cuit = reader.GetString(2);
            if (!reader.IsDBNull(3))
                objListEstadistico.total = (float)reader.GetInt32(3);
            return objListEstadistico;
        }

    }
}
