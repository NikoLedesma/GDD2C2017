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
    public class BusinessEmpresaImpl
    {

        public int saveEmpresa(EmpresaDTO empresaDTO)
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            Empresa empresa = converterEmpresaDTOToEmpresa(empresaDTO);
            return empresaDAO.saveEmpresa(empresa);
        }

        public Empresa converterEmpresaDTOToEmpresa(EmpresaDTO empresaDTO)
        {
            Empresa empresa = new Empresa();
            empresa.nombre = empresaDTO.nombre;
            empresa.cuit = empresaDTO.cuit;
            empresa.direccion = empresaDTO.direccion;
            empresa.rubro = empresaDTO.rubro;
            return empresa;
        }
                
    }

}
