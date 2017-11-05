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
    public class RendicionDAO : GenericDAO<Rendicion>
    {

        public int saveRendicion(Rendicion rendicion)
        {
            /*using (var command = new SqlCommand("INSERT INTO LOS_PUBERTOS.Rendicion " +
                        "(rend_fecha,rend_importe,rend_porcentaje) " +
                        "VALUES (@FECHA,@IMPORTE,@PORCENTAJE)"))
            */
            using (var command = new SqlCommand("[LOS_PUBERTOS].agregarRendicion"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FECHA", rendicion.fecha);
                command.Parameters.AddWithValue("@IMPORTE", rendicion.importe);
                command.Parameters.AddWithValue("@PORCENTAJE", rendicion.porcentaje);
                command.Parameters.AddWithValue("@IDFACT", rendicion.idFact);
                command.Parameters.AddWithValue("@RESULT", 0);

                return save(command);
            }

        }
        public List<string> getAllTrimestres()
        {
            using (var command = new SqlCommand("SELECT CONCAT(DATEPART ( YEAR , rend_fecha ),CONCAT('-T:',DATEPART ( QUARTER , rend_fecha ))) FROM [LOS_PUBERTOS].[Rendicion] GROUP BY CONCAT(DATEPART ( YEAR , rend_fecha ),CONCAT('-T:',DATEPART ( QUARTER , rend_fecha )))"))
            {
                return GetArray(command);
            }
        }
        public IEnumerable<Rendicion> getRendicionByEmpresa(int empresaId) //aca tengo qe traer todos los campos
        {
            String str = "";

            if (empresaId > 0) { str += " AND fact_empresa = @EMPRESA "; }
            //en el comando sql capaz que puedo no traerme el id si no lo uso
            using (var command = new SqlCommand("SELECT  [rend_id]" +
                                                "  ,[rend_fecha]" +
                                                "  ,[rend_importe]" +
                                                "  ,[rend_numero]" +
                                                "  ,ISNULL([rend_porcentaje],0.0) " +
                                                "FROM [LOS_PUBERTOS].[Rendicion] " +
                                                "JOIN [LOS_PUBERTOS].[Rf] ON rf_rendicion = rend_id " +
                                                "JOIN [LOS_PUBERTOS].[Factura] ON rf_factura = fact_id " +
                                                "WHERE 1=1 " + str))
            {

                if (empresaId > 0) { command.Parameters.AddWithValue("@EMPRESA", empresaId); }
                return GetRecords(command);
            }

            throw new NotImplementedException();
        }




        public override Rendicion PopulateRecord(SqlDataReader reader)
        {
            Rendicion rendicion = new Rendicion();
            if (!reader.IsDBNull(0))
                rendicion.id = reader.GetInt32(0);
            if (!reader.IsDBNull(1))
                rendicion.fecha = reader.GetDateTime(1);
            if (!reader.IsDBNull(2))
                rendicion.importe = (float)reader.GetDouble(2);
            if (!reader.IsDBNull(3))
                rendicion.numero = reader.GetInt32(3);
            if (!reader.IsDBNull(4))
                rendicion.porcentaje = (float)reader.GetDouble(4);
            return rendicion;
        }

    }
}
