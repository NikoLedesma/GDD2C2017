using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.GenericDAO
{
    public abstract class GenericDAO<T> where T : class
    {
        private static SqlConnection _connection;

        public GenericDAO()
        {
            _connection = new SqlConnection(Properties.Settings.Default.str_connection);
        }


        public GenericDAO(String connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }


        public virtual T PopulateRecord(SqlDataReader reader)
        {
            return null;
        }




        public void save(SqlCommand command)
        {

            using (SqlConnection connection1 = new SqlConnection(Properties.Settings.Default.str_connection))
            {
                var list = new List<T>();
                command.Connection = connection1;
                connection1.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException sql)
                {
                    System.Diagnostics.Debug.Write(sql.Message);
                }

                finally
                {
                    _connection.Close();
                }
            }
        }


        public IEnumerable<T> GetRecords(SqlCommand command)
        {
            var list = new List<T>();
            command.Connection = _connection;
            _connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(PopulateRecord(reader));
                }
            }
            finally
            {
                _connection.Close();
            }
            return list;
        }

        public T GetRecord(SqlCommand command)
        {
            T record = null;
            command.Connection = _connection;
            _connection.Open();

            var reader = command.ExecuteReader();
            try
            {
            while (reader.Read())
            {
                record = PopulateRecord(reader);
                break;
            }
            reader.Close();
            }
            finally
            {
                _connection.Close();
            }
            return record;
        }

        public IEnumerable<T> ExecuteStoredProc(SqlCommand command)
        {
            var list = new List<T>();
            command.Connection = _connection;
            command.CommandType = CommandType.StoredProcedure;
            _connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var record = PopulateRecord(reader);
                    if (record != null) list.Add(record);
                }
                reader.Close();
            }
            finally
            {
                _connection.Close();
            }
            return list;
        }


        public int ExecuteSP(SqlCommand command)
        {
            var response = 0;
            command.Connection = _connection;
            command.CommandType = CommandType.StoredProcedure;
            _connection.Open();
            try
            {
                command.ExecuteScalar();

            }
            finally
            {
                _connection.Close();
            }
            return response;
        }










    }

}
