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
            factura.items = facturaDTO.items;
            return factura;
        }
        public List<FacturaDTO> getFacturaByFilter(FacturaDTO facturaDTO)
        {
            FacturaDAO facturaDAO = new FacturaDAO();
            List<FacturaDTO> facturaDTOList = new List<FacturaDTO>();
            List<Factura> facturaList = new List<Factura>();
            facturaList = facturaDAO.getAllByUsername(facturaDTO.cliente, facturaDTO.empresa).ToList();
            facturaList.ForEach(x => { facturaDTOList.Add(converterFacturaToFacturaDTO(x)); });
            return facturaDTOList;
        }
        public FacturaDTO converterFacturaToFacturaDTO(Factura factura)
        {
            FacturaDTO facturaDTO = new FacturaDTO();
            facturaDTO.id = factura.id;
            facturaDTO.cliente = factura.cliente;
            facturaDTO.empresa = factura.empresa;
            facturaDTO.habilitado = factura.habilitado;
            facturaDTO.fechaDeAlta = factura.fechaDeAlta;
            facturaDTO.fechaDeVencimiento = factura.fechaDeVencimiento;
            facturaDTO.total = factura.total;
            facturaDTO.items = factura.items;
            return facturaDTO;
        }

    }

}
