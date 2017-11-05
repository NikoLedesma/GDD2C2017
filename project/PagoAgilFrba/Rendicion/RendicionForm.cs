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
        
        //private static String MSG_EMAI_ALREADY_EXISTS = "LA FECHA DE RENDICION NO COINCIDE CON LA DE EMPRESA";

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
            this.comboBox1.DisplayMember = "nombre";

        }
      

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (verificarFechaEmpresa())
            {
                MessageBox.Show("EL DIA DE REINDICION COINCIDE");

                FacturaDTO rendiciones = pantallaFacturasDTO();
                filtroRendicionesDTOs = businessFacturaImpl.getFacturaByFilterRendicion(rendiciones); //Busco en la base de datos la empresa por filtros
                populateDataGridView(filtroRendicionesDTOs);

                int cantFact;
                cantFact = filtroRendicionesDTOs.Count;
                txtCantFact.Text = cantFact.ToString();

                float sumaFact = 0;
                filtroRendicionesDTOs.ForEach(x => { sumaFact = sumaFact + x.total; });

                facturasID = new DataTable();
                facturasID.Columns.Add("id", typeof(int));

                filtroRendicionesDTOs.ForEach(x => { addColumnInList(x, facturasID); });

                mostrarTotales(sumaFact);

            }
            else
            {
                MessageBox.Show("No hay empresas habilitadas que realicen rendiciones este dia - Por favor verifique la fecha de rendicion de la empresa seleccionada");
            }
  
        }

        private Boolean verificarFechaEmpresa()
        {
            EmpresaDTO empresaDTO = pantallaEmpresaDTO();
            Boolean result = businessEmpresaImpl.ifFechaRendicionIgual(empresaDTO);//verifica que sea la misma empresa y fecha
            return result;
        }

        private EmpresaDTO pantallaEmpresaDTO()
        {
            EmpresaDTO empresaDTO = new EmpresaDTO();
            empresaDTO.fechaRendicion = dateTimePicker1.Value;
            empresaDTO.id = (int)this.comboBox1.SelectedValue;
            return empresaDTO;
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
            if (rendicionToSave.idFact == null)
            {
                MessageBox.Show("Debe seleccionar las facturas a rendir.");
            }
            else
            {
                businessRendicionImpl.saveRendicion(rendicionToSave);
                MessageBox.Show("Se rindieron las facturas");
            }
        }

        private RendicionDTO PantallaARendicionDTO()
        {
            RendicionDTO rendicionDTO = new RendicionDTO();
            rendicionDTO.fecha = dateTimePicker1.Value;
            if (!String.IsNullOrEmpty(txtTotal.Text))
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
