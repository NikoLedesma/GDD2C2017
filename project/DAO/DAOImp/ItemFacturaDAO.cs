using DAO.GenericDAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAO.DAOImp
{
    public class ItemFacturaDAO : GenericDAO<ItemFactura>
    {
        public IEnumerable<ItemFactura> getAllItems(int facturaId)
        {

            String str = "";
            if (facturaId > 0) { str += " AND item_factura = @FACTURA "; }



            using (var command = new SqlCommand("SELECT [item_id],[item_monto], [item_cantidad] " +
                          "FROM  NO_TENGO_IDEA.Item WHERE 1=1 " + str))
            {
                if (facturaId > 0) { command.Parameters.AddWithValue("@FACTURA", facturaId); }

                return GetRecords(command);
            }

        }
        public override ItemFactura PopulateRecord(SqlDataReader reader)
        {
            ItemFactura item = new ItemFactura();
            if (!reader.IsDBNull(0))
                item.id = reader.GetInt32(0);
            if (!reader.IsDBNull(1))
            {
                float readerResult = (float)reader.GetDouble(1);
                item.monto = readerResult;
            }
            if (!reader.IsDBNull(2))
                item.cantidad = reader.GetInt32(2);
            return item;
        }
    }
}
