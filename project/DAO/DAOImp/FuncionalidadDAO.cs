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
    public class FuncionalidadDAO : GenericDAO<Funcionalidad>
    {
        public IEnumerable<Funcionalidad> getFuncionalidadByRolId(int rolID)
        {
            using (var command = new SqlCommand("SELECT F.ID, F.NOMBRE FROM NO_TENGO_IDEA.FUNCIONALIDAD F INNER JOIN "+
                "NO_TENGO_IDEA.ROLXFUNCIONALIDAD RF ON F.ID = RF.FUNCIONALIDAD_ID WHERE RF.ROL_ID = @ROLID "))
            {
                command.Parameters.AddWithValue("@ROLID", rolID);
                return GetRecords(command);
            }
        }


        public IEnumerable<Funcionalidad> getFuncionalidadByRolName(String rolName)
        {
            using (var command = new SqlCommand("SELECT F.ID, F.NOMBRE FROM NO_TENGO_IDEA.FUNCIONALIDAD F " +
                "INNER JOIN NO_TENGO_IDEA.ROLXFUNCIONALIDAD RF ON F.ID = RF.FUNCIONALIDAD_ID " +
                "INNER JOIN  NO_TENGO_IDEA.ROL R ON R.ID = RF.ROL_ID WHERE R.NOMBRE = @ROLNAME "))
            {
                command.Parameters.AddWithValue("@ROLNAME", rolName);
                return GetRecords(command);
            }
        }



        public IEnumerable<Funcionalidad> getFuncionalidadNotAddedByRolName(String rolName)
        {
            using (var command = new SqlCommand("SELECT F.ID, F.NOMBRE FROM NO_TENGO_IDEA.FUNCIONALIDAD F EXCEPT "+
                "SELECT F.ID, F.NOMBRE FROM NO_TENGO_IDEA.FUNCIONALIDAD F " +
                "INNER JOIN NO_TENGO_IDEA.ROLXFUNCIONALIDAD RF ON F.ID = RF.FUNCIONALIDAD_ID " +
                "INNER JOIN  NO_TENGO_IDEA.ROL R ON R.ID = RF.ROL_ID WHERE R.NOMBRE = @ROLNAME "))
            {
                command.Parameters.AddWithValue("@ROLNAME", rolName);
                return GetRecords(command);
            }
        }


        public override Funcionalidad PopulateRecord(SqlDataReader reader)
        {
            Funcionalidad funcionalidad = new Funcionalidad();
            funcionalidad.id = reader.GetInt32(0);
            funcionalidad.Nombre = reader.GetString(1);
            return funcionalidad;
        }



    }
}