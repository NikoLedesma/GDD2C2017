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
        public AltaFacturaForm(Form form)
        {
            InitializeComponent();
            businessFacturaImpl = new BusinessFacturaImpl();
            prevForm = form;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FacturaDTO facturaDTO = new FacturaDTO();
            facturaDTO.cliente = txtCliente.Text;
            facturaDTO.empresa = txtEmpresa.Text; //falta ponerlo acotado
            facturaDTO.nroFact = Int32.Parse(txtNroFact.Text);
            facturaDTO.fechaDeAlta = dateTimePickerAlta.Value;
            facturaDTO.fechaDeVencimiento = dateTimePickerVencimiento.Value;
            facturaDTO.total = Int32.Parse(txtTotal.Text);

            //FALTA AGREGAR LA GRILLA DE LOS TOTAL ITEMS MONTO Y CANTIDAD

            businessFacturaImpl.saveFactura(facturaDTO);

            MessageBox.Show("Se dio de alta la FACTURA");
        }

    }

}
