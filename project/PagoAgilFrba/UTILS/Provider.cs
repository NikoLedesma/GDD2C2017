using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.UTILS
{
    public class Provider
    {

        public static object getValueIdentifier(DataGridView dataGridView,int rowIndex,String identifierColumnHeader) {
            return dataGridView.Rows[rowIndex].Cells[identifierColumnHeader].Value;
        }

        public static void matchAndTurnOffColumnVisibility(DataGridViewColumnEventArgs e, String columnHeaderName)
        {
            if (e.Column.Name.Equals(columnHeaderName)) { 
                e.Column.Visible = false; 
            }
        }

        public static void matchAndTurnOnColumnReadOnly(DataGridViewColumnEventArgs e, String columnHeaderName)
        {
            if (e.Column.Name.Equals(columnHeaderName))
            {
                e.Column.ReadOnly = true;
            }
        }
    
    }

}
