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

namespace PagoAgilFrba.AbmFactura
{
    public partial class AltaFacturaForm : Form
    {
        private Form prevForm;
        private BusinessFacturaImpl businessFacturaImpl;
        private BusinessClienteImpl businessClienteImpl;
        private BusinessEmpresaImpl businessEmpresaImpl;
        private List<ClienteDTO> listClienteDTO;
        private List<EmpresaDTO> listEmpresaDTO;

        public AltaFacturaForm(Form form)
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

        private void button1_Click(object sender, EventArgs e)
        {
            FacturaDTO facturaDTO = new FacturaDTO();
            facturaDTO.cliente = (int)this.comboBox1.SelectedValue; //txtCliente.Text;
            facturaDTO.empresa = (int)this.comboBox1.SelectedValue;//txtEmpresa.Text; //falta ponerlo acotado
            facturaDTO.nroFact = Int32.Parse(txtNroFact.Text);
            facturaDTO.fechaDeAlta = dateTimePickerAlta.Value;
            facturaDTO.fechaDeVencimiento = dateTimePickerVencimiento.Value;
            facturaDTO.total = Int32.Parse(txtTotal.Text);

            //FALTA AGREGAR LA GRILLA DE LOS TOTAL ITEMS MONTO Y CANTIDAD

            //businessFacturaImpl.saveFactura(facturaDTO);
            DataTable dt = new DataTable();
            dt.Columns.Add("monto", typeof(float));
            dt.Columns.Add("cantidad", typeof(int));

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                
                var cell = row.Cells[0].Value;
                if (cell != null)
                {

                    float monto = float.Parse(row.Cells[0].Value.ToString());
                    int cantidad = int.Parse(row.Cells[1].Value.ToString());
                    dt.Rows.Add(monto, cantidad);
                }

            }

            MessageBox.Show("Se dio de alta la FACTURA");
        }

    }

}
