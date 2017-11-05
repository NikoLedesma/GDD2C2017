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

namespace PagoAgilFrba.RegistroPago
{
    public partial class FacturaAPagarForm : Form
    {


        private RegistroDePagoForm prevForm;
        private BusinessRegistroDePagoImpl businessRegistroDePago;
        private FacturaDTO facturaDTO;
        private static String MSG_FACTURA_ALREADY_PAID = "LA FACTURA YA FUE PAGADA";
        private static String MSG_FACTURA_NOT_EXIST = "NO EXISTE LA FACTURA, VUELVA A CONSULTAR";
        private static String MSG_FACTURA_ALREADY_ADDED = "LA FACTURA N°{0} YA FUE AGREGADA";
        private static String MSG_FACTURA_EXIST_WITH_EMPRESA_DISABLED = "LA EMPRESA DE LA FACTURA ESTA DESHABILITADA";
        private static String MSG_FACTURA_VENCIDA = "LA FECHA DE FACTURA ESTA VENCIDA";
        public FacturaAPagarForm(RegistroDePagoForm form)
        {
            this.prevForm = form;
            form.Hide();
            InitializeComponent();
            btnAgregar.Enabled = false;
            businessRegistroDePago = new BusinessRegistroDePagoImpl();
        }

        private void RegistroPagoForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            prevForm.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FacturaDTO facturaDTO = businessRegistroDePago.getFacturaByNroFactura(Int32.Parse(txtNroFactura.Text));

            if (!prevForm.alreadyExistsFacturaDTO(facturaDTO))
            {
                if (Validator.dateIsLessThanSystemDate(facturaDTO.fechaDeVencimiento))
                {
                    prevForm.addFacturaDTOToPay(facturaDTO);
                    this.Close();
                }
                else {

                    MessageBox.Show(MSG_FACTURA_VENCIDA);
                }
            }
            else {
                MessageBox.Show(String.Format(MSG_FACTURA_ALREADY_ADDED, facturaDTO.nroFact));
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
            List <String> msgError=new List<string>();
            msgError = Validator.addMsgIfEmpty(msgError,txtNroFacturaToSearch.Text,"NUMERO DE FACTURA");
            msgError = Validator.addMsgIfNotInteger(msgError, txtNroFacturaToSearch.Text, "NUMERO DE FACTURA");
            Boolean isAnyMsgToShow = Validator.verifiedIfIsOk(msgError,"VALIDACION DE CAMPOS");
            if (!isAnyMsgToShow)
            {
            ResultCheckFactura verifiedFactura = businessRegistroDePago.verifiedFacturaById(Int32.Parse(txtNroFacturaToSearch.Text));
            if(verifiedFactura == ResultCheckFactura.EXIST_FACTURA_NO_PAGADA){
                facturaDTO = businessRegistroDePago.getFacturaByNroFactura(Int32.Parse(txtNroFacturaToSearch.Text));
                txtNroFactura.Text = facturaDTO.nroFact.ToString();
                txtEmpresa.Text = facturaDTO.empresa.ToString();
                txtCliente.Text = facturaDTO.cliente.ToString();
                txtFechaDeCobro.Text = GlobalUtils.getHoraDelSistemaString();
                txtFechaVencimiento.Text = facturaDTO.fechaDeVencimiento.ToString();
                txtImporte.Text = facturaDTO.total.ToString();
                txtSucursal.Text = GlobalUtils.sucursalGlobalDTO.nombre;
                btnAgregar.Enabled = true;
            }
            else if(verifiedFactura == ResultCheckFactura.EXIST_FACTURA_PAGADA)
            {
                MessageBox.Show(MSG_FACTURA_ALREADY_PAID);
            }
            else if (verifiedFactura == ResultCheckFactura.NOT_EXIST_FACTURA)
            {
                MessageBox.Show(MSG_FACTURA_NOT_EXIST);
            }
            else if (verifiedFactura == ResultCheckFactura.EXIST_FACTURA_WITH_EMPRESA_DISABLED)
            {
                MessageBox.Show(MSG_FACTURA_EXIST_WITH_EMPRESA_DISABLED);
            }
        }
        }
    
    }
}
