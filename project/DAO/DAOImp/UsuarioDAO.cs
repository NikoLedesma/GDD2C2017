using DAO.GenericDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data;

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
            using (var command = new SqlCommand("SELECT ID,USERNAME,PASS,HABILITADO,CANT_INTENTOS_FALLIDOS FROM NO_TENGO_IDEA.USUARIO WHERE NO_TENGO_IDEA.USUARIO.USERNAME = @USERNAME AND NO_TENGO_IDEA.USUARIO.PASS = @PASSWORD"))
            {
                command.Parameters.AddWithValue("@USERNAME", username);
                command.Parameters.AddWithValue("@PASSWORD", password);
                return GetRecord(command);
            }
        }

        public int execLogin(String username, String password)
        {

            using (var command = new SqlCommand("NO_TENGO_IDEA.SP_INICIAR_SESION_DE_USUARIO"))
            {
                command.Parameters.AddWithValue("@USERNAME", username);
                command.Parameters.AddWithValue("@PASSWORD", password);
                command.Parameters.Add("@ESTADO_INICIO", SqlDbType.Int).Direction = ParameterDirection.Output;
                ExecuteSP(command); 
                return Convert.ToInt32(command.Parameters["@ESTADO_INICIO"].Value);
            }
        }

        public void add(String username, String password,int id){
            using (var command = new SqlCommand("INSERT INTO NO_TENGO_IDEA.USUARIO  (ID,USERNAME,PASS,HABILITADO,CANT_INTENTOS_FALLIDOS) "
                                                + "VALUES (@ID,@USERNAME,@PASSWORD,1,1)"))
            {
                command.Parameters.AddWithValue("@USERNAME", username);
                command.Parameters.AddWithValue("@PASSWORD", password);
                command.Parameters.AddWithValue("@ID", id);
                save(command);
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
