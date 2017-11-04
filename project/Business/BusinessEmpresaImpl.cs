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
    public class BusinessEmpresaImpl
    {

        public int saveEmpresa(EmpresaDTO empresaDTO)
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            Empresa empresa = converterEmpresaDTOToEmpresa(empresaDTO);
            int a = empresaDAO.saveEmpresa(empresa);
            return a;
        }

        public Empresa converterEmpresaDTOToEmpresa(EmpresaDTO empresaDTO)
        {
            Empresa empresa = new Empresa();
            empresa.id = empresaDTO.id;
            empresa.nombre = empresaDTO.nombre;
            empresa.direccion = empresaDTO.direccion;
            empresa.rubro = empresaDTO.rubro;
            empresa.habilitado = empresaDTO.habilitado;
            empresa.cuit = empresaDTO.cuit;
            empresa.fechaRendicion = empresaDTO.fechaRendicion;
            return empresa;
        }
        public List<EmpresaDTO> getEmpresas() //trae las todas las empresas
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            List<EmpresaDTO> empresaDTOList = new List<EmpresaDTO>();
            List<Empresa> empresaList = new List<Empresa>();
            empresaList = empresaDAO.getAll().ToList();
            empresaList.ForEach(x => { empresaDTOList.Add(converterEmpresaToEmpresaDTO(x)); });
            return empresaDTOList;
        }
        public EmpresaDTO converterEmpresaToEmpresaDTO(Empresa empresa)
        {
            EmpresaDTO empresaDTO = new EmpresaDTO();
            empresaDTO.id = empresa.id;
            empresaDTO.nombre = empresa.nombre;
            empresaDTO.direccion = empresa.direccion;
            empresaDTO.rubro = empresa.rubro;
            empresaDTO.habilitado = empresa.habilitado;
            empresaDTO.cuit = empresa.cuit;
            empresaDTO.fechaRendicion = empresa.fechaRendicion;
            return empresaDTO;
        }

        public List<EmpresaDTO> getEmpresasByFilter(EmpresaDTO empresaDTO)
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            List<EmpresaDTO> empresaDTOList = new List<EmpresaDTO>();
            List<Empresa> empresaList = new List<Empresa>();
            empresaList = empresaDAO.getAllByUsername(empresaDTO.nombre, empresaDTO.cuit, empresaDTO.rubro).ToList();
            empresaList.ForEach(x => { empresaDTOList.Add(converterEmpresaToEmpresaDTO(x)); });
            return empresaDTOList;
        }

        public int updateEmpresa(EmpresaDTO empresaDTO)
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            Empresa empresa = converterEmpresaDTOToEmpresa(empresaDTO);
            return empresaDAO.updateEmpresa(empresa);
        }

        public int deleteEmpresa(EmpresaDTO empresaDTO)
        {
            empresaDTO.habilitado = true; //va true porq en base de datos esta como inactiva el campo
            EmpresaDAO empresaDAO = new EmpresaDAO();
            Empresa empresa = converterEmpresaDTOToEmpresa(empresaDTO);
            int a = empresaDAO.deleteEmpresa(empresa);
            return a;
        }

        public bool ifFechaRendicionIgual(EmpresaDTO empresaDTO)
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            Empresa empresa = converterEmpresaDTOToEmpresa(empresaDTO);
            int res = empresaDAO.getFechaRendicion(empresa);
          //  MessageBox.Show("el resu de fech rendicion es", res);
       //ACA TENGO QUE PONER LAS POSIBILIDADES aca no estoy comparando solo por dia 
            return res >= 1 ? true : false;

        }
                
    }

}
