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
    public class SucursalDAO : GenericDAO<Sucursal>
    {
        public int saveSucursal(Sucursal sucursal)
        {
            using (var command = new SqlCommand("INSERT INTO LOS_PUBERTOS.Sucursal " +
                                    "(sucu_nom,sucu_dire,sucu_cp,sucu_inactive) " +
                                    "VALUES (@NOMBRE,@DIRECCION,@COD_POSTAL,@HABILITADO)"))
                                                                                
          {
                command.Parameters.AddWithValue("@NOMBRE", sucursal.nombre);
                command.Parameters.AddWithValue("@DIRECCION", sucursal.direccion);
                command.Parameters.AddWithValue("@COD_POSTAL", sucursal.codPostal);
                command.Parameters.AddWithValue("@HABILITADO", sucursal.habilitado);
                return save(command);
            }
        }

        public int updateSucursal(Sucursal sucursal) //Cambio los valores de la sucursal
        {
            using (var command = new SqlCommand("UPDATE LOS_PUBERTOS.Sucursal SET " +
                        "sucu_nom=@NOMBRE,sucu_dire=@DIRECCION,sucu_cp=@COD_POSTAL,sucu_inactive=@HABILITADO " +
                        "WHERE sucu_id= @ID "))
            {
                command.Parameters.AddWithValue("@NOMBRE", sucursal.nombre);
                command.Parameters.AddWithValue("@DIRECCION", sucursal.direccion);
                command.Parameters.AddWithValue("@COD_POSTAL", sucursal.codPostal);
                command.Parameters.AddWithValue("@HABILITADO", sucursal.habilitado);
                command.Parameters.AddWithValue("@ID", sucursal.id);
                return save(command);
            }
        }


        public IEnumerable<Sucursal> getAllByUsername(string nombre, string apellido, int dni)  //busco en la base de datos filtrando por nombre, ap, codigo postal
        {
            String str = "";
            if (!String.IsNullOrEmpty(nombre)) { str += " AND sucu_nom LIKE @NOMBRE + '%' "; }
            if (!String.IsNullOrEmpty(apellido)) { str += " AND sucu_dire LIKE @APELLIDO+ '%' "; }
            if (dni > 0) { str += " AND sucu_cp = @DNI "; }

            using (var command = new SqlCommand("SELECT sucu_id,sucu_nom,sucu_dire,sucu_cp,sucu_inactive " +
                          "FROM  LOS_PUBERTOS.Sucursal WHERE 1=1 " + str))
            {
//////////VER PORQUE EN CLIENTE DAO EL NOMBRE LO COMPARA CON NOMBRE - LA LINEA DE ABAJO

                if (!String.IsNullOrEmpty(nombre)) { command.Parameters.AddWithValue("@NOMBRE", nombre); }
                if (!String.IsNullOrEmpty(apellido)) { command.Parameters.AddWithValue("@APELLIDO", apellido); }
                if (dni > 0) { command.Parameters.AddWithValue("@DNI", dni); }
                return GetRecords(command);
            }
            throw new NotImplementedException();
        }


        public IEnumerable<Sucursal> getAll() //busco y traigo de la base de datos todas las sucursales
        {
            using (var command = new SqlCommand("SELECT sucu_id,sucu_nom,sucu_dire,sucu_inactive from LOS_PUBERTOS.Sucursal"))
            {
                return GetRecords(command);
            }

            throw new NotImplementedException();
        }


        public override Sucursal PopulateRecord(SqlDataReader reader)
        {
            Sucursal sucursal = new Sucursal();
            if (!reader.IsDBNull(0))
                sucursal.id = reader.GetInt32(0);
            if (!reader.IsDBNull(1))
                sucursal.nombre = reader.GetString(1);
            if (!reader.IsDBNull(2))
                sucursal.direccion = reader.GetString(2);
            if (!reader.IsDBNull(3))
                sucursal.codPostal = reader.GetInt32(3);
            if (!reader.IsDBNull(4))
                sucursal.habilitado = reader.GetBoolean(4);
            return sucursal;
        }

        public int deleteSucursal(Sucursal sucursal)
        {
            using (var command = new SqlCommand("UPDATE LOS_PUBERTOS.Sucursal SET sucu_inactive=@HABILITADO " +
            "WHERE sucu_id = @ID "))
            {
                command.Parameters.AddWithValue("@HABILITADO", sucursal.habilitado);
                command.Parameters.AddWithValue("@ID", sucursal.id);
                return save(command);
            }
        }




    }

}
