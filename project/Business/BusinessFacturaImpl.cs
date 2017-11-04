using DAO.DAOImp;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
            factura.id = facturaDTO.id;
            factura.cliente = facturaDTO.cliente;
            factura.empresa = facturaDTO.empresa;
            factura.nroFact = facturaDTO.nroFact;
            factura.fechaDeAlta = facturaDTO.fechaDeAlta;
            factura.fechaDeVencimiento = facturaDTO.fechaDeVencimiento; 
            factura.total = facturaDTO.total;
            factura.items = facturaDTO.items;
            factura.habilitado = facturaDTO.habilitado;
            return factura;
        }

        public List<string> getTrimestres()
        {
            FacturaDAO facturaDAO = new FacturaDAO();
            return facturaDAO.getAllTrimestres();
        }
        public List<ListStadisticoDTO> getPorcFactCobradas(string trimestre)
        {
            ListEstadisticoDAO listEstadisticoDAO = new ListEstadisticoDAO();

            List<ListStadisticoDTO> listEstadisticoDTO = new List<ListStadisticoDTO>();
            List<ListEstadistico> facturaList = new List<ListEstadistico>();
            facturaList = listEstadisticoDAO.getAllPorcFactCobradas(trimestre).ToList();
            facturaList.ForEach(x => { listEstadisticoDTO.Add(converterListEstadisticoToDTO(x)); });
            return listEstadisticoDTO;
        }
        public ListStadisticoDTO converterListEstadisticoToDTO(ListEstadistico listEstadistico)
        {
            ListStadisticoDTO listEstadisticoDTO = new ListStadisticoDTO();
            listEstadisticoDTO.id = listEstadistico.id;
            listEstadisticoDTO.total = listEstadistico.total;
            listEstadisticoDTO.cuit = listEstadistico.cuit;
            listEstadisticoDTO.nombre = listEstadistico.nombre;
            return listEstadisticoDTO;
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

        public List<FacturaDTO> getFacturaByFilterRendicion(FacturaDTO facturaDTO)
        {
            FacturaDAO facturaDAO = new FacturaDAO();
            List<FacturaDTO> facturaDTOList = new List<FacturaDTO>();
            List<Factura> facturaList = new List<Factura>();
            facturaList = facturaDAO.getAllFactARendir(facturaDTO.empresa).ToList();
            facturaList.ForEach(x => { facturaDTOList.Add(converterFacturaToFacturaDTO(x)); });
            
            return facturaDTOList;
        }
        public List<FacturaDTO> getFacturaByClientAndEmpresa(int cliente, int empresa)
        {
            FacturaDAO facturaDAO = new FacturaDAO();
            List<FacturaDTO> facturaDTOList = new List<FacturaDTO>();
            List<Factura> facturaList = new List<Factura>();
            facturaList = facturaDAO.getAllByUsername(cliente, empresa).ToList();
            facturaList.ForEach(x => { facturaDTOList.Add(converterFacturaToFacturaDTO(x)); });

            return facturaDTOList;
        }
        public List<ItemFacturaDTO> getItems(int facturaId) //trae las todas las empresas
        {
            ItemFacturaDAO itemFacturaDAO = new ItemFacturaDAO();

            List<ItemFacturaDTO> ItemFacturaDTOList = new List<ItemFacturaDTO>();
            List<ItemFactura> itemsList = new List<ItemFactura>();

            itemsList = itemFacturaDAO.getAllItems(facturaId).ToList();

            itemsList.ForEach(x => { ItemFacturaDTOList.Add(converterItemToItemDTO(x)); });
            return ItemFacturaDTOList;
        }
        public ItemFacturaDTO converterItemToItemDTO(ItemFactura item)
        {
            ItemFacturaDTO itemDTO = new ItemFacturaDTO();
            itemDTO.id = item.id;
            itemDTO.cantidad = item.cantidad;
            itemDTO.monto = item.monto;
            return itemDTO;
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
            facturaDTO.nroFact = factura.nroFact;
            facturaDTO.total = factura.total;
            facturaDTO.items = factura.items;
            return facturaDTO;
        }

    }

}
