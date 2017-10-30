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
    public class  RubroDAO : GenericDAO<Rubro>
    {
        public IEnumerable<Rubro> getAllRubros()
        {
            using (var command = new SqlCommand("select rubr_id, rubr_nombre from LOS_PUBERTOS.Rubro"))
            {
                return GetRecords(command);
            }
        }
        public override Rubro PopulateRecord(SqlDataReader reader)
        {
            Rubro rubro = new Rubro();
            rubro.id = reader.GetInt32(0);
            rubro.nombre = reader.GetString(1);
            return rubro;
        }
    }
}
