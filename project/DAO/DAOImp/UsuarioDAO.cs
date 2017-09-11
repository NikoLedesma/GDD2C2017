using DAO.GenericDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace DAO.DAOImp
{

    public class UsuarioDAO : GenericDAO<Usuario>
    {

        public UsuarioDAO()            
        {
        }

        public UsuarioDAO(string connectionString): base(connectionString)
        {
        }


        public IEnumerable<Usuario> GetAll()
        {
            using (var command = new SqlCommand("SELECT ID,USERNAME,PASS,HABILITADO,CANT_INTENTOS_FALLIDOS FROM NO_TENGO_IDEA.USUARIO"))
            {
                return GetRecords(command);
            }
        }
        public Usuario GetByLogin(String username, String password)
        {
            // PARAMETERIZED QUERIES!
            using (var command = new SqlCommand("SELECT ID,USERNAME,PASS,HABILITADO,CANT_INTENTOS_FALLIDOS FROM NO_TENGO_IDEA.USUARIO WHERE NO_TENGO_IDEA.USUARIO.USERNAME = @USERNAME AND NO_TENGO_IDEA.USUARIO.PASS = @PASSWORD"))
            {
                command.Parameters.AddWithValue("@USERNAME", username);
                command.Parameters.AddWithValue("@PASSWORD", password);
                return GetRecord(command);
            }
        }
        public override Usuario PopulateRecord(SqlDataReader reader)
        {
            Usuario usuario = new Usuario();
            usuario.Id = reader.GetInt32(0);
            usuario.Username = reader.GetString(1);
            usuario.Password = reader.GetString(2);
            usuario.Habilitado = reader.GetBoolean(3);
            usuario.CantIntentosFallidos = reader.GetByte(4);
            return usuario;
        }

    }

}
