using DAO.GenericDAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAOImp
{
    public class SucursalDAO : GenericDAO<Sucursal>
    {
        public int saveSucursal(Sucursal sucursal)
        {
            //          using (var command = new SqlCommand("INSERT INTO NO_TENGO_IDEA.SUCURSAL " +
            //                                "(SUCURSAL_NOMBRE,SUCURSAL_DIRECCION,SUCURSAL_NRO_PISO,SUCURSAL_DEPTO,SUCURSAL_LOCALIDAD,SUCURSAL_COD_POSTAL,SUCURSAL_HABILITADO) " +
            //                                    "VALUES (@NOMBRE,@DIRECCION,@NRO_PISO,@DEPTO,@LOCALIDAD,@COD_POSTAL,@HABILITADO)"))
           
            using (var command = new SqlCommand("INSERT INTO NO_TENGO_IDEA.Sucursal " +
                                    "(sucu_nom,sucu_dire,sucu_cp,sucu_inactive) " +
                                    "VALUES (@NOMBRE,@DIRECCION,@COD_POSTAL,@HABILITADO)"))
                                                                                
          {
                command.Parameters.AddWithValue("@NOMBRE", sucursal.nombre);
                command.Parameters.AddWithValue("@DIRECCION", sucursal.direccion);
                //             command.Parameters.AddWithValue("@NRO_PISO", sucursal.nroPiso);
                //            command.Parameters.AddWithValue("@DEPTO", sucursal.departamento);
                //            command.Parameters.AddWithValue("@LOCALIDAD", sucursal.localidad);
                command.Parameters.AddWithValue("@COD_POSTAL", sucursal.codPostal);
                command.Parameters.AddWithValue("@HABILITADO", sucursal.habilitado);
                return save(command);
            }
        }

    }

}
