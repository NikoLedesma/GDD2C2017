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

    public class BusinessFacturaImpl
    {
        public int saveFactura(FacturaDTO facturaDTO)
        {
            FacturaDAO facturaDAO = new FacturaDAO();
            Factura factura = converterFacturaDTOToFactura(facturaDTO);
            return facturaDAO.saveFactura(factura);
        }

        public Factura converterFacturaDTOToFactura(FacturaDTO facturaDTO)
        {
            Factura factura = new Factura();
            factura.cliente = facturaDTO.cliente;
            factura.empresa = facturaDTO.empresa;
            factura.nroFact = facturaDTO.nroFact;
            factura.fechaDeAlta = facturaDTO.fechaDeAlta;
            factura.fechaDeVencimiento = facturaDTO.fechaDeVencimiento; 
            factura.total = facturaDTO.total;
            
            return factura;
        }

    }

}
