using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.UTILS
{
    public class Validator
    {

        private readonly static String MODIFICAR_COLUMN = "ModificarColumn";
        private readonly static String BAJAR_COLUMN = "BajarColumn";
        private readonly static String ELIMINAR_COLUMN = "EliminarColumn";
        private readonly static String MSG_INTEGERP_VALIDATION = "EL CAMPO {0} TIENE QUE SER ENTERO POSITIVO";
        private readonly static String MSG_MAIL_VALIDATION = "EL MAIL {0} ES INVALIDO";

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

        public static Boolean validatePositiveIntegerTextBoxBool(TextBox textBox, String message)
        {
            Boolean result = true;
            Int32 number = -1;
            if (!String.IsNullOrWhiteSpace(textBox.Text))
            {
                if (int.TryParse(textBox.Text, out number))
                {
                    if (number <= 0)
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
        public static Boolean validatePositiveFloatTextBoxBool(TextBox textBox, String message)
        {
            Boolean result = true;
            Int32 number = -1;
            if (!String.IsNullOrWhiteSpace(textBox.Text))
            {   
                float convField = Convert.ToSingle(textBox.Text);
                if (convField <= 0)
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

        public static Boolean validateEmptyTextBox(TextBox textBox, String message)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show(String.Format(MSG_OBLIGATORY_VALIDATION, message));
                return false;
            }
            return true;
        }


        public static Boolean dateIsLessThanSystemDate(DateTime dateTime)
        {
            DateTime systemTime = GlobalUtils.getHoraDelSistemaDateTime();
            int res = DateTime.Compare(dateTime, systemTime);
            return res <= 0;
        }



        private static String MSG_EMPTY_FIELD = "EL CAMPO {0} ESTA VACIO";
        private static String MSG_OBLIGATORY_VALIDATION = "EL CAMPO {0} ES OBLIGATORIO";
        private static String MSG_ONLY_LETTERS = "EN EL CAMPO {0} SOLO SE PERMITEN INGRESAR LETRAS";
        private static String MSG_ONLY_INTEGERS = "EN EL CAMPO {0} SOLO SE PERMITEN INGRESAR NUMEROS ENTEROS";

        public static List<String> addMsgIfEmpty(List<String> message, String textValue, String textLabel)
        {
            if (String.IsNullOrEmpty(textValue))
            {
                string msg = String.Format(MSG_OBLIGATORY_VALIDATION, textLabel);
                message.Add(msg);
            }
            return message;
        }


        public static List<String> addMsgIfNotInteger(List<String> message, String textValue, String textLabel)
        {
            if (!isPositiveInteger(textValue))
            {
                string msg = String.Format(MSG_ONLY_INTEGERS, textLabel);
                message.Add(msg);
            }
            return message;
        }

        public static List<String> addMsgIfNotLetters(List<String> message, String textValue, String textLabel)
        {
            if (!onlyLetters(textValue))
            {
                string msg = String.Format(MSG_ONLY_LETTERS, textLabel);
                message.Add(msg);
            }
            return message;
        }

        private static Boolean isPositiveInteger(String text)
        {
            Boolean result = true;
            Int32 number = -1;
            if (int.TryParse(text, out number))
            {
                if (number < 0)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }


        private static Boolean onlyLetters(String text)
        {
            Boolean res = Regex.IsMatch(text, @"^[a-zA-Z]+$");
            return res;
        }




        public static Boolean verifiedIfIsOk(List<string> msgErrors, string titleText)
        {    
            if(msgErrors.Count>0){
                string delimiter = "\n";
                String message = msgErrors.Aggregate((i, j) => i + delimiter + j);
                MessageBox.Show(message, titleText);
            }
            return msgErrors.Count >= 0 ? true : false;
        }
    }

}
