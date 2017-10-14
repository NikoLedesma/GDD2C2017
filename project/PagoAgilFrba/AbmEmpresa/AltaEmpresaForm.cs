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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class AltaEmpresaForm : Form
    {
        private Form prevForm;
        private BusinessEmpresaImpl businessEmpresaImpl;
        public AltaEmpresaForm(Form form)
        {

            InitializeComponent();
            businessEmpresaImpl = new BusinessEmpresaImpl();
            prevForm = form;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmpresaDTO empresaDTO = new EmpresaDTO();
            empresaDTO.nombre = txtNombre.Text;
            empresaDTO.cuit = txtCuit.Text;
            empresaDTO.direccion = txtDireccion.Text;
            empresaDTO.rubro = txtRubro.Text;
            businessEmpresaImpl.saveEmpresa(empresaDTO);

            MessageBox.Show("Se dio de alta la EMPRESA");
        }
    }
}
