﻿using DAO.GenericDAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAOImp
{
    public class EmpresaDAO : GenericDAO<Empresa>
    {
        public int saveEmpresa(Empresa empresa )
        {
            using (var command = new SqlCommand("INSERT INTO LOS_PUBERTOS.Empresa " +
                                    "(empr_nombre, empr_direccion,empr_rubro, empr_inactivo,empr_cuit,empr_fechaRendicion) " +
                                    "VALUES (@NOMBRE,@DIRECCION,@RUBRO,@HABILITADO,@CUIT,@FECHA_RENDICION)"))
            {
                command.Parameters.AddWithValue("@NOMBRE", empresa.nombre);
                command.Parameters.AddWithValue("@DIRECCION", empresa.direccion);
                command.Parameters.AddWithValue("@RUBRO", empresa.rubro);
                command.Parameters.AddWithValue("@HABILITADO", empresa.habilitado);
                command.Parameters.AddWithValue("@CUIT", empresa.cuit);
                command.Parameters.AddWithValue("@FECHA_RENDICION", empresa.fechaRendicion);
                return save(command);
            }
        }
        public IEnumerable<Empresa> getAll()
        {

            using (var command = new SqlCommand("select empr_id,empr_nombre, empr_direccion,empr_rubro, empr_inactivo,empr_cuit, empr_fechaRendicion from [LOS_PUBERTOS].Empresa"))
            {
                return GetRecords(command);
            }

            throw new NotImplementedException();
        }

        public override Empresa PopulateRecord(SqlDataReader reader)
        {
            
            Empresa empresa = new Empresa();
            if (!reader.IsDBNull(0))
                empresa.id = reader.GetInt32(0);
            if (!reader.IsDBNull(1)) 
                empresa.nombre = reader.GetString(1);
            if (!reader.IsDBNull(2)) 
                empresa.direccion = reader.GetString(2);
            if (!reader.IsDBNull(3)) 
                empresa.rubro = reader.GetInt32(3);
            if (!reader.IsDBNull(4)) 
                empresa.habilitado = reader.GetBoolean(4);
            if (!reader.IsDBNull(5)) 
                empresa.cuit = reader.GetString(5);
            if (!reader.IsDBNull(6))
                empresa.fechaRendicion = reader.GetDateTime(6);
            return empresa;
        }


        public IEnumerable<Empresa> getAllByUsername(string nombre, string cuit, int rubro) //aca tengo qe traer todos los campos
        {
            String str = "";
            if (!String.IsNullOrEmpty(nombre)) { str += " AND empr_nombre LIKE @NOMBRE + '%' "; }
            if (!String.IsNullOrEmpty(cuit)) { str += " AND empr_cuit LIKE @APELLIDO + '%' "; }
            if (rubro > 0) { str += " AND empr_rubro = @DNI "; }
            //en el comando sql capaz que puedo no traerme el id si no lo uso
            using (var command = new SqlCommand("SELECT empr_id, empr_nombre, empr_direccion, empr_rubro,empr_inactivo,empr_cuit,empr_fechaRendicion " +
                          "FROM  LOS_PUBERTOS.Empresa WHERE 1=1 " + str))
            {
                if (!String.IsNullOrEmpty(nombre)) { command.Parameters.AddWithValue("@NOMBRE", nombre); }
                if (!String.IsNullOrEmpty(cuit)) { command.Parameters.AddWithValue("@APELLIDO", cuit); }
                if (rubro > 0) { command.Parameters.AddWithValue("@DNI", rubro); }
                return GetRecords(command);
            }

           throw new NotImplementedException();
        }
     

        //falta el tener todos los campos y el update de empresa
        public IEnumerable<Empresa> update(Empresa empresa)
        {
            return null;
        }



        public int deleteEmpresa(Empresa empresa)
        {
            using (var command = new SqlCommand("UPDATE LOS_PUBERTOS.Empresa SET empr_inactivo=@HABILITADO " +
            "WHERE empr_id = @ID "))
            {
                command.Parameters.AddWithValue("@HABILITADO", empresa.habilitado);
                command.Parameters.AddWithValue("@ID", empresa.id);
                return save(command);
            }
        }


        
        public int updateEmpresa(Empresa empresa) //aca tengo que modificar todos los campos de la base de datos
        { 
              using (var command = new SqlCommand("UPDATE LOS_PUBERTOS.Empresa SET " +
                        "empr_nombre=@NOMBRE,empr_direccion=@DIRECCION,empr_cuit=@CUIT, empr_rubro=@RUBRO, empr_inactivo=@INACTIVO, empr_fechaRendicion=@FECHA_RENDICION " +
                        "WHERE empr_id = @ID "))
            {
                command.Parameters.AddWithValue("@ID", empresa.id);
                command.Parameters.AddWithValue("@NOMBRE", empresa.nombre);
                command.Parameters.AddWithValue("@DIRECCION", empresa.direccion);
                command.Parameters.AddWithValue("@CUIT", empresa.cuit);
                command.Parameters.AddWithValue("@RUBRO", empresa.rubro);
                command.Parameters.AddWithValue("@INACTIVO", empresa.habilitado);
                command.Parameters.AddWithValue("@FECHA_RENDICION", empresa.fechaRendicion);

                return save(command);
            }
    
        }


        public int getFechaRendicion(Empresa empresa) //tengo que comparar solo con el dia
        {
            using (var command = new SqlCommand("SELECT count(*) from [LOS_PUBERTOS].Empresa " +
                "WHERE DAY(empr_fechaRendicion) = DAY(@FECHA_RENDICION) AND empr_id = @ID AND empr_inactivo=1"))
            {
                command.Parameters.AddWithValue("@ID", empresa.id);
                command.Parameters.AddWithValue("@FECHA_RENDICION", empresa.fechaRendicion);
                return GetCount(command);
            }
        }
        
    }
}
