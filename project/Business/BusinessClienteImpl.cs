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

        public int updateCliente(ClienteDTO clienteDTO)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            Cliente cliente = converterClienteDTOToCliente(clienteDTO);
            return clienteDAO.updateCliente(cliente);
        }

        public List <ClienteDTO> getClientesByFilter(ClienteDTO clienteDTO){
            ClienteDAO clienteDAO = new ClienteDAO();
            List <ClienteDTO> clienteDTOList =  new List<ClienteDTO>();
            List <Cliente> clienteList = new List<Cliente>();
            clienteList = clienteDAO.getAllByUsername(clienteDTO.nombre,clienteDTO.apellido,clienteDTO.dni).ToList();
            clienteList.ForEach(x => { clienteDTOList.Add(converterClienteToClienteDTO(x));});
            return clienteDTOList;
        }

        public Cliente converterClienteDTOToCliente(ClienteDTO clienteDTO)
        {
            Cliente cliente = new Cliente();
            cliente.id = clienteDTO.id;
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
            cliente.habilitado = cliente.habilitado;
            return cliente;
        }


        public ClienteDTO converterClienteToClienteDTO(Cliente cliente)
        {
            ClienteDTO clienteDTO = new ClienteDTO();
            clienteDTO.id = cliente.id;
            clienteDTO.nombre = cliente.nombre;
            clienteDTO.apellido = cliente.apellido;
            clienteDTO.dni = cliente.dni;
            clienteDTO.mail = cliente.mail;
            clienteDTO.nroTelefono = cliente.nroTelefono;
            clienteDTO.direccion = cliente.direccion;
            clienteDTO.nroPiso = cliente.nroPiso;
            clienteDTO.departamento = cliente.departamento;
            clienteDTO.localidad = cliente.localidad;
            clienteDTO.codPostal = cliente.codPostal;
            clienteDTO.fechaDeNacimiento = cliente.fechaDeNacimiento;
            clienteDTO.habilitado = cliente.habilitado;
            return clienteDTO;
        }





    }

}
