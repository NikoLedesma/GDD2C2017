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
