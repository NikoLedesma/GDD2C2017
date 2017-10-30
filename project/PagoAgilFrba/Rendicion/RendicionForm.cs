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

namespace PagoAgilFrba.Rendicion
{
    public partial class RendicionForm : Form
    {
        private Form prevForm;
        private BusinessEmpresaImpl businessEmpresaImpl;
        private BusinessFacturaImpl businessFacturaImpl;
        private BusinessRendicionImpl businessRendicionImpl;

        private List<EmpresaDTO> listEmpresaDTO;
        private List<FacturaDTO> filtroRendicionesDTOs;
        private DataTable facturasID;

        public RendicionForm(Form form)
        {
            InitializeComponent();
            form.Hide();
            this.prevForm = form;
       //   businessRendicionImpl = new BusinessRendicionImpl();
            businessEmpresaImpl = new BusinessEmpresaImpl();
            businessFacturaImpl = new BusinessFacturaImpl();
            businessRendicionImpl = new BusinessRendicionImpl();

            listEmpresaDTO = businessEmpresaImpl.getEmpresas();
            this.comboBox1.DataSource = listEmpresaDTO;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DisplayMember = "empresa";

        }
      

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FacturaDTO rendiciones = pantallaFacturasDTO();
            filtroRendicionesDTOs = businessFacturaImpl.getFacturaByFilterRendicion(rendiciones); //Busco en la base de datos la empresa por filtros
            //FALTA AGREGARLE AL BUSINESS FACTURA UN FILTRO POR LA FECHA
            populateDataGridView(filtroRendicionesDTOs);

            int cantFact;
            cantFact = filtroRendicionesDTOs.Count;
            txtCantFact.Text = cantFact.ToString();

            float sumaFact=0;
            filtroRendicionesDTOs.ForEach(x => { sumaFact = sumaFact + x.total; });

            facturasID = new DataTable();
            facturasID.Columns.Add("id",typeof(int));

            filtroRendicionesDTOs.ForEach(x => { addColumnInList(x, facturasID); });

            mostrarTotales(sumaFact);
 
        }

        private void addColumnInList(FacturaDTO factura, DataTable facturasID)
        {
            DataRow row = facturasID.NewRow();
            row["id"] = factura.id;
            facturasID.Rows.Add(row);
            
        }

        private void mostrarTotales(float subTotal)
        {

            txtSubTotal.Text = subTotal.ToString();
            //txtSubTotal.Text = "1000"; //ESTE VALOR TIENE QUE SER LA SUMA DE TODAS LAS FACTURAS

            if (validateEmptyFields())
            {
                txtImpCom.Text = ((Convert.ToDecimal(subTotal)) * (Convert.ToDecimal(txtPorcCom.Text) / 100)).ToString();
                txtTotal.Text = ((Convert.ToDecimal(subTotal)) - Convert.ToDecimal(txtImpCom.Text)).ToString();
               
            }
                       
        }

        private Boolean validateEmptyFields()
        {
            Boolean result = Validator.validateEmptyTextBox(txtPorcCom, "COMISION") ;
            return result;
        }

        private FacturaDTO pantallaFacturasDTO() 
        {
            FacturaDTO wachaDTO = new FacturaDTO();
            //wachaDTO.fecha = txtFecha.;
            //wachaDTO.fecha = dateTimePicker1.Value;
            wachaDTO.empresa = (int)this.comboBox1.SelectedValue; //txtRubro.Text;    //agrego el combobox del rubro
            return wachaDTO;
        
        }

        private void populateDataGridView(List<FacturaDTO> rendDTO)
        {
            var bindingList = new BindingList<FacturaDTO>(rendDTO);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        
        private void btnRendir_Click(object sender, EventArgs e)
        {
            
            RendicionDTO rendicionToSave = PantallaARendicionDTO();
            //todo mandar al business la rendicion
            businessRendicionImpl.saveRendicion(rendicionToSave);
            MessageBox.Show("Se rindieron las facturas");         

        }

        private RendicionDTO PantallaARendicionDTO()
        {
            RendicionDTO rendicionDTO = new RendicionDTO();
            rendicionDTO.fecha = dateTimePicker1.Value;
            rendicionDTO.importe = Convert.ToSingle(txtTotal.Text);
            rendicionDTO.porcentaje = Convert.ToSingle(txtPorcCom.Text);
            rendicionDTO.idFact = facturasID;
            return rendicionDTO;

        }




        private void RendicionForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.prevForm.Show();
        }

    }

}
