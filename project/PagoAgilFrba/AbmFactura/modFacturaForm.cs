using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using DTO;
using DTO.Enums;
using PagoAgilFrba.UTILS;

namespace PagoAgilFrba.AbmFactura
{
    public partial class modFacturaForm : Form
    {
        private Form prevForm;
        private BusinessFacturaImpl businessFacturaImpl;
        private BusinessClienteImpl businessClienteImpl;
        private BusinessEmpresaImpl businessEmpresaImpl;
        private List<ClienteDTO> listClienteDTO;
        private List<EmpresaDTO> listEmpresaDTO;
        private List<FacturaDTO> filteredFacturaDTOs;
        private readonly static String ID_COLUMN_HEADER_NAME = "id";


        public modFacturaForm(Form form)
        {
            InitializeComponent();
            businessFacturaImpl = new BusinessFacturaImpl();
            businessClienteImpl = new BusinessClienteImpl();
            businessEmpresaImpl = new BusinessEmpresaImpl();

            listClienteDTO = businessClienteImpl.getAllCliente();
            this.comboBox1.DataSource = listClienteDTO;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DisplayMember = "dni";

            listEmpresaDTO = businessEmpresaImpl.getEmpresas();
            this.comboBox2.DataSource = listEmpresaDTO;
            this.comboBox2.ValueMember = "id";
            this.comboBox2.DisplayMember = "cuit";

            prevForm = form;
        }

        private void modFacturaForm_Load(object sender, EventArgs e)
        {

        }
        private FacturaDTO validateAndFillFilterFacturaDTO()
        {
            FacturaDTO facturaDTO = new FacturaDTO();
            facturaDTO.cliente = (int)this.comboBox1.SelectedValue; //txtCliente.Text;
            facturaDTO.empresa = (int)this.comboBox2.SelectedValue;
            //fFacturaDTO.dni = Validator.validatePositiveIntegerTextBox(txtDNI, DNI_VALIDATION_MSG);
            return facturaDTO;
        }
        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaFacturaForm form = new AltaFacturaForm(this, EnumFormMode.MODE_ALTA, null);
            form.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {   
            FacturaDTO filterFacturaDTO = validateAndFillFilterFacturaDTO();
            filteredFacturaDTOs = businessFacturaImpl.getFacturaByFilter(filterFacturaDTO);
            populateDataGridView(filteredFacturaDTOs);
        }
        private void populateDataGridView(List<FacturaDTO> facturasList)
        {

            var bindingList = new BindingList<FacturaDTO>(facturasList);
            var source = new BindingSource(bindingList, null);
            dataGVClientes.DataSource = source;
        }
        private void dataGVClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            String id = Provider.getValueIdentifier(dataGridView, e.RowIndex, ID_COLUMN_HEADER_NAME).ToString();
            //MessageBox.Show("Mod id:" + id);
            if (Validator.isSelectedModificarColumn(dataGridView, e.ColumnIndex))
            {
                
                //TODO : VERIFICAR SI AGARRA EL CORRECTO OBJECTO
                FacturaDTO facturaDTO = filteredFacturaDTOs[e.RowIndex];
                AltaFacturaForm form = new AltaFacturaForm(this, EnumFormMode.MODE_MODIFICACION, facturaDTO);
                form.Show();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGVClientes.Rows.Clear();
        }
    }
}
