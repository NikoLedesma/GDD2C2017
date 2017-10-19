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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class altaSucursalForm : Form
    {

        private Form prevForm;
        private BusinessSucursalImpl businessSucursalImpl;
        private EnumFormMode formMode;
        private SucursalDTO sucursalDTOToUpdateOrSave;
        private static String MSG_ERROR_SAVE = "ERROR:NO SE PUDO DAR DE ALTA A UNA SUCURSA";
        private static String MSG_ERROR_UPDATE = "ERROR:NO SE PUDO ACTUALIZAR LA SUCURSAL";
        private static String ALTA_TITLE = "SUCURSAL DADA DE ALTA ";
        private static String MODIF_TITLE = "MODIFICACION DE SUCURSAL(ID:{0})";
        private static String MSG_SUCCESS_SAVE = "LA SUCURSAL SE DIO DE ALTA";
        private static String MSG_SUCCESS_UPDATE = "LA SUCURSAL SE MODIFICO";

        public altaSucursalForm(Form form, EnumFormMode enumFormMode, SucursalDTO suc)
        {
            InitializeComponent();
            businessSucursalImpl = new BusinessSucursalImpl();
            prevForm = form;
            form.Hide();
            formMode = enumFormMode;
            if (formMode == EnumFormMode.MODE_ALTA)
            {
                //DAR DE ALTA SUCURSAL
                this.Text = ALTA_TITLE;
                this.sucursalDTOToUpdateOrSave = new SucursalDTO();
            }

            if (formMode == EnumFormMode.MODE_MODIFICACION)
            {
                //MODIFICAR SUCURSAL
                this.Text = String.Format(MODIF_TITLE, suc.id);
                this.sucursalDTOToUpdateOrSave = suc;
                txtNombre.Text = suc.nombre;
                txtDireccion.Text = suc.direccion;
                txtCodPostal.Text = suc.codPostal.ToString();
                
            }
        }


        private void button1_Click(object sender, EventArgs e) //aceptar y dar de alta
        {
            SucursalDTO sucursalDTO = new SucursalDTO();
            sucursalDTO.nombre = txtNombre.Text;
            sucursalDTO.direccion = txtDireccion.Text;
            sucursalDTO.codPostal = Int32.Parse(txtCodPostal.Text); //Int32.Parse(txtNumPiso.Text);
            saveOrUpdateSucursal(sucursalDTO);

            MessageBox.Show("Se dio de alta la SUCURSAL");

        }


        public void saveOrUpdateSucursal(SucursalDTO sucursalDTO)
        {
            if (formMode == EnumFormMode.MODE_ALTA)
            {
                try
                {
                    businessSucursalImpl.saveSucursal(sucursalDTO);
                    MessageBox.Show(MSG_SUCCESS_SAVE);
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
                    businessSucursalImpl.updateSucursal(sucursalDTO);
                    MessageBox.Show(MSG_SUCCESS_UPDATE);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(MSG_ERROR_UPDATE);
                }
            }
        }

        private Boolean validateEmptyFields()
        {
            Boolean result = Validator.validateEmptyTextBox(txtNombre, "NOMBRE") 
                                && Validator.validateEmptyTextBox(txtDireccion, "DIRECCION")
                                && Validator.validateEmptyTextBox(txtCodPostal, "CODIGO POSTAL");
            return result;
        }




    }

}
