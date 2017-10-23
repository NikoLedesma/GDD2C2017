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
    public partial class ModEmpresaForm : Form
    {

        private Form prevForm;
        private BusinessEmpresaImpl businessEmpresaImpl;
        private readonly static String HABILITADO_COLUMN_HEADER_NAME = "habilitado";
        private readonly static String ID_COLUMN_HEADER_NAME = "id";
        private List<EmpresaDTO> filtroEmpresaDTOs;
        private BusinessRubroImpl businessRubroImpl;
        private List<RubroDTO> listRubroDTO;
       
        public ModEmpresaForm(Form form)
        {
            InitializeComponent();
            form.Hide();
            this.prevForm = form;
            businessEmpresaImpl = new BusinessEmpresaImpl();
            businessRubroImpl = new BusinessRubroImpl();
            listRubroDTO = businessRubroImpl.getRubros(); //agrego el box para seleccion acotada del rubro
            this.comboBoxRubro.DataSource = listRubroDTO;
            this.comboBoxRubro.ValueMember = "id";
            this.comboBoxRubro.DisplayMember = "nombre";
        }
        
        private void btnBuscar_Click(object sender, EventArgs e) //boton buscar
        {
            EmpresaDTO empresaABuscar = pantallaADTO();
            filtroEmpresaDTOs = businessEmpresaImpl.getEmpresasByFilter(empresaABuscar); //Busco en la base de datos la empresa por filtros
            mostrarPantalla(filtroEmpresaDTOs);
        }

        private EmpresaDTO pantallaADTO() //Tomo los datos de pantalla y los pongo en empresa DTO
        {
            EmpresaDTO wachaDTO = new EmpresaDTO();
            wachaDTO.nombre = txtNombre.Text;
            wachaDTO.cuit = txtCuit.Text;
            wachaDTO.rubro = (int)this.comboBoxRubro.SelectedValue; //txtRubro.Text;    //agrego el combobox del rubro
            return wachaDTO;
        }

        private void mostrarPantalla(List<EmpresaDTO> listaEmpresas)
        {
            var bindingList = new BindingList<EmpresaDTO>(listaEmpresas);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        protected void dataGVEmpresas_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            Provider.matchAndTurnOffColumnVisibility(e, ID_COLUMN_HEADER_NAME);
            Provider.matchAndTurnOnColumnReadOnly(e, HABILITADO_COLUMN_HEADER_NAME);
        }

        private void dataGVEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e) //funcion para ver que hacer cuando eligen el borrar o modificar en la grilla
        {
            var dataGridView = (DataGridView)sender;
            String id = Provider.getValueIdentifier(dataGridView, e.RowIndex, ID_COLUMN_HEADER_NAME).ToString();
            if (Validator.isSelectedModificarColumn(dataGridView, e.ColumnIndex))
            {
                //MessageBox.Show("Mod id:" + id);
                //TODO : VERIFICAR SI AGARRA EL CORRECTO OBJECTO
                EmpresaDTO cl = filtroEmpresaDTOs[e.RowIndex];
                AltaEmpresaForm form = new AltaEmpresaForm(this, EnumFormMode.MODE_MODIFICACION, cl);
                form.Show();
            }
            if (Validator.isSelectedBajarColumn(dataGridView, e.ColumnIndex))
            {
                //TODO : VERIFICAR SI AGARRA EL CORRECTO OBJECTO
                EmpresaDTO cl = filtroEmpresaDTOs[e.RowIndex];
                if (cl.habilitado == false) //tengo que poner false porque quedaron al reves los datos en la base. pusieron inactiva
                {
                    //cl.nombre = "Okuma"; //Esto nose que hace
                    businessEmpresaImpl.deleteEmpresa(cl);
                    MessageBox.Show("ELIMINADO");
                }
                else
                {
                    MessageBox.Show("LA EMPRESA ESTA DESHABILITADA");
                }
            }

        }


        private void btnAltaEmp_Click(object sender, EventArgs e) //boton de alta nueva empresa
        {
            AltaEmpresaForm form = new AltaEmpresaForm(this, EnumFormMode.MODE_ALTA, null);
            form.Show();
        }


        private void ModEmpresaForm_FormClosing(Object sender, FormClosingEventArgs e)//Esto permite volver atras
        {
            this.prevForm.Show();
        }


    }

}
