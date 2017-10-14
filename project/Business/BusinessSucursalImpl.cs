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
    public class BusinessSucursalImpl
    {

        public int saveSucursal(SucursalDTO sucursalDTO)
        {
            SucursalDAO sucursalDAO = new SucursalDAO();
            Sucursal sucursal = converterSucursalDTOToSucursal(sucursalDTO);
            return sucursalDAO.saveSucursal(sucursal);
        }

        public Sucursal converterSucursalDTOToSucursal(SucursalDTO sucursalDTO)
        {
            Sucursal sucursal = new Sucursal();
            sucursal.nombre = sucursalDTO.nombre;
            sucursal.direccion = sucursalDTO.direccion;
            //          sucursal.nroPiso = sucursalDTO.nroPiso;
            //          sucursal.departamento = sucursalDTO.departamento;
            //          sucursal.localidad = sucursalDTO.localidad;
            sucursal.codPostal = sucursalDTO.codPostal;
            return sucursal;
        }

    }

}
