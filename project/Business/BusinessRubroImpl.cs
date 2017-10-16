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
    public class BusinessRubroImpl
    {
        public List<RubroDTO> getRubros()
        {
            RubroDAO rubroDAO = new RubroDAO();
            List<RubroDTO> rubroDTOList = new List<RubroDTO>();
            List<Rubro> rubroList = new List<Rubro>();
            rubroList = rubroDAO.getAllRubros().ToList();
            rubroList.ForEach(x => { rubroDTOList.Add(converterRubroToRubroDTO(x)); });
            return rubroDTOList;

        }
        public Rubro converterRubroDTOToRubro(RubroDTO rubroDTO)
        {
            Rubro rubro = new Rubro();
            rubro.id = rubroDTO.id;
            rubro.nombre = rubroDTO.nombre;
            return rubro;
        }
        public RubroDTO converterRubroToRubroDTO(Rubro rubro)
        {
            RubroDTO rubroDTO = new RubroDTO();
            rubroDTO.id = rubro.id;
            rubroDTO.nombre = rubro.nombre;
            return rubroDTO;
        }


        /*        public List <ClienteDTO> getClientesByFilter(ClienteDTO clienteDTO){
            ClienteDAO clienteDAO = new ClienteDAO();
            List <ClienteDTO> clienteDTOList =  new List<ClienteDTO>();
            List <Cliente> clienteList = new List<Cliente>();
            clienteList = clienteDAO.getAllByUsername(clienteDTO.nombre,clienteDTO.apellido,clienteDTO.dni).ToList();
            clienteList.ForEach(x => { clienteDTOList.Add(converterClienteToClienteDTO(x));});
            return clienteDTOList;
        }*/
    }
}
