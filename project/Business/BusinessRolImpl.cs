using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DTO;
using DAO.DAOImp;
namespace Business
{
    public class BusinessRolImpl
    {
        public List<RolDTO> getRolesByUsuario(UsuarioDTO usuarioDTO){
            RolDAO rolDAO = new RolDAO();
            List<Rol> listRol = null;
            List<RolDTO> listRolDTO = new List <RolDTO>();
            listRol = rolDAO.getAllByUsername(usuarioDTO.Username).ToList();
            listRol.ForEach(x => { listRolDTO.Add(new RolDTO(x.Nombre, x.Habilitado)); });
            return listRolDTO;
        }


        public List<RolDTO> getEnabledRolesByUsuario(UsuarioDTO usuarioDTO)
        {
            RolDAO rolDAO = new RolDAO();
            List<Rol> listRol = null;
            List<RolDTO> listRolDTO = new List<RolDTO>();
            listRol = rolDAO.getAllByUsername(usuarioDTO.Username).ToList();
            listRol.ForEach(x => {if(x.Habilitado){listRolDTO.Add(new RolDTO(x.Nombre, x.Habilitado)); }});
            return listRolDTO;
        }




        public List<RolDTO> getAllRolesWithFunctionalidades( )
        {
            RolDAO rolDAO = new RolDAO();
            List <Rol> listRol  = rolDAO.getAll().ToList();
            List<RolDTO> listRolDTO = new List<RolDTO>();
            listRol.ForEach(rolSource => populateListRolDTO(rolSource, listRolDTO));
            return listRolDTO;
        }

        public void populateListRolDTO(Rol rolSource, List<RolDTO> listRolDTO)
        {
            FuncionalidadDAO funcionalidadDAO = new FuncionalidadDAO();
            List<Funcionalidad> listFuncionalidad = funcionalidadDAO.getFuncionalidadByRolName(rolSource.Nombre).ToList();
            List <FuncionalidadDTO> listFuncionalidadDTO = new List<FuncionalidadDTO>();
            listFuncionalidad.ForEach(x => { listFuncionalidadDTO.Add(new FuncionalidadDTO(x.Nombre)); });
            RolDTO rolDTO = new RolDTO(rolSource.Nombre, rolSource.Habilitado, listFuncionalidadDTO);
            listRolDTO.Add(rolDTO);
        }


        public List<FuncionalidadDTO> getFuncionalidadesNotAddedByRolName(string rolName)
        {
            FuncionalidadDAO funcionalidadDAO = new FuncionalidadDAO();
            List<Funcionalidad> listFuncionalidad =funcionalidadDAO.getFuncionalidadNotAddedByRolName(rolName).ToList();
            List<FuncionalidadDTO> listFuncionalidadDTO = new List<FuncionalidadDTO>();
            listFuncionalidad.ForEach(x => { listFuncionalidadDTO.Add(new FuncionalidadDTO(x.Nombre)); });
            return listFuncionalidadDTO;
        }

        public void removeFuncionalidadFromRol(SelectedFuncRolDTO selectedFuncRolDTO)
        {
            RolDAO rolDAO = new RolDAO();
            int res =rolDAO.removeFuncionalidadByRolName(selectedFuncRolDTO.NombreRol, selectedFuncRolDTO.NombreFuncionalidad);
            Console.WriteLine(res);
        }

        public void addFuncionalidadToRol(SelectedFuncRolDTO selectedFuncRolDTO)
        {
            RolDAO rolDAO = new RolDAO();
            int res = rolDAO.addFuncionalidadToRol(selectedFuncRolDTO.NombreRol,selectedFuncRolDTO.NombreFuncionalidad); ;
        }

        public List<RolDTO> deleteRol(RolDTO rolDTO)
        {
            RolDAO rolDAO = new RolDAO();
           int res = rolDAO.deleteLogicalByName(rolDTO.Nombre);
           List<RolDTO> listRolDTO = getAllRolesWithFunctionalidades();  
            return listRolDTO;
        }


        public List<RolDTO> enableRol(RolDTO rolDTO)
        {
            RolDAO rolDAO = new RolDAO();
            int res = rolDAO.addLogicalByName(rolDTO.Nombre);
            List<RolDTO> listRolDTO = getAllRolesWithFunctionalidades();
            return listRolDTO;
        }


        public int addRol(RolDTO rolDTO)
        {
            RolDAO rolDAO = new RolDAO();
            int res = rolDAO.addRol(rolDTO.Nombre);
            List<FuncionalidadDTO> listFuncionalidadDTO = rolDTO.listFuncionalidadDTO;
            listFuncionalidadDTO.ForEach(x => { rolDAO.addFuncionalidadToRol(rolDTO.Nombre, x.Nombre); });
            if (res == -1) { throw new Exception("NO MODIFICADO"); }
            return res;
        }

        public List <FuncionalidadDTO> getAllFunctionalidades(){
            FuncionalidadDAO funcionalidadDAO = new FuncionalidadDAO();
            List<Funcionalidad> listFuncionalidad = funcionalidadDAO.getAllFuncionalidades().ToList();
            List<FuncionalidadDTO> listFuncionalidadDTO = new List<FuncionalidadDTO>();
            listFuncionalidad.ForEach(x => { listFuncionalidadDTO.Add(new FuncionalidadDTO(x.Nombre)); });
            return listFuncionalidadDTO;
        }

    }
}
