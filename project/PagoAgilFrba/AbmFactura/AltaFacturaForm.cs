﻿using Business;
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
        private List<ItemFacturaDTO> listItemDTOs;
        

        private EnumFormMode formMode;
        private static String ALTA_TITLE = "ALTA DE Factura";
        private FacturaDTO facturaDTOToUpdateOrSave;
        private static String MODIF_TITLE = "MODIFICACION DE FACTURA(ID:{0})";

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
        public AltaFacturaForm(Form form,EnumFormMode enumFormMode,FacturaDTO cl)
        {
            InitializeComponent();
            businessClienteImpl = new BusinessClienteImpl();
            prevForm = form;
            form.Hide();
            formMode = enumFormMode;
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

            if (formMode == EnumFormMode.MODE_ALTA)
            {

                this.Text = ALTA_TITLE;
                this.facturaDTOToUpdateOrSave = new FacturaDTO();
                //disabledRadioButtons();
            }

            if (formMode == EnumFormMode.MODE_MODIFICACION)
            {
                this.Text = String.Format(MODIF_TITLE, cl.id);
                this.facturaDTOToUpdateOrSave = cl;
                populateAllInputsToModify(cl);
            }
        }
        private void populateAllInputsToModify(FacturaDTO fc)
        {
            this.comboBox1.SelectedValue = fc.cliente; //txtCliente.Text;
            this.comboBox2.SelectedValue = fc.empresa;//txtEmpresa.Text; //falta ponerlo acotado
            txtNroFact.Text = fc.nroFact.ToString();
            dateTimePickerAlta.Value = fc.fechaDeAlta;
            dateTimePickerVencimiento.Value = fc.fechaDeVencimiento;
            txtTotal.Text = fc.total.ToString();

           listItemDTOs = businessFacturaImpl.getItems(fc.id);
           populateDataGridView(listItemDTOs);
           /* DataTable dt = new DataTable();
            dt.Columns.Add("Monto", typeof(float));
            dt.Columns.Add("Cantidad", typeof(int));

            DataRow row;
            row = dt.NewRow();

            row["Monto"] = 200;
            row["Cantidad"] = 1;
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["Monto"] = 400;
            row["Cantidad"] = 2;
            dt.Rows.Add(row);

            foreach (DataRow dr in dt.Rows)
            {

                this.dataGridView1.Rows.Add(dr.ItemArray);

            }*/
            

        }
        private void populateDataGridView(List<ItemFacturaDTO> list)
        {

            list.ForEach(x => { this.dataGridView1.Rows.Add(converterItemDTOToRow(x)); });
            /*var bindingList = new BindingList<ItemFacturaDTO>(List);
            var source = new BindingSource(bindingList, null);
            this.dataGridView1.DataSource = source;*/
        }
        private DataGridViewRow converterItemDTOToRow(ItemFacturaDTO item)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = item.monto;
            row.Cells[1].Value = item.cantidad;
            return row;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FacturaDTO facturaDTO = new FacturaDTO();
            facturaDTO.cliente = (int)this.comboBox1.SelectedValue; //txtCliente.Text;
            facturaDTO.empresa = (int)this.comboBox2.SelectedValue;//txtEmpresa.Text; //falta ponerlo acotado
            facturaDTO.nroFact = Int32.Parse(txtNroFact.Text);
            facturaDTO.fechaDeAlta = dateTimePickerAlta.Value;
            facturaDTO.fechaDeVencimiento = dateTimePickerVencimiento.Value;
            facturaDTO.total = Int32.Parse(txtTotal.Text);

            //FALTA AGREGAR LA GRILLA DE LOS TOTAL ITEMS MONTO Y CANTIDAD

            
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
            facturaDTO.items = dt;
            int resu = businessFacturaImpl.saveFactura(facturaDTO);
            MessageBox.Show("Se dio de alta la FACTURA, resu:"+resu);
        }
        /*private void disabledRadioButtons()
        {
            radioBtnHabilitado.Select();
            radioBtnHabilitado.Enabled = false;
            radioBtnDeshabilitado.Enabled = false;
        }*/

    }

}
