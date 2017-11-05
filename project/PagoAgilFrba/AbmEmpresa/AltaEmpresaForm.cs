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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class AltaEmpresaForm : Form
    {
        private Form prevForm;
        private BusinessEmpresaImpl businessEmpresaImpl;
        private BusinessRubroImpl businessRubroImpl;
        private List<RubroDTO> listRubroDTO;
        private EnumFormMode formMode;
        private EmpresaDTO empDTOModifOAlta;
        
        private static String MSG_ERROR_SAVE = "ERROR:NO SE PUDO DAR DE ALTA A LA EMPRESA";
        private static String MSG_ERROR_UPDATE = "ERROR:NO SE PUDO ACTUALIZAR A LA EMPRESA";
        private static String ALTA_TITLE = "ALTA DE EMPRESA";
        private static String MODIF_TITLE = "MODIFICACION DE EMPRESA";//(ID:{0})";
        private static String MSG_SUCCESS_SAVE = "LA EMPRESA SE DIO DE ALTA";
        private static String MSG_SUCCESS_UPDATE = "LA EMPRESA SE MODIFICO";


        public AltaEmpresaForm(Form form, EnumFormMode enumFormMode, EmpresaDTO cl)
        {

            InitializeComponent();
            businessEmpresaImpl = new BusinessEmpresaImpl();
            prevForm = form;
            businessRubroImpl = new BusinessRubroImpl();
            listRubroDTO = businessRubroImpl.getRubros();
            //object[] objects = listRubroDTO.ConvertAll<object>(item => (object)item.nombre).ToArray();
           // listRubroDTO.ForEach(x => { objects.push(converterRubroToRubroDTO(x)); });
            //this.comboBox1.Items.AddRange(objects);//.DataSource = listRubroDTO;
            this.comboBox1.DataSource = listRubroDTO;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DisplayMember = "nombre";

            form.Hide();
            formMode = enumFormMode;

            if (formMode == EnumFormMode.MODE_ALTA)
            {
                this.Text = ALTA_TITLE;
                this.empDTOModifOAlta = new EmpresaDTO();
                disabledRadioButtons();
            }

            if (formMode == EnumFormMode.MODE_MODIFICACION)
            {
                //this.Text = String.Format(MODIF_TITLE, cl.id);
                this.Text = MODIF_TITLE;
                this.empDTOModifOAlta = cl;
                ponerAllInputsToModify(cl); //pongo a la empresa seleccionada para modif
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FALTA AGREGAR VALIDACIONES ANTES DEL ACEPTAR
            if (validateFields())//en esa funcion estan la validaciones falta validar el cuit
            {
                empDTOModifOAlta.nombre = txtNombre.Text;
                empDTOModifOAlta.cuit = txtCuit.Text;
                empDTOModifOAlta.direccion = txtDireccion.Text;
                empDTOModifOAlta.rubro = (int)this.comboBox1.SelectedValue; //txtRubro.Text;
                empDTOModifOAlta.habilitado = radioBtnHabilitado.Checked;
                empDTOModifOAlta.fechaRendicion = dateTimePicker1.Value;
                //      empDTOModifOAlta = empresaDTOAltaOModif();

                if (formMode == EnumFormMode.MODE_ALTA)
                {
                    try
                    {
                        int resu = businessEmpresaImpl.saveEmpresa(empDTOModifOAlta);
                        if (resu >= 1)
                        {
                            MessageBox.Show(MSG_SUCCESS_SAVE);
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una empresa con ese CUIT");
                        }
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(MSG_ERROR_SAVE);
                    }
                }
                if (formMode == EnumFormMode.MODE_MODIFICACION)
                {
                    try
                    {
                        int resUpdate = businessEmpresaImpl.updateEmpresa(empDTOModifOAlta);

                        if (resUpdate >= 1)
                        {
                            MessageBox.Show(MSG_SUCCESS_SAVE);
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una empresa con ese CUIT");
                        }
                        
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(MSG_ERROR_UPDATE);
                    }
                }
                
            }//ACA TENGO QUE MOSTRAR TODOS LOS CAMPOS QE ESTAN VACIO TODO
      
        }

        private Boolean validateFields()
        {
            List<string> msgErrors = new List<string>();
            msgErrors = Validator.addMsgIfEmpty(msgErrors, txtNombre.Text, "NOMBRE");
            msgErrors = Validator.addMsgIfNotLetters(msgErrors, txtNombre.Text, "NOMBRE");
            msgErrors = Validator.addMsgIfEmpty(msgErrors, txtCuit.Text, "CUIT");
            msgErrors = Validator.addMsgIfNotInteger(msgErrors, txtCuit.Text, "CUIT");
            msgErrors = Validator.addMsgIfEmpty(msgErrors, txtDireccion.Text, "DIRECCION");
            Boolean isAnyMessageToShow = Validator.verifiedIfIsOk(msgErrors, "ALERTA DE CAMPOS");
            return !isAnyMessageToShow;
        }


        private Boolean validateEmptyFields()
        {
            Boolean result = Validator.validateEmptyTextBox(txtNombre, "NOMBRE") && Validator.validateEmptyTextBox(txtDireccion, "DIRECCION")
            && Validator.validateEmptyTextBox(txtCuit, "CUIT");
            return result;
        }
        
        private EmpresaDTO empresaDTOAltaOModif()
        {
            empDTOModifOAlta.nombre = txtNombre.Text;
            empDTOModifOAlta.cuit = txtCuit.Text;
            empDTOModifOAlta.direccion = txtDireccion.Text;
            empDTOModifOAlta.rubro = (int)this.comboBox1.SelectedValue; //txtRubro.Text;
            empDTOModifOAlta.habilitado = radioBtnHabilitado.Checked;
            empDTOModifOAlta.fechaRendicion = dateTimePicker1.Value;
            return empDTOModifOAlta;
        }

        private void ponerAllInputsToModify(EmpresaDTO cl)
        {
            txtNombre.Text = cl.nombre;
            txtDireccion.Text = cl.direccion;
            txtCuit.Text = cl.cuit;
      //      dateTimePicker1.Value = cl.fechaRendicion;
            if (cl.habilitado) 
            {
                disabledRadioButtons();
            }
            else
            {
                radioBtnDeshabilitado.Select();
            }
        }

        private void disabledRadioButtons()
        {
            radioBtnHabilitado.Select();
            radioBtnHabilitado.Enabled = false;
            radioBtnDeshabilitado.Enabled = false;
        }

        private void AltaEmpresaForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.prevForm.Show();
        }


    }
}
