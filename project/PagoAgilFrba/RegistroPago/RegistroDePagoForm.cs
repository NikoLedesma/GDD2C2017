using Business;
using DTO;
using Entities;
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

namespace PagoAgilFrba.RegistroPago
{
    public partial class RegistroDePagoForm : Form
    {

        private Form prevForm;
        private FacturaAPagarForm form;
        private RegistroDePagoDTO registroDePagoDTO;
        private BusinessRegistroDePagoImpl businessRegistroDePago;
        private static String MSG_WITHOUT_ANY_FACTURA = "NO AGREGO NINGUNA FACTURA AL PAGO";
        private static String MSG_PAGO_SUCCED  = "PAGO GENERADO";
        private static String MSG_PAGO_FAILED = "NO SE PUDO GENERAR EL PAGO";


        public RegistroDePagoForm(Form form)
        {
            InitializeComponent();
            this.prevForm = form;
            form.Hide();
            registroDePagoDTO = new RegistroDePagoDTO();
            registroDePagoDTO.facturasDTO = new List<FacturaDTO>();
            businessRegistroDePago = new BusinessRegistroDePagoImpl();
            populateDataGridView();
            /*************************/
            List<MedioDePagoDTO> medioDePagoDTOList= businessRegistroDePago.getAllMediosDePagos();
            comboBoxFormaDePago.DisplayMember ="nombre";
            comboBoxFormaDePago.ValueMember = "id";
            comboBoxFormaDePago.DataSource = new BindingSource(medioDePagoDTOList,null);
            comboBoxFormaDePago.SelectedIndex = 0;
            /*************************/
        }

        private void btnAddFactura_Click(object sender, EventArgs e)
        {
            form = new FacturaAPagarForm(this);
            form.Show();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

            if (registroDePagoDTO.facturasDTO.Count > 0)
            {
                MedioDePagoDTO medioDePagoDTOSelected = (MedioDePagoDTO)comboBoxFormaDePago.SelectedItem;
                registroDePagoDTO.medioDePagoDTO = medioDePagoDTOSelected;
                registroDePagoDTO.numero =   Int32.Parse(txtIdPago.Text);
                registroDePagoDTO.importe = (float) Double.Parse(txtImporte.Text);  
                int resPago = businessRegistroDePago.registrarPagos(registroDePagoDTO);
                if (resPago == 1)
                {
                    MessageBox.Show(MSG_PAGO_SUCCED);

                }
                else {
                    MessageBox.Show(MSG_PAGO_FAILED);
                }

                txtIdPago.Text = "";
                txtImporte.Text = "";
                registroDePagoDTO = new RegistroDePagoDTO();
                registroDePagoDTO.facturasDTO = new List<FacturaDTO>();
                populateDataGridView();                

            }
            else {
                MessageBox.Show(MSG_WITHOUT_ANY_FACTURA);
            }


        }


        public void addFacturaDTOToPay(FacturaDTO facturaDTO)
        {
            registroDePagoDTO.facturasDTO.Add(facturaDTO);
            float importe = 0;
            registroDePagoDTO.facturasDTO.ForEach(x => { importe += x.total; });
            registroDePagoDTO.importe = importe;
            txtImporte.Text = importe.ToString();
            populateDataGridView();
        }

        private void dataGridViewFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            if (Validator.isSelectedEliminarColumn(dataGridViewFacturas, e.ColumnIndex))
            {
                FacturaDTO facturaDTO = registroDePagoDTO.facturasDTO[e.RowIndex];
                dataGridView.Rows.RemoveAt(e.RowIndex);
                //registroDePagoDTO.facturasDTO.RemoveAt(e.RowIndex);
                float importe = 0;
                registroDePagoDTO.facturasDTO.ForEach(x => { importe += x.total; });
                registroDePagoDTO.importe = importe;
                txtImporte.Text = importe.ToString();
            }
        }


        private void populateDataGridView()
        {
            var bindingList = new BindingList<FacturaDTO>(registroDePagoDTO.facturasDTO);
            var source = new BindingSource(bindingList, null);
            dataGridViewFacturas.DataSource = source;
        }


        private void RegistroDePagoForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }


        public bool alreadyExistsFacturaDTO(FacturaDTO facturaDTO)
        {
            return registroDePagoDTO.facturasDTO.Any(item => item.nroFact == facturaDTO.nroFact);
        }
    }
}
