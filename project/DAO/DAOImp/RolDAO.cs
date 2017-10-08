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


        public IEnumerable<Rol> getAll( )
        {
            using (var command = new SqlCommand("SELECT R.ID,R.NOMBRE,R.HABILITADO FROM NO_TENGO_IDEA.ROL R"))
            {
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





        public int removeFuncionalidadByRolName(string rolName, string funcionalidadName)
        {

            using (var command = new SqlCommand("DELETE FROM NO_TENGO_IDEA.ROLXFUNCIONALIDAD WHERE "+
                                "ROL_ID IN (SELECT R.ID FROM NO_TENGO_IDEA.ROL R WHERE R.NOMBRE=@ROLNAME) AND "+
                                "FUNCIONALIDAD_ID IN (SELECT F.ID FROM NO_TENGO_IDEA.FUNCIONALIDAD F WHERE F.NOMBRE = @FUNCIONALIDADNAME)" ))
            {
                command.Parameters.AddWithValue("@ROLNAME", rolName);
                command.Parameters.AddWithValue("@FUNCIONALIDADNAME", funcionalidadName);
                return remove(command);
            }

        }

        public int addFuncionalidadToRol(string rolName, string funcionalidadName)
        {
            using (var command = new SqlCommand("INSERT INTO NO_TENGO_IDEA.ROLXFUNCIONALIDAD (ROL_ID,FUNCIONALIDAD_ID) SELECT " +
                    "(SELECT R.ID FROM NO_TENGO_IDEA.ROL R WHERE R.NOMBRE = @ROLNAME), " +
                    "(SELECT F.ID FROM NO_TENGO_IDEA.FUNCIONALIDAD F WHERE F.NOMBRE = @FUNCIONALIDADNAME ) "))
            {
                command.Parameters.AddWithValue("@ROLNAME", rolName);
                command.Parameters.AddWithValue("@FUNCIONALIDADNAME", funcionalidadName);
                return save(command);
            }
        }

        public int deleteLogicalByName(string rolName)
        {
            using (var command = new SqlCommand("UPDATE NO_TENGO_IDEA.ROL SET HABILITADO = 0 WHERE NOMBRE = @ROLNAME ") )
            {
                command.Parameters.AddWithValue("@ROLNAME", rolName);
                return save(command);
            }    
        }


        public int addLogicalByName(string rolName)
        {
            using (var command = new SqlCommand("UPDATE NO_TENGO_IDEA.ROL SET HABILITADO = 1 WHERE NOMBRE = @ROLNAME "))
            {
                command.Parameters.AddWithValue("@ROLNAME", rolName);
                return save(command);
            }
        }




        public int addRol(string rolName)
        {
            using (var command = new SqlCommand("SET IDENTITY_INSERT NO_TENGO_IDEA.ROL OFF INSERT INTO  NO_TENGO_IDEA.ROL (NOMBRE,HABILITADO) "
                                                +"VALUES(@ROLNAME,1) "))
            {
                command.Parameters.AddWithValue("@ROLNAME", rolName);
                return save(command);
            }
        }


    }
}
