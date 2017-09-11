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


    public class RolDAO : GenericDAO <Rol>
    {

        public RolDAO()
        {

        }

        public RolDAO(string connectionString): base(connectionString)
        {

        }


        public IEnumerable<Rol> getAllByUsername(String username) {
            using ( var command =  new SqlCommand("SELECT R.ID,R.NOMBRE,R.HABILITADO FROM NO_TENGO_IDEA.ROL R INNER JOIN "+
                   "NO_TENGO_IDEA.USUARIOXROL UXR ON UXR.ROL_ID = R.ID  INNER JOIN NO_TENGO_IDEA.USUARIO U ON U.ID =UXR.USUARIO_ID "+
                   "WHERE U.USERNAME = @USERNAME"))
            {
                command.Parameters.AddWithValue("@USERNAME",username);
                return GetRecords(command);
            }
        }

        public override Rol PopulateRecord(SqlDataReader reader)
        {
            Rol rol = new Rol();
            rol.Nombre = reader.GetString(1);
            rol.Habilitado = reader.GetBoolean(2);
            return rol;
        }




    }
}
