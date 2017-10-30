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
    public class ClienteDAO : GenericDAO<Cliente>
    {
        public int saveCliente(Cliente cliente)
        {
            using (var command = new SqlCommand("INSERT INTO LOS_PUBERTOS.CLIENTE "+
	                                "(CLIENTE_NOMBRE,CLIENTE_APELLIDO,CLIENTE_DNI,CLIENTE_MAIL,CLIENTE_DIRECCION,CLIENTE_NRO_PISO,CLIENTE_DEPTO,CLIENTE_LOCALIDAD,CLIENTE_NRO_TELEFONO,CLIENTE_COD_POSTAL,CLIENTE_FECHA_NACIMIENTO,CLIENTE_HABILITADO) "+
                                    "VALUES (@NOMBRE,@APELLIDO,@DNI,@MAIL,@DIRECCION,@NRO_PISO,@DEPTO,@LOCALIDAD,@NRO_TELEFONO,@COD_POSTAL,@FECHA_DE_NACIMIENTO,@HABILITADO)"))
            {
                command.Parameters.AddWithValue("@NOMBRE", cliente.nombre);
                command.Parameters.AddWithValue("@APELLIDO", cliente.apellido);
                command.Parameters.AddWithValue("@DNI", cliente.dni);
                command.Parameters.AddWithValue("@MAIL", cliente.mail);
                command.Parameters.AddWithValue("@DIRECCION", cliente.direccion);
                command.Parameters.AddWithValue("@NRO_PISO", cliente.nroPiso);
                command.Parameters.AddWithValue("@DEPTO", cliente.departamento);
                command.Parameters.AddWithValue("@LOCALIDAD", cliente.localidad);
                command.Parameters.AddWithValue("@NRO_TELEFONO", cliente.nroTelefono);
                command.Parameters.AddWithValue("@COD_POSTAL", cliente.codPostal);
                command.Parameters.AddWithValue("@FECHA_DE_NACIMIENTO", cliente.fechaDeNacimiento);
                command.Parameters.AddWithValue("@HABILITADO", cliente.habilitado);
                return save(command);
            }
        }

        public IEnumerable<Cliente> getAllByUsername(string nombre, string apellido, int dni)
        {
            String str = "" ;
            if (!String.IsNullOrEmpty(nombre)) { str += " AND CLIENTE_NOMBRE LIKE @NOMBRE + '%' "; }
            if (!String.IsNullOrEmpty(apellido)) { str += " AND CLIENTE_APELLIDO LIKE @APELLIDO + '%' "; }
            if (dni > 0) { str += " AND CLIENTE_DNI = @DNI "; }

            using (var command = new SqlCommand("SELECT CLIENTE_ID,CLIENTE_NOMBRE,CLIENTE_APELLIDO,CLIENTE_DNI,CLIENTE_MAIL,CLIENTE_DIRECCION,CLIENTE_NRO_PISO,CLIENTE_DEPTO,CLIENTE_LOCALIDAD,CLIENTE_NRO_TELEFONO,CLIENTE_COD_POSTAL,CLIENTE_FECHA_NACIMIENTO,CLIENTE_HABILITADO " +
                          "FROM  LOS_PUBERTOS.CLIENTE WHERE 1=1 " + str))
            {
                if (!String.IsNullOrEmpty(nombre)) { command.Parameters.AddWithValue("@NOMBRE", nombre); }
                if (!String.IsNullOrEmpty(apellido)) { command.Parameters.AddWithValue("@APELLIDO", apellido); }
                if (dni > 0){command.Parameters.AddWithValue("@DNI", dni);}
                return GetRecords(command);
            }
            throw new NotImplementedException();
        }
        public IEnumerable<Cliente> getAll()
        {

            using (var command = new SqlCommand("select CLIENTE_ID,CLIENTE_NOMBRE,CLIENTE_APELLIDO,CLIENTE_DNI,CLIENTE_MAIL,CLIENTE_DIRECCION,CLIENTE_NRO_PISO,CLIENTE_DEPTO,CLIENTE_LOCALIDAD,CLIENTE_NRO_TELEFONO,CLIENTE_COD_POSTAL,CLIENTE_FECHA_NACIMIENTO,CLIENTE_HABILITADO from LOS_PUBERTOS.Cliente"))
            {
                return GetRecords(command);
            }
        
            throw new NotImplementedException();
        }



        public IEnumerable<Cliente> update( Cliente cliente)
        {
            return null;
        }


        public override Cliente PopulateRecord(SqlDataReader reader)
        {
            Cliente cliente = new Cliente();
            if (!reader.IsDBNull(0))
                cliente.id = reader.GetInt32(0);
            if (!reader.IsDBNull(1))
                cliente.nombre = reader.GetString(1);
            if (!reader.IsDBNull(2)) 
                cliente.apellido = reader.GetString(2);
            if (!reader.IsDBNull(3))
                cliente.dni = reader.GetInt32(3);
            if (!reader.IsDBNull(4))
                cliente.mail = reader.GetString(4) ;
            if (!reader.IsDBNull(5))    
                cliente.direccion = reader.GetString(5);
            if (!reader.IsDBNull(6))
                cliente.nroPiso = reader.GetInt16(6);
            if (!reader.IsDBNull(7))
                cliente.departamento = reader.GetString(7) [0];
            if (!reader.IsDBNull(8))
                cliente.localidad = reader.GetString(8);
            if (!reader.IsDBNull(9))
                cliente.nroTelefono =reader.GetInt32(9);
            if (!reader.IsDBNull(10))
                cliente.codPostal = reader.GetString(10);
            if (!reader.IsDBNull(11))
                cliente.fechaDeNacimiento = reader.GetDateTime(11);
            if (!reader.IsDBNull(12))
                cliente.habilitado = reader.GetBoolean(12);
            return cliente;
        }


        public int updateCliente(Cliente cliente)
        {
            using (var command = new SqlCommand("UPDATE LOS_PUBERTOS.CLIENTE SET " +
                        "CLIENTE_NOMBRE=@NOMBRE,CLIENTE_APELLIDO=@APELLIDO,CLIENTE_DNI=@DNI,CLIENTE_MAIL=@MAIL,CLIENTE_DIRECCION=@DIRECCION,CLIENTE_NRO_PISO=@NRO_PISO,CLIENTE_DEPTO=@DEPTO,CLIENTE_LOCALIDAD=@LOCALIDAD,CLIENTE_NRO_TELEFONO=@NRO_TELEFONO,CLIENTE_COD_POSTAL=@COD_POSTAL,CLIENTE_FECHA_NACIMIENTO=@FECHA_DE_NACIMIENTO,CLIENTE_HABILITADO=@HABILITADO " +
                        "WHERE CLIENTE_ID = @ID "))
            
            {
                command.Parameters.AddWithValue("@NOMBRE", cliente.nombre);
                command.Parameters.AddWithValue("@APELLIDO", cliente.apellido);
                command.Parameters.AddWithValue("@DNI", cliente.dni);
                command.Parameters.AddWithValue("@MAIL", cliente.mail);
                command.Parameters.AddWithValue("@DIRECCION", cliente.direccion);
                command.Parameters.AddWithValue("@NRO_PISO", cliente.nroPiso);
                command.Parameters.AddWithValue("@DEPTO", cliente.departamento);
                command.Parameters.AddWithValue("@LOCALIDAD", cliente.localidad);
                command.Parameters.AddWithValue("@NRO_TELEFONO", cliente.nroTelefono);
                command.Parameters.AddWithValue("@COD_POSTAL", cliente.codPostal);
                command.Parameters.AddWithValue("@FECHA_DE_NACIMIENTO", cliente.fechaDeNacimiento);
                command.Parameters.AddWithValue("@HABILITADO", cliente.habilitado);
                command.Parameters.AddWithValue("@ID", cliente.id);
                return save(command);
            }
        }

        public int deleteCliente(Cliente cliente)
        {
            using (var command = new SqlCommand("UPDATE LOS_PUBERTOS.CLIENTE SET CLIENTE_HABILITADO=@HABILITADO " +
            "WHERE CLIENTE_ID = @ID "))
            {
                command.Parameters.AddWithValue("@HABILITADO", cliente.habilitado);
                command.Parameters.AddWithValue("@ID", cliente.id);
                return save(command);
            }
        }
    }
}
