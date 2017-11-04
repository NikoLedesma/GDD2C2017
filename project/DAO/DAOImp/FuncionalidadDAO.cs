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
    public class FuncionalidadDAO : GenericDAO<Funcionalidad>
    {

        private static String NAME_IGNORED = "F.NOMBRE NOT IN ('Login y Seguridad','Registro de usuario')";


        public IEnumerable<Funcionalidad> getFuncionalidadByRolId(int rolID)
        {
            using (var command = new SqlCommand("SELECT F.ID, F.NOMBRE FROM LOS_PUBERTOS.FUNCIONALIDAD F INNER JOIN "+
                "LOS_PUBERTOS.ROLXFUNCIONALIDAD RF ON F.ID = RF.FUNCIONALIDAD_ID WHERE RF.ROL_ID = @ROLID "+
                "AND " + NAME_IGNORED))
            {
                command.Parameters.AddWithValue("@ROLID", rolID);
                return GetRecords(command);
            }
        }


        public IEnumerable<Funcionalidad> getFuncionalidadByRolName(String rolName)
        {
            using (var command = new SqlCommand("SELECT F.ID, F.NOMBRE FROM LOS_PUBERTOS.FUNCIONALIDAD F " +
                "INNER JOIN LOS_PUBERTOS.ROLXFUNCIONALIDAD RF ON F.ID = RF.FUNCIONALIDAD_ID " +
                "INNER JOIN  LOS_PUBERTOS.ROL R ON R.ID = RF.ROL_ID WHERE R.NOMBRE = @ROLNAME "+
                "AND " + NAME_IGNORED))
            {
                command.Parameters.AddWithValue("@ROLNAME", rolName);
                return GetRecords(command);
            }
        }



        public IEnumerable<Funcionalidad> getFuncionalidadNotAddedByRolName(String rolName)
        {
            using (var command = new SqlCommand("SELECT F.ID, F.NOMBRE FROM LOS_PUBERTOS.FUNCIONALIDAD F "+
                "WHERE "+ NAME_IGNORED + " EXCEPT " +
                "SELECT F.ID, F.NOMBRE FROM LOS_PUBERTOS.FUNCIONALIDAD F " +
                "INNER JOIN LOS_PUBERTOS.ROLXFUNCIONALIDAD RF ON F.ID = RF.FUNCIONALIDAD_ID " +
                "INNER JOIN  LOS_PUBERTOS.ROL R ON R.ID = RF.ROL_ID WHERE R.NOMBRE = @ROLNAME "))
            {
                command.Parameters.AddWithValue("@ROLNAME", rolName);
                return GetRecords(command);
            }
        }


        public override Funcionalidad PopulateRecord(SqlDataReader reader)
        {
            Funcionalidad funcionalidad = new Funcionalidad();
            funcionalidad.id = reader.GetInt32(0);
            funcionalidad.Nombre = reader.GetString(1);
            return funcionalidad;
        }




        public IEnumerable<Funcionalidad> getAllFuncionalidades()
        {
            using (var command = new SqlCommand("SELECT F.ID,F.NOMBRE FROM LOS_PUBERTOS.FUNCIONALIDAD F "+
                "WHERE " + NAME_IGNORED))
            {
                return GetRecords(command);
            }

        }
    }
}
