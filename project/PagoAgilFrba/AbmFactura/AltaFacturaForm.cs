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
        private static String ALTA_TITLE = "ALTA DE FACTURA";
        private FacturaDTO facturaDTOToUpdateOrSave;
        private static String MODIF_TITLE = "MODIFICACION DE FACTURA" ; //(ID:{0})";

        private static String MSG_ERROR_SAVE = "ERROR:NO SE PUDO DAR DE ALTA A UNA FACTURA";
        private static String MSG_ERROR_UPDATE = "ERROR:NO SE PUDO ACTUALIZAR A LA FACTURA";

        private static String MSG_SUCCESS_SAVE = "LA FACTURA SE DIO DE ALTA";
        private static String MSG_SUCCESS_UPDATE = "LA FACTURA SE MODIFICO";
        DataTable dtItems = new DataTable();

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
           // MessageBox.Show("fc.habilitado" + fc.habilitado);
            if (fc.habilitado)
                radioBtnHabilitado.Checked = true;
            else
                radioBtnDeshabilitado.Checked = true;

    

            listItemDTOs = businessFacturaImpl.getItems(fc.id);
            
            dtItems.Columns.Add("monto", typeof(float));
            dtItems.Columns.Add("cantidad", typeof(int));
            dtItems.Columns.Add("id", typeof(int));

            listItemDTOs.ForEach(x => { converterItemListToRow(x, dtItems); });

            facturaDTOToUpdateOrSave.items = dtItems;
            populateDataGridView(listItemDTOs);
           

        }

        public DataRow converterItemListToRow(ItemFacturaDTO item, DataTable tabla)
        {

            DataRow row = tabla.NewRow();
            row["monto"] = item.monto;
            row["cantidad"] = item.cantidad;
            row["id"] = item.id;
            tabla.Rows.Add(row);
            return row;
        }

        private void populateDataGridView(List<ItemFacturaDTO> list)
        {
            list.ForEach(x => { this.dataGridView1.Rows.Add(converterItemDTOToRow(x)); });          
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
            if (validateFields())
            {
                FacturaDTO facturaDTO = new FacturaDTO();
                facturaDTO.cliente = (int)this.comboBox1.SelectedValue; //txtCliente.Text;
                facturaDTO.empresa = (int)this.comboBox2.SelectedValue;//txtEmpresa.Text; //falta ponerlo acotado
                facturaDTO.nroFact = Int32.Parse(txtNroFact.Text);
                facturaDTO.fechaDeAlta = dateTimePickerAlta.Value;
                facturaDTO.fechaDeVencimiento = dateTimePickerVencimiento.Value;
                facturaDTO.total = Convert.ToSingle(txtTotal.Text);
                facturaDTO.habilitado = radioBtnHabilitado.Checked;

                //FALTA AGREGAR LA GRILLA DE LOS TOTAL ITEMS MONTO Y CANTIDAD
                DataTable dt = new DataTable();
                dt.Columns.Add("monto", typeof(float));
                dt.Columns.Add("cantidad", typeof(int));
                dt.Columns.Add("id", typeof(int));

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

                if (formMode == EnumFormMode.MODE_ALTA)
                {
                    try
                    {
                        int resu = businessFacturaImpl.saveFactura(facturaDTO);
                        MessageBox.Show(MSG_SUCCESS_SAVE);
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(MSG_ERROR_SAVE);
                    }
                }

                if (formMode == EnumFormMode.MODE_MODIFICACION)
                {
                    try
                    {
                        facturaDTO.id = facturaDTOToUpdateOrSave.id;
                        DataRowCollection items = facturaDTO.items.Rows;
                        foreach (DataRow row in items)
                        {
                            int currentIndex = items.IndexOf(row);
                            row["id"] = facturaDTOToUpdateOrSave.items.Rows[currentIndex]["id"];
                            //MessageBox.Show("Agrego al DTO el id:" + row["id"]);
                        }
                        int resu = businessFacturaImpl.saveFactura(facturaDTO);
                        MessageBox.Show(MSG_SUCCESS_UPDATE);
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(MSG_ERROR_UPDATE);
                    }
                }

            }


        }
        /*private void disabledRadioButtons()
        {
            radioBtnHabilitado.Select();
            radioBtnHabilitado.Enabled = false;
            radioBtnDeshabilitado.Enabled = false;
        }*/

        private Boolean validateFields()
        {
            Boolean resu = validateEmptyFields() && Validator.validatePositiveFloatTextBoxBool(txtTotal, "EL TOTAL ES NEGATIVO");
            return resu;
        }

        private Boolean validateEmptyFields() 
        {
            Boolean result = Validator.validateEmptyTextBox(txtNroFact, "NRO FACTURA")
                                && Validator.validateEmptyTextBox(txtTotal, "TOTAL");
            return result;
        }



        private void AltaFacturaForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.prevForm.Show();
        }





    }

}
