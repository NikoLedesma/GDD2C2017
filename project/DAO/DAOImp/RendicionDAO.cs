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
    public class RendicionDAO: GenericDAO<Rendicion>
    {

        public int saveRendicion(Rendicion rendicion)
        {
            using (var command = new SqlCommand("INSERT INTO NO_TENGO_IDEA.Rendicion " +
                        "(rend_fecha,rend_importe,rend_porcentaje) " +
                        "VALUES (@FECHA,@IMPORTE,@PORCENTAJE)"))
            {
                command.Parameters.AddWithValue("@FECHA", rendicion.fecha);
                command.Parameters.AddWithValue("@IMPORTE", rendicion.importe);
                command.Parameters.AddWithValue("@PORCENTAJE", rendicion.porcentaje);
 
                return save(command);
            }

        }


        public override Rendicion PopulateRecord(SqlDataReader reader)
        {
            Rendicion rendicion = new Rendicion();
            if (!reader.IsDBNull(0))
                rendicion.id = reader.GetInt32(0);
            if (!reader.IsDBNull(1))
                rendicion.fecha = reader.GetDateTime(1);
            if (!reader.IsDBNull(2))
                rendicion.importe = reader.GetFloat(2);
     //       if (!reader.IsDBNull(3))
     //           rendicion.numero = reader.GetInt32(3);
            if (!reader.IsDBNull(4))
                rendicion.porcentaje = reader.GetFloat(4); 
            return rendicion;
        }

    }
}
