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







        public int remove(SqlCommand command)
        {

            using (SqlConnection connection1 = new SqlConnection(Properties.Settings.Default.str_connection))
            {
                command.Connection = connection1;
                connection1.Open();
                var i=-1;
                try
                {
                  i = command.ExecuteNonQuery();
                }
                catch (SqlException sql)
                {
                    System.Diagnostics.Debug.Write(sql.Message);
                }
                finally
                {
                    _connection.Close();
                }
                return i; 
            }
        }










        public int save(SqlCommand command)
        {

            using (SqlConnection connection1 = new SqlConnection(Properties.Settings.Default.str_connection))
            {
                var list = new List<T>();
                int i=-1;
                command.Connection = connection1;
                connection1.Open();
                try
                {
                 i = command.ExecuteNonQuery();
                }
                catch (SqlException sql)
                {
                    System.Diagnostics.Debug.Write(sql.Message);
                }

                finally
                {
                    _connection.Close();
                }
                return i;
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

        public List<string> GetArray(SqlCommand command)
        {
            List<string> list = new List<string>();
            command.Connection = _connection;
            _connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(getStringOfReader(reader));
                }
            }
            finally
            {
                _connection.Close();
            }
            return list;
        }
        public string getStringOfReader(SqlDataReader reader){
                
            var resu = "";
            if (!reader.IsDBNull(0))
                resu = reader.GetString(0);
            return resu;
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




        public int GetCount(SqlCommand command)
        {
            int count = -1;
            command.Connection = _connection;
            _connection.Open();

            var reader = command.ExecuteReader();
            try
            {

                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }

                reader.Close();
            }
            finally
            {
                _connection.Close();
            }
            return count;
        }





    }

}
