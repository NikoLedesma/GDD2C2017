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
            using (var command = new SqlCommand("INSERT INTO NO_TENGO_IDEA.Sucursal " +
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
            using (var command = new SqlCommand("UPDATE NO_TENGO_IDEA.Sucursal SET " +
                        "sucu_nom=@NOMBRE,sucu_dire=@DIRECCION,sucu_cp=@COD_POSTAL,sucu_inactive=@HABILITADO " +
                        "WHERE SUCURSAL_ID = @ID "))
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
            if (nombre != null && !nombre.Equals(apellido)) { str += " AND sucu_nom = @NOMBRE "; }
            if (apellido != null && !apellido.Equals(apellido)) { str += " AND sucu_dire = @APELLIDO "; }
            if (dni > 0) { str += " AND sucu_cp = @DNI "; }

            using (var command = new SqlCommand("SELECT sucu_id,sucu_nom,sucu_dire,sucu_inactive " +
                          "FROM  NO_TENGO_IDEA.Sucursal WHERE 1=1 " + str))
            {
//////////VER PORQUE EN CLIENTE DAO EL NOMBRE LO COMPARA CON NOMBRE - LA LINEA DE ABAJO

                if (nombre != null && !nombre.Equals(nombre)) { command.Parameters.AddWithValue("@NOMBRE", nombre); }
                if (apellido != null && !apellido.Equals(apellido)) { command.Parameters.AddWithValue("@APELLIDO", apellido); }
                if (dni > 0) { command.Parameters.AddWithValue("@DNI", dni); }
                return GetRecords(command);
            }
            throw new NotImplementedException();
        }


        public IEnumerable<Sucursal> getAll()         //busco y traigo de la base de datos todas las sucursales
        {
            using (var command = new SqlCommand("SELECT sucu_id,sucu_nom,sucu_dire,sucu_inactive from NO_TENGO_IDEA.Sucursal"))
            {
                return GetRecords(command);
            }

            throw new NotImplementedException();
        }





    }

}
