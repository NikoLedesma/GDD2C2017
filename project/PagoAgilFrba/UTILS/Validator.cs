using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.UTILS
{
    public class Validator
    {

        private readonly static String MODIFICAR_COLUMN = "ModificarColumn";
        private readonly static String BAJAR_COLUMN = "BajarColumn";
        private readonly static String MSG_DNI_VALIDATION = "EL CAMPO {0} TIENE QUE SER ENTERO POSITIVO";





        public static Boolean isSelectedModificarColumn(DataGridView dataGridView, int columnIndex)
        {
            return dataGridView.Columns[columnIndex].Name.Equals(MODIFICAR_COLUMN);
        }

        public static Boolean isSelectedBajarColumn(DataGridView dataGridView, int columnIndex)
        {
            return dataGridView.Columns[columnIndex].Name.Equals(BAJAR_COLUMN);
        }

        public static Int32 validatePositiveIntegerTextBox(TextBox textBox, String message)
        {
            Int32 number = -1;
            if (!String.IsNullOrWhiteSpace(textBox.Text))
            {
                if (int.TryParse(textBox.Text, out number))
                {
                    if (number < 0)
                    {
                        MessageBox.Show(String.Format(MSG_DNI_VALIDATION, message));
                    }
                }
                else
                {
                    MessageBox.Show(String.Format(MSG_DNI_VALIDATION, message));
                }
            }
            return number;
        }






    }
}
