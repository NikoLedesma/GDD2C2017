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
        private BusinessRubroImpl businessRubroImpl;
        private List<RubroDTO> listRubroDTO; 


        public AltaEmpresaForm(Form form)
        {

            InitializeComponent();
            businessEmpresaImpl = new BusinessEmpresaImpl();
            prevForm = form;
            businessRubroImpl = new BusinessRubroImpl();
            listRubroDTO = businessRubroImpl.getRubros();
            object[] objects = listRubroDTO.ConvertAll<object>(item => (object)item.nombre).ToArray();
           // listRubroDTO.ForEach(x => { objects.push(converterRubroToRubroDTO(x)); });
            //this.comboBox1.Items.AddRange(objects);//.DataSource = listRubroDTO;
            this.comboBox1.DataSource = listRubroDTO;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DisplayMember = "nombre";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmpresaDTO empresaDTO = new EmpresaDTO();
            empresaDTO.nombre = txtNombre.Text;
            empresaDTO.cuit = txtCuit.Text;
            empresaDTO.direccion = txtDireccion.Text;
            empresaDTO.rubro = (int)this.comboBox1.SelectedValue; //txtRubro.Text;
            businessEmpresaImpl.saveEmpresa(empresaDTO);

            MessageBox.Show("Se dio de alta la EMPRESA, Rubro:");
        }
    }
}
