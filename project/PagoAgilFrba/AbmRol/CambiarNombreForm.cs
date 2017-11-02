using Business;
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

namespace PagoAgilFrba.AbmRol
{
    public partial class CambiarNombreForm : Form
    {

        private RolForm prevForm;
        private BusinessRolImpl businessRolImpl; 


        public CambiarNombreForm(RolForm form,String rolNameToChange)
        {
            InitializeComponent();
            prevForm = form;
            prevForm.Enabled = false;
            txtNombreRolActual.Text = rolNameToChange;
            businessRolImpl = new BusinessRolImpl();
        }

        private void btnCambiarNombreRol_Click(object sender, EventArgs e)
        {
            if(Validator.validateEmptyTextBox(txtNombreRolNuevo,"NOMBRE DE ROL NUEVO") &&  !haveTheSameRolName()){
                Boolean isExistingName=businessRolImpl.isExistingName(txtNombreRolNuevo.Text);
                if (!isExistingName)
                {
                    int res = businessRolImpl.changeNameByOther(txtNombreRolActual.Text, txtNombreRolNuevo.Text);
                    if (res == 1)
                    {
                        MessageBox.Show("EL NOMBRE DE ROL FUE CAMBIADO");
                        prevForm.updateNameOfRol();
                        this.Close();
                    }
                    else {
                        MessageBox.Show("EL NOMBRE DE ROL NO PUDO SER CAMBIADO#5$%&");
                    }

                }
                else {
                    MessageBox.Show("EL NUEVO NOMBRE INGRESADO YA EXISTE, INGRESE OTRO");
                }
                

            }

        }

        private Boolean haveTheSameRolName()
        {
            String nombreRolActual = txtNombreRolActual.Text;
            String nombreRolNuevo = txtNombreRolNuevo.Text;
            Boolean res = nombreRolActual.Equals(nombreRolNuevo);
            if(res){
                MessageBox.Show("EL NUEVO NOMBRE TIENE EL MISMO NOMBRE QUE EL ACTUAL");
            }
            return res;
        }


        private void CambiarNombreForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            prevForm.Enabled = true;
        }

    }
}
