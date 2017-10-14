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
    public class EmpresaDAO : GenericDAO<Empresa>
    {
        public int saveEmpresa(Empresa empresa )
        {
            using (var command = new SqlCommand("INSERT INTO NO_TENGO_IDEA.Empresa " +
                                    "(empr_nombre,empr_cuit, empr_direccion,empr_rubro, empr_inactivo) " +
                                    "VALUES (@NOMBRE,@CUIT,@DIRECCION,@RUBRO,@HABILITADO)"))
            {
                command.Parameters.AddWithValue("@NOMBRE", empresa.nombre);
                command.Parameters.AddWithValue("@CUIT", empresa.cuit);
                command.Parameters.AddWithValue("@DIRECCION", empresa.direccion);
                command.Parameters.AddWithValue("@RUBRO", empresa.rubro);
                command.Parameters.AddWithValue("@HABILITADO", empresa.habilitado);
                return save(command);
            }
        }


    }
}
