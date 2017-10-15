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
        private static String MODIF_TITLE = "MODIFICACION DE CLIENTE(ID:{0})";
        private static String MSG_SUCCESS_SAVE = "EL CLIENTE SE DIO DE ALTA";
        private static String MSG_SUCCESS_UPDATE = "EL CLIENTE SE MODIFICO";

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
            }

            if (formMode == EnumFormMode.MODE_MODIFICACION)
            {
                this.Text = String.Format(MODIF_TITLE, cl.id);
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
            return validateEmptyFields() && Validator.validateMailTextBox(txtMail);
        }

        private Boolean validateEmptyFields()
        {
            Boolean result = Validator.validateEmptyTextBox(txtNombre, "NOMBRE") && Validator.validateEmptyTextBox(txtApellido, "APELLIDO")
            && Validator.validateEmptyTextBox(txtDNI, "DNI") && Validator.validateEmptyTextBox(txtMail, "MAIL")
            && Validator.validateEmptyTextBox(txtTelefono, "TELEFONO") && Validator.validateEmptyTextBox(txtDirCalle, "DIRECCION")
            && Validator.validateEmptyTextBox(txtNumPiso, "NRO PISO") && Validator.validateEmptyTextBox(txtDepartamento, "DEPARTAMENTO")
            && Validator.validateEmptyTextBox(txtLocalidad, "LOCALIDAD") && Validator.validateEmptyTextBox(txtCodPostal, "CODIGO POSTAL");
            return result;
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
            return clienteDTOToUpdateOrSave;
        }


        private void AltaClienteForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.prevForm.Show();
        }

    }
}
