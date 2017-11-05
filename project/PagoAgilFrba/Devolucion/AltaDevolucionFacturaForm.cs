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
using DTO.Enums;
using PagoAgilFrba.UTILS;

namespace PagoAgilFrba.Devolucion
{
    public partial class AltaDevolucionFacturaForm : Form
    {
        private Form prevForm;
        private BusinessFacturaImpl businessFacturaImpl;
        private BusinessClienteImpl businessClienteImpl;
        private BusinessEmpresaImpl businessEmpresaImpl;
        private List<ClienteDTO> listClienteDTO;
        private List<EmpresaDTO> listEmpresaDTO;
        private List<FacturaDTO> listFacturaDTO;
        private BusinessDevolucionImpl businessDevolucionImpl;

        public AltaDevolucionFacturaForm(Form prevForm)
        {
            InitializeComponent();
            businessFacturaImpl = new BusinessFacturaImpl();
            businessClienteImpl = new BusinessClienteImpl();
            businessEmpresaImpl = new BusinessEmpresaImpl();

            listClienteDTO = businessClienteImpl.getAllCliente();
            this.comboBox3.DataSource = listClienteDTO;
            this.comboBox3.ValueMember = "id";
            this.comboBox3.DisplayMember = "dni";

            listEmpresaDTO = businessEmpresaImpl.getEmpresas();
            this.comboBox1.DataSource = listEmpresaDTO;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DisplayMember = "cuit";

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmpresaDTO empresaSelected = (EmpresaDTO)this.comboBox1.SelectedItem;
            ClienteDTO clienteSelected = (ClienteDTO)this.comboBox3.SelectedItem;
            int empresaId = 0;
            int clienteId = 0;

            if(empresaSelected != null)
                empresaId = empresaSelected.id;
            if(empresaSelected != null)
                clienteId = clienteSelected.id;

            if (empresaId > 0 && clienteId > 0)
            {

                businessFacturaImpl = new BusinessFacturaImpl();

                listFacturaDTO = businessFacturaImpl.getFacturaByClientAndEmpresa(clienteId, empresaId);

                this.comboBox2.DataSource = listFacturaDTO;
                this.comboBox2.ValueMember = "nroFact";
                this.comboBox2.DisplayMember = "fecha";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmpresaDTO empresaSelected = (EmpresaDTO)this.comboBox1.SelectedItem;
            ClienteDTO clienteSelected = (ClienteDTO)this.comboBox3.SelectedItem;
            int empresaId = 0;
            int clienteId = 0;

            if (empresaSelected != null)
                empresaId = empresaSelected.id;
            if (empresaSelected != null)
                clienteId = clienteSelected.id;

            if (empresaId > 0 && clienteId > 0)
            {

                businessFacturaImpl = new BusinessFacturaImpl();

                listFacturaDTO = businessFacturaImpl.getFacturaByClientAndEmpresa(clienteId, empresaId);

                this.comboBox2.DataSource = listFacturaDTO;
                this.comboBox2.ValueMember = "nroFact";
                this.comboBox2.DisplayMember = "fecha";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(validateEmptyFields())
            {
                DevolucionDTO devolucionDTO = new DevolucionDTO();

                devolucionDTO.idFact = (int)this.comboBox2.SelectedValue;

                devolucionDTO.razon = this.textBox1.Text;

                businessDevolucionImpl = new BusinessDevolucionImpl();

                int resu = businessDevolucionImpl.saveDevolucion(devolucionDTO);
                MessageBox.Show("La devolucion se dio con exito, resu:" + resu);
            }

            
        }

        private Boolean validateEmptyFields()
        {
            Boolean result = Validator.validateEmptyTextBox(textBox1, "MOTIVO");
            return result;
        }

    }
}
