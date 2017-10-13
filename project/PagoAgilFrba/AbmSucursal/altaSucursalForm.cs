using Business;
using DTO;
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
       // private BusinessClienteImpl businessClienteImpl;
        private BusinessSucursalImpl businessSucursalImpl;
        public altaSucursalForm(Form form)
        //public altaSucursalForm()
        {
            InitializeComponent();
            businessSucursalImpl = new BusinessSucursalImpl();
            prevForm = form;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SucursalDTO sucursalDTO = new SucursalDTO();
            sucursalDTO.nombre = txtNombre.Text;
            sucursalDTO.direccion = txtDireccion.Text;
         /* 
          * COMENTO TODO ESTO PORQUE EN EL DER ESTA EL CAMPO DIRECCION SOLO
            sucursalDTO.nroPiso = Int32.Parse(txtNumPiso.Text);
            sucursalDTO.departamento = txtDepartamento.Text.ToCharArray()[0];
            sucursalDTO.localidad = txtLocalidad.Text;
         */
            sucursalDTO.codPostal = txtCodPostal.Text;
            businessSucursalImpl.saveSucursal(sucursalDTO);

            MessageBox.Show("Se dio de alta la SUCURSAL");

        }

    }

}
