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
    public class DevolucionDAO : GenericDAO<Devolucion>
    {
        public int saveDevolucion(Devolucion devulucion)
        {
            using (var command = new SqlCommand("[LOS_PUBERTOS].createDevolucion"))/*new SqlCommand("INSERT INTO LOS_PUBERTOS.Devolucion " +
                                    "(devo_razon) " +
                                    "VALUES (@RAZON)"))*/
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RAZON", devulucion.razon);
                command.Parameters.AddWithValue("@FACTURA", devulucion.idFact);
                command.Parameters.AddWithValue("@RENDICION", devulucion.idRendicion);

                return save(command);
            }
        }
        public override Devolucion PopulateRecord(SqlDataReader reader)
        {
            Devolucion devo = new Devolucion();
            if (!reader.IsDBNull(0))
                devo.id = reader.GetInt32(0);
            if (!reader.IsDBNull(1))
                devo.razon = reader.GetString(1);

            return devo;
        }
    }
}
