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
    public class BusinessRendicionImpl
    {

        public int saveRendicion(RendicionDTO rendicionDTO)
        {
            RendicionDAO rendicionDAO = new RendicionDAO();
            Rendicion rendicion = converterRendicionDTOToRendicion(rendicionDTO);
            return rendicionDAO.saveRendicion(rendicion);
        }
        public List<RendicionDTO> getRendByEmpresa(int empresaId)
        {

            RendicionDAO rendicionDAO = new RendicionDAO();
            List<RendicionDTO> listRendDTO = new List<RendicionDTO>();
            List<Rendicion> rendicionList = new List<Rendicion>();

            rendicionList = rendicionDAO.getRendicionByEmpresa(empresaId).ToList();
            rendicionList.ForEach(x => { listRendDTO.Add(converterRendToRendDTO(x)); });

            return listRendDTO;
        }
        public RendicionDTO converterRendToRendDTO(Rendicion rendicion)
        {
            RendicionDTO rendicionDTO = new RendicionDTO();
            rendicionDTO.id = rendicionDTO.id;
            rendicionDTO.fecha = rendicionDTO.fecha;
            rendicionDTO.importe = rendicionDTO.importe;
            //    rendicion.numero = rendicionDTO.numero;
            rendicionDTO.porcentaje = rendicionDTO.porcentaje;
            rendicionDTO.idFact = rendicionDTO.idFact;
            return rendicionDTO;
        }
        public Rendicion converterRendicionDTOToRendicion(RendicionDTO rendicionDTO)
        {
            Rendicion rendicion = new Rendicion();
            rendicion.id = rendicionDTO.id;
            rendicion.fecha = rendicionDTO.fecha;
            rendicion.importe = rendicionDTO.importe;
        //    rendicion.numero = rendicionDTO.numero;
            rendicion.porcentaje = rendicionDTO.porcentaje;
            rendicion.idFact = rendicionDTO.idFact;
            return rendicion;
        }


    }
}
