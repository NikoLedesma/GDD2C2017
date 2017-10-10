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

namespace PagoAgilFrba.AbmCliente
{
    public partial class AltaClienteForm : Form
    {

        private Form prevForm;

        private BusinessClienteImpl businessClienteImpl;
        public AltaClienteForm(Form form)
        {
            InitializeComponent();
            businessClienteImpl = new BusinessClienteImpl();
            prevForm = form;
        
        }

        
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ClienteDTO clienteDTO = new ClienteDTO();
            clienteDTO.nombre = txtNombre.Text;
            clienteDTO.apellido =txtApellido.Text;
            clienteDTO.dni = Int32.Parse (txtDNI.Text);
            clienteDTO.mail = txtMail.Text;
            clienteDTO.nroTelefono =Int32.Parse (txtTelefono.Text);
            clienteDTO.direccion = txtDirCalle.Text;
            clienteDTO.nroPiso = Int32.Parse (txtNumPiso.Text);
            clienteDTO.departamento = txtDepartamento.Text.ToCharArray()[0];
            clienteDTO.localidad = txtLocalidad.Text;
            clienteDTO.codPostal = txtCodPostal.Text;
            clienteDTO.fechaDeNacimiento = dateTimePickerNacimiento.Value;
            businessClienteImpl.saveCliente(clienteDTO);
        }



    }
}
