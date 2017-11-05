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
    public partial class ModSucursalForm : Form
    {
        private Form prevForm;
        private BusinessSucursalImpl businessSucursalImpl;

        private readonly static String HABILITADO_COLUMN_HEADER_NAME = "habilitado";
        private readonly static String ID_COLUMN_HEADER_NAME = "id";
        private readonly static String DNI_VALIDATION_MSG = " COD POSTAL ";
        private List<SucursalDTO> filteredSucursalDTOs;

        public ModSucursalForm(Form form)
        {
            InitializeComponent();
            form.Hide();
            this.prevForm = form;
            businessSucursalImpl = new BusinessSucursalImpl();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            altaSucursalForm form = new altaSucursalForm(this, EnumFormMode.MODE_ALTA, null);
            form.Show();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            businessSucursalImpl = new BusinessSucursalImpl();
            SucursalDTO fSucursalDTO = validateAndFillFilterSucursalDTO();
            filteredSucursalDTOs = businessSucursalImpl.getSucursalesByFilter(fSucursalDTO);
            populateDataGridView(filteredSucursalDTOs);
        }

        private SucursalDTO validateAndFillFilterSucursalDTO()
        {
            SucursalDTO fSucursalDTO = new SucursalDTO();
            fSucursalDTO.nombre = txtNombre.Text;
            fSucursalDTO.direccion = txtDireccion.Text;
            fSucursalDTO.codPostal = Validator.validatePositiveIntegerTextBox(txtCodPostal, DNI_VALIDATION_MSG);
            return fSucursalDTO;
        }

        private void populateDataGridView(List<SucursalDTO> sucuList)
        {
            var bindingList = new BindingList<SucursalDTO>(sucuList);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        //desde aca -- arranca el tema de agregar las columnas id y habilitado y permite elegirla y selecccionarla

        protected void dataGVSucursal_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {//esto es para que no se vea la columna de id. ---
            Provider.matchAndTurnOffColumnVisibility(e, ID_COLUMN_HEADER_NAME);
            Provider.matchAndTurnOnColumnReadOnly(e, HABILITADO_COLUMN_HEADER_NAME);
        }

        private void dataGVSucursal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            String id = Provider.getValueIdentifier(dataGridView, e.RowIndex, ID_COLUMN_HEADER_NAME).ToString();
            if (Validator.isSelectedModificarColumn(dataGridView, e.ColumnIndex))
            {
                //MessageBox.Show("Mod id:" + id);
                //TODO : VERIFICAR SI AGARRA EL CORRECTO OBJECTO
                SucursalDTO cl = filteredSucursalDTOs[e.RowIndex];
                altaSucursalForm form = new altaSucursalForm(this, EnumFormMode.MODE_MODIFICACION, cl);
                form.Show();
            }
            if (Validator.isSelectedBajarColumn(dataGridView, e.ColumnIndex))
            {
                SucursalDTO cl = filteredSucursalDTOs[e.RowIndex];
                if (cl.habilitado == true) //tengo que poner false porque quedaron al reves los datos en la base. pusieron inactiva
                {
                    //cl.apellido = "Okuma";
                    businessSucursalImpl.deleteSucursal(cl);
                    MessageBox.Show("Sucursal Eliminada");
                }
                else
                {
                    MessageBox.Show("NO ESTA HABILITADO");
                }
                
            }

        }

        private void ModSucursalForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.prevForm.Show();
        }
        //hasta aca

        private void btnLimpiar_Click(object sender, EventArgs e) //todavia no esta hecho
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtCodPostal.Clear();
            dataGridView1.Rows.Clear();
            //dataGridView1.Columns.Clear();
            //dataGridView1.DataSource = Nothing;
        }


    }
}
