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
    public class BusinessDevolucionImpl
    {
        public int saveDevolucion(DevolucionDTO devolucionDTO)
        {
            DevolucionDAO devolucionDAO = new DevolucionDAO();
            Devolucion devolucion = converterDevolucionDTOToDevolucion(devolucionDTO);
            return devolucionDAO.saveDevolucion(devolucion);
        }
        public Devolucion converterDevolucionDTOToDevolucion(DevolucionDTO devolucionDTO)
        {
            Devolucion devolucion = new Devolucion();
            devolucion.id = devolucionDTO.id;
            devolucion.razon = devolucionDTO.razon;
            devolucion.idRendicion = devolucionDTO.idRendicion;
            devolucion.idFact = devolucionDTO.idFact;
            return devolucion;
        }
    }

}
