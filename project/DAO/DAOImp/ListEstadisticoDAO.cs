using DAO.GenericDAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO.DAOImp
{
    public class ListEstadisticoDAO : GenericDAO<ListEstadistico>
    {
        public IEnumerable<ListEstadistico> getAllPorcFactCobradas(string trimestre)
        {
            using (var command = new SqlCommand("select FactPagadas.fact_empresa, count(*)*100/ (select count(*) from LOS_PUBERTOS.Factura as Fact where Fact.fact_empresa = FactPagadas.fact_empresa AND CONCAT(DATEPART ( YEAR , Fact.fact_fecha_vencimiento ),CONCAT('-T:',DATEPART ( QUARTER , Fact.fact_fecha_vencimiento ))) = @QUARTER  group by Fact.fact_empresa) " +
                                                    "from LOS_PUBERTOS.Pago " +
                                                    "JOIN LOS_PUBERTOS.PF ON Pago.pago_id = pf.pf_pago " +
                                                    "JOIN LOS_PUBERTOS.Factura as FactPagadas ON pf_factura = fact_id " +
                                                    "where CONCAT(DATEPART ( YEAR , pago_fecha ),CONCAT('-T:',DATEPART ( QUARTER , pago_fecha ))) = @QUARTER " +
                                                    "group by fact_empresa "))
            {
                command.Parameters.AddWithValue("@QUARTER", trimestre);
                return GetRecords(command);
            }
        }
        public override ListEstadistico PopulateRecord(SqlDataReader reader)
        {
            ListEstadistico objListEstadistico = new ListEstadistico();
            if (!reader.IsDBNull(0))
                objListEstadistico.nombre = reader.GetInt32(0);
            if (!reader.IsDBNull(1))
                objListEstadistico.total = (float)reader.GetDouble(6);
            return objListEstadistico;
        }

    }
}
