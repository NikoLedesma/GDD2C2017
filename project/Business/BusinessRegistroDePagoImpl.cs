using DAO.DAOImp;
using DTO;
using DTO.Enums;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessRegistroDePagoImpl
    {



        public FacturaDTO getFacturaByNroFactura(int nroFactura) {
            FacturaDAO facturaDAO = new FacturaDAO();
            Factura factura = facturaDAO.getFacturaById(nroFactura);
            return convertFacturaToFacturaDTO(factura);
        }

        public ResultCheckFactura verifiedFacturaById(int nroFactura)
        {
            FacturaDAO facturaDAO = new FacturaDAO();
            int res = facturaDAO.verifiedFacturaById( nroFactura );
            return (ResultCheckFactura) res;
        }


        public List <MedioDePagoDTO> getAllMediosDePagos(){
            MedioDePagoDAO medioDePagoDAO = new MedioDePagoDAO();
            List<MedioDePagoDTO> medioDePagoDTOList = new List<MedioDePagoDTO>();
            List<MedioDePago> medioDePagoList =  medioDePagoDAO.getAllMediosDePago().ToList();
            medioDePagoList.ForEach(x => { medioDePagoDTOList.Add(new MedioDePagoDTO(x.id,x.nombre)); });
            return medioDePagoDTOList;
        }


        public int registrarPagos(RegistroDePagoDTO registroDePagoDTO)
        {
            RegistroDePagoDAO registroDePagoDAO = new RegistroDePagoDAO();
            RegistroDePago registroDePago = converterRegistroDePagoDTOToRegistroDePago(registroDePagoDTO);
            try
            {
                int resSavePago = registroDePagoDAO.savePago(registroDePago);
                if (resSavePago == 1)
                {
                    registroDePago.facturas.ForEach(factura => { registroDePagoDAO.saveFacturaToPago(factura, registroDePago.numero); });
                }
                else {
                    return -1;
                }
            }catch(Exception){
                return -1;
            }
            return 1;
        }


        private RegistroDePago converterRegistroDePagoDTOToRegistroDePago(RegistroDePagoDTO registroDePagoDTO)
        {
            RegistroDePago registroDePago = new RegistroDePago();
            registroDePago.id = registroDePagoDTO.id;
            registroDePago.medioDePago = new MedioDePago();
            registroDePago.medioDePago.id = registroDePagoDTO.medioDePagoDTO.id;
            registroDePago.medioDePago.nombre = registroDePagoDTO.medioDePagoDTO.nombre;
            registroDePago.importe = registroDePagoDTO.importe;
            registroDePago.numero = registroDePagoDTO.numero;
            List<Factura> facturasList = new List<Factura>();
            registroDePagoDTO.facturasDTO.ForEach(x => { facturasList.Add(converterFacturaDTOToFactura(x)); });
            registroDePago.facturas = facturasList;
            return registroDePago;
        }


        private FacturaDTO convertFacturaToFacturaDTO(Factura factura)
        {
            FacturaDTO facturaDTO = new FacturaDTO();
            facturaDTO.id = factura.id;
            facturaDTO.cliente = factura.cliente;
            facturaDTO.empresa = factura.empresa;
            facturaDTO.nroFact = factura.nroFact;
            facturaDTO.fechaDeAlta = factura.fechaDeAlta;
            facturaDTO.fechaDeVencimiento = factura.fechaDeVencimiento;
            facturaDTO.total = factura.total;
            facturaDTO.fechaDeDevolucion = factura.fechaDevolucion;
            return facturaDTO;
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
            factura.fechaDevolucion = facturaDTO.fechaDeDevolucion;
            return factura;
        }


    }
}
