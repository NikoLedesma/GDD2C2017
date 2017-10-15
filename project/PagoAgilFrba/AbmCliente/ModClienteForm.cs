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

namespace PagoAgilFrba.AbmCliente
{
    public partial class ModClienteForm : Form
    {

        private Form prevForm;
        private BusinessClienteImpl businessClienteImpl;
       
        private readonly static String HABILITADO_COLUMN_HEADER_NAME = "habilitado";
        private readonly static String ID_COLUMN_HEADER_NAME = "id";
        private readonly static String DNI_VALIDATION_MSG = " DNI ";
        private List<ClienteDTO> filteredClienteDTOs;

        public ModClienteForm(Form form)
        {
            InitializeComponent();
            form.Hide();
            this.prevForm = form;
            businessClienteImpl = new BusinessClienteImpl();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClienteDTO fClienteDTO = validateAndFillFilterClientDTO();
            filteredClienteDTOs = businessClienteImpl.getClientesByFilter(fClienteDTO);
            populateDataGridView(filteredClienteDTOs);
        }


        private ClienteDTO validateAndFillFilterClientDTO()
        {
            ClienteDTO fClienteDTO = new ClienteDTO();
            fClienteDTO.nombre = txtNombre.Text;
            fClienteDTO.apellido = txtApellido.Text;
            fClienteDTO.dni = Validator.validatePositiveIntegerTextBox(txtDNI, DNI_VALIDATION_MSG);
            return fClienteDTO;
        }

        private void populateDataGridView (List<ClienteDTO> clientesList){

            var bindingList = new BindingList<ClienteDTO>(clientesList);
            var source = new BindingSource(bindingList, null);
            dataGVClientes.DataSource = source;
        }
        
        protected void dataGVClientes_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            Provider.matchAndTurnOffColumnVisibility(e, ID_COLUMN_HEADER_NAME);
            Provider.matchAndTurnOnColumnReadOnly(e, HABILITADO_COLUMN_HEADER_NAME);
        }

        private void dataGVClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            String id = Provider.getValueIdentifier(dataGridView, e.RowIndex, ID_COLUMN_HEADER_NAME).ToString();      
            if(Validator.isSelectedModificarColumn(dataGridView,e.ColumnIndex)){
                //MessageBox.Show("Mod id:" + id);
                //TODO : VERIFICAR SI AGARRA EL CORRECTO OBJECTO
                ClienteDTO cl = filteredClienteDTOs[e.RowIndex];
                AltaClienteForm form = new AltaClienteForm(this, EnumFormMode.MODE_MODIFICACION,cl);
                form.Show();
            }
            if(Validator.isSelectedBajarColumn(dataGridView,e.ColumnIndex)){
                //TODO : 
                MessageBox.Show("VER SI SE AGREGA EN LA MODIFICACION:" + id);
            }

        }

        private void ModClienteForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.prevForm.Show();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaClienteForm form = new AltaClienteForm(this, EnumFormMode.MODE_ALTA,null);
            form.Show();
        }

    }
}
