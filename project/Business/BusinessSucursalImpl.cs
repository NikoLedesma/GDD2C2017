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
            sucursal.codPostal = sucursalDTO.codPostal;
            return sucursal;
        }

        public int updateSucursal(SucursalDTO sucursalDTO)
        {
            SucursalDAO sucursalDAO = new SucursalDAO();
            Sucursal sucursal = converterSucursalDTOToSucursal(sucursalDTO);
            return sucursalDAO.updateSucursal(sucursal);
        }


        public List<SucursalDTO> getSucursalesByFilter(SucursalDTO sucursalDTO)
        {
            SucursalDAO sucursalDAO = new SucursalDAO();
            List<SucursalDTO> sucursalDTOList = new List<SucursalDTO>();
            List<Sucursal> sucursalList = new List<Sucursal>();
            sucursalList = sucursalDAO.getAllByUsername(sucursalDTO.nombre, sucursalDTO.direccion, sucursalDTO.codPostal).ToList();
            sucursalList.ForEach(x => { sucursalDTOList.Add(converterSucursalToSucursalDTO(x)); });
            return sucursalDTOList;
        }
        public List<SucursalDTO> getAllSucursal()
        {
            SucursalDAO sucursalDAO = new SucursalDAO();
            List<SucursalDTO> sucursalDTOList = new List<SucursalDTO>();
            List<Sucursal> sucursalList = new List<Sucursal>();
            sucursalList = sucursalDAO.getAll().ToList();
            sucursalList.ForEach(x => { sucursalDTOList.Add(converterSucursalToSucursalDTO(x)); });
            return sucursalDTOList;
        }

        public SucursalDTO converterSucursalToSucursalDTO(Sucursal sucursal)
        {
            SucursalDTO sucursalDTO = new SucursalDTO();
            sucursalDTO.id = sucursal.id;
            sucursalDTO.nombre = sucursal.nombre;
            sucursalDTO.direccion = sucursal.direccion;
            sucursalDTO.codPostal = sucursal.codPostal;
            sucursalDTO.habilitado = sucursal.habilitado;
            return sucursalDTO;
        }



    }

}
