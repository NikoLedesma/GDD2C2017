using Business;
using DTO;
using DTO.Enums;
using PagoAgilFrba.UTILS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class AltaClienteForm : Form
    {
        private Form prevForm;
        private BusinessClienteImpl businessClienteImpl;
        private EnumFormMode formMode;
        private ClienteDTO clienteDTOToUpdateOrSave;
        private static String MSG_ERROR_SAVE="ERROR:NO SE PUDO DAR DE ALTA A UN CLIENTE" ; 
        private static String MSG_ERROR_UPDATE="ERROR:NO SE PUDO ACTUALIZAR AL CLIENTE";
        private static String ALTA_TITLE = "ALTA DE CLIENTE";
        private static String MODIF_TITLE = "MODIFICACION DE CLIENTE"; //(ID:{0})";
        private static String MSG_SUCCESS_SAVE = "EL CLIENTE SE DIO DE ALTA";
        private static String MSG_SUCCESS_UPDATE = "EL CLIENTE SE MODIFICO";
        private static String MSG_EMAI_ALREADY_EXISTS= "EL EMAIL INGRESADO YA EXISTE, INTENTE INGRESANDO OTRO";

        public AltaClienteForm(Form form,EnumFormMode enumFormMode,ClienteDTO cl)
        {
            InitializeComponent();
            businessClienteImpl = new BusinessClienteImpl();
            prevForm = form;
            form.Hide();
            formMode = enumFormMode;

            if (formMode == EnumFormMode.MODE_ALTA)
            {
                this.Text = ALTA_TITLE;
                this.clienteDTOToUpdateOrSave = new ClienteDTO();
                disabledRadioButtons();
            }

            if (formMode == EnumFormMode.MODE_MODIFICACION)
            {
                //this.Text = String.Format(MODIF_TITLE, cl.id);
                this.Text = MODIF_TITLE;
                this.clienteDTOToUpdateOrSave = cl;
                populateAllInputsToModify(cl);
            }
        }

        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validateFields())
            {
                clienteDTOToUpdateOrSave=populateClienteDTOToUpdateOrSave();
                saveOrUpdateCliente(clienteDTOToUpdateOrSave);
            }
        }

        public void saveOrUpdateCliente(ClienteDTO clienteDTO)
        {
            if (formMode == EnumFormMode.MODE_ALTA)
            {
                try{
                     businessClienteImpl.saveCliente(clienteDTO);
                     MessageBox.Show(MSG_SUCCESS_SAVE);
                     this.Close();
                }catch(Exception){
                    MessageBox.Show(MSG_ERROR_SAVE);   
                }
            }

            if (formMode == EnumFormMode.MODE_MODIFICACION)
            {
                try
                {
                    businessClienteImpl.updateCliente(clienteDTO);
                    MessageBox.Show(MSG_SUCCESS_UPDATE);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(MSG_ERROR_UPDATE);
                }
            }
        }

        private Boolean validateFields()
        {
            Boolean isAnyMessageToShow = validateEmptyFields();
            Boolean isNotExistingMail = !isExistingMail(txtMail);
            /* Boolean isModeModificacion = (formMode == EnumFormMode.MODE_MODIFICACION);
             return !isAnyMessageToShow && (isNotExistingMail || isModeModificacion);*/

            return !isAnyMessageToShow && isNotExistingMail;
        }

        private Boolean validateEmptyFields()
        {
            List <String> msgError = new List<string>();
            msgError = Validator.addMsgIfEmpty(msgError ,txtNombre.Text ,"NOMBRE");
            //msgError = Validator.addMsgIfNotLetters(msgError, txtNombre.Text, "NOMBRE"); 
            msgError = Validator.addMsgIfEmpty(msgError, txtApellido.Text, "APELLIDO");
            //msgError = Validator.addMsgIfNotLetters(msgError, txtApellido.Text, "APELLIDO");
            msgError = Validator.addMsgIfEmpty(msgError, txtDNI.Text, "DNI");
            msgError = Validator.addMsgIfNotInteger(msgError, txtDNI.Text, "DNI");
            msgError = Validator.addMsgIfEmpty(msgError, txtMail.Text, "MAIL");
            msgError = Validator.addMsgIfNotEmail(msgError, txtMail.Text, "MAIL");
            msgError = Validator.addMsgIfEmpty(msgError, txtTelefono.Text, "TELEFONO");            
            msgError = Validator.addMsgIfNotInteger(msgError, txtTelefono.Text, "TELEFONO");
            msgError = Validator.addMsgIfEmpty(msgError, txtDirCalle.Text, "DIRECCION");
            msgError = Validator.addMsgIfEmpty(msgError, txtNumPiso.Text, "NRO PISO");
            msgError = Validator.addMsgIfNotInteger(msgError, txtNumPiso.Text, "NRO PISO");
            msgError = Validator.addMsgIfEmpty(msgError,txtDepartamento.Text, "DEPARTAMENTO");//TODO:validar que sea nada mas un char
            msgError = Validator.addMsgIfEmpty(msgError,txtLocalidad.Text,"LOCALIDAD");
            msgError = Validator.addMsgIfEmpty(msgError, txtCodPostal.Text, "CODIGO POSTAL");
            msgError = Validator.addMsgIfNotInteger(msgError, txtCodPostal.Text, "CODIGO POSTAL");
            return Validator.verifiedIfIsOk(msgError,"ERROR CAMPOS DE CLIENTE"); 
        }

        private Boolean isExistingMail(TextBox txtMail){
            Boolean isExistingMail = businessClienteImpl.isExistingMail(txtMail.Text);
            if (isExistingMail && (formMode == EnumFormMode.MODE_ALTA))
            {
                MessageBox.Show(MSG_EMAI_ALREADY_EXISTS);
            }
            return isExistingMail && (formMode == EnumFormMode.MODE_ALTA);
        }

        private void populateAllInputsToModify(ClienteDTO cl)
        {
            txtNombre.Text = cl.nombre;
            txtApellido.Text = cl.apellido;
            txtDNI.Text = cl.dni.ToString();
            txtMail.Text = cl.mail;
            txtTelefono.Text = cl.nroTelefono.ToString();
            txtDirCalle.Text = cl.direccion;
            txtNumPiso.Text = cl.nroPiso.ToString();
            txtDepartamento.Text = cl.departamento.ToString();
            txtLocalidad.Text = cl.localidad;
            txtCodPostal.Text = cl.codPostal;
            if (cl.habilitado)
            {
                disabledRadioButtons();
            }
            else
            {
                radioBtnDeshabilitado.Select();
            }
            dateTimePickerNacimiento.Value = cl.fechaDeNacimiento;
        }

        private ClienteDTO populateClienteDTOToUpdateOrSave()
        {
            clienteDTOToUpdateOrSave.nombre = txtNombre.Text;
            clienteDTOToUpdateOrSave.apellido = txtApellido.Text;
            clienteDTOToUpdateOrSave.dni = Int32.Parse(txtDNI.Text);
            clienteDTOToUpdateOrSave.mail = txtMail.Text;
            clienteDTOToUpdateOrSave.nroTelefono = Int32.Parse(txtTelefono.Text);
            clienteDTOToUpdateOrSave.direccion = txtDirCalle.Text;
            clienteDTOToUpdateOrSave.nroPiso = Int32.Parse(txtNumPiso.Text);
            clienteDTOToUpdateOrSave.departamento = txtDepartamento.Text.ToCharArray()[0];
            clienteDTOToUpdateOrSave.localidad = txtLocalidad.Text;
            clienteDTOToUpdateOrSave.codPostal = txtCodPostal.Text;
            clienteDTOToUpdateOrSave.fechaDeNacimiento = dateTimePickerNacimiento.Value;
            clienteDTOToUpdateOrSave.habilitado = radioBtnHabilitado.Checked;
            return clienteDTOToUpdateOrSave;
        }

        private void disabledRadioButtons() {
            radioBtnHabilitado.Select();
            radioBtnHabilitado.Enabled = false;
            radioBtnDeshabilitado.Enabled = false;
        }


        private void AltaClienteForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.prevForm.Show();
        }

    }
}
