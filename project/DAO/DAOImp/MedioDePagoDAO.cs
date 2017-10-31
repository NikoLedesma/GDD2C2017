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
    public class MedioDePagoDAO : GenericDAO<MedioDePago>
    {

        public IEnumerable<MedioDePago> getAllMediosDePago()
        {
            using (var command = new SqlCommand("SELECT M.MEDI_ID,M.MEDI_NOMBRE FROM LOS_PUBERTOS.MEDIODEPAGO M"))
            {
                return GetRecords(command);
            }
        }

        public override MedioDePago PopulateRecord(SqlDataReader reader)
        {
            MedioDePago medioDePago = new MedioDePago();
            medioDePago.id = reader.GetInt32(0);
            medioDePago.nombre = reader.GetString(1);
            return medioDePago;
        }

    }
}
