using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.UTILS
{
    public class Validator
    {

        private readonly static String MODIFICAR_COLUMN = "ModificarColumn";
        private readonly static String BAJAR_COLUMN = "BajarColumn";
        private readonly static String ELIMINAR_COLUMN = "EliminarColumns";
        private readonly static String MSG_INTEGERP_VALIDATION = "EL CAMPO {0} TIENE QUE SER ENTERO POSITIVO";
        private readonly static String MSG_MAIL_VALIDATION = "EL MAIL {0} ES INVALIDO";
        private readonly static String MSG_OBLIGATORY_VALIDATION = "EL CAMPO {0} ES OBLIGATORIO";

        public static Boolean isSelectedModificarColumn(DataGridView dataGridView, int columnIndex)
        {
            return dataGridView.Columns[columnIndex].Name.Equals(MODIFICAR_COLUMN);
        }

        public static Boolean isSelectedBajarColumn(DataGridView dataGridView, int columnIndex)
        {
            return dataGridView.Columns[columnIndex].Name.Equals(BAJAR_COLUMN);
        }

        public static Boolean isSelectedEliminarColumn(DataGridView dataGridView, int columnIndex)
        {
            return dataGridView.Columns[columnIndex].Name.Equals(ELIMINAR_COLUMN);
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
                        MessageBox.Show(String.Format(MSG_INTEGERP_VALIDATION, message));
                    }
                }
                else
                {
                    MessageBox.Show(String.Format(MSG_INTEGERP_VALIDATION, message));
                }
            }
            return number;
        }

        public static Boolean validatePositiveIntegerTextBox(TextBox textBox, String message,String sd)
        {
            Boolean result = true;
            Int32 number = -1;
            if (!String.IsNullOrWhiteSpace(textBox.Text))
            {
                if (int.TryParse(textBox.Text, out number))
                {
                    if (number < 0)
                    {
                        MessageBox.Show(String.Format(MSG_INTEGERP_VALIDATION, message));
                        result = false;
                    }
                }
                else
                {
                    MessageBox.Show(String.Format(MSG_INTEGERP_VALIDATION, message));
                    result = false;
                }
            }
            return result;
        }

        public static Boolean validateMailTextBox(TextBox textBox)
        {
            try
            {
                MailAddress m = new MailAddress(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format(MSG_MAIL_VALIDATION, textBox.Text));
                return false;
            }
        }

        public static Boolean validateEmptyTextBox(TextBox textBox,String message)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show(String.Format(MSG_OBLIGATORY_VALIDATION, message));
                return false;
            }
            return true;
        }


        public static Boolean dateIsLessThanSystemDate(DateTime dateTime) {
            DateTime systemTime = GlobalUtils.getHoraDelSistemaDateTime();
            int res = DateTime.Compare(dateTime, systemTime);
            return res <= 0;
        }

    
    }

}
