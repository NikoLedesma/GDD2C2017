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
            using (var command = new SqlCommand("select * from NO_TENGO_IDEA.Rubro"))
            {
                return GetRecords(command);
            }
        }
    }
}
