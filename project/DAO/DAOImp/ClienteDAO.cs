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
            using (var command = new SqlCommand("INSERT INTO NO_TENGO_IDEA.CLIENTE "+
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


    }
}
