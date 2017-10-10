using DAO.DAOImp;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessClienteImpl
    {

        public int saveCliente(ClienteDTO clienteDTO)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            Cliente cliente = converterClienteDTOToCliente(clienteDTO);
            return clienteDAO.saveCliente(cliente);
        }

        public Cliente converterClienteDTOToCliente(ClienteDTO clienteDTO)
        {
            Cliente cliente = new Cliente();
            cliente.nombre = clienteDTO.nombre;
            cliente.apellido = clienteDTO.apellido;
            cliente.dni = clienteDTO.dni;
            cliente.mail = clienteDTO.mail;
            cliente.nroTelefono = clienteDTO.nroTelefono;
            cliente.direccion = clienteDTO.direccion;
            cliente.nroPiso = clienteDTO.nroPiso;
            cliente.departamento = clienteDTO.departamento;
            cliente.localidad = clienteDTO.localidad;
            cliente.codPostal = clienteDTO.codPostal;
            cliente.fechaDeNacimiento = clienteDTO.fechaDeNacimiento;
            return cliente;
        }
    }

}
