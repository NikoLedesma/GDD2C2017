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


namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class ListadoEstadisticoForm : Form
    {
        private BusinessFacturaImpl businessFacturaImpl;
        private BusinessRegistroDePagoImpl businessRegistroDePagoImpl;
        private BusinessRendicionImpl businessRendicionImpl;

        DataTable porcFactCobradasPorEmpresa = new DataTable();
        DataTable empresasMasRendidas = new DataTable();
        DataTable clientesConMasPAgos = new DataTable();
        DataTable clientesMasCumplidores = new DataTable();

        public ListadoEstadisticoForm(Form form)
        {
            InitializeComponent();
            businessFacturaImpl = new BusinessFacturaImpl();
            businessRegistroDePagoImpl = new BusinessRegistroDePagoImpl();
            businessRendicionImpl = new BusinessRendicionImpl();

            var listTrimestresFacturas = businessFacturaImpl.getTrimestres();
            

            var listTrimestresPagos = businessRegistroDePagoImpl.getTrimestres();
            this.comboBox1.DataSource = listTrimestresPagos;
            this.comboBox3.DataSource = listTrimestresPagos;
            this.comboBox4.DataSource = listTrimestresPagos;

            var listTrimestresRendicion = businessRendicionImpl.getTrimestres();
            this.comboBox2.DataSource = listTrimestresRendicion;

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trimestre =(string)this.comboBox1.SelectedItem;
            List<ListStadisticoDTO> listStadistico;
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();
            //trimestre = "%" + trimestre + "%";
            //MessageBox.Show("trimestre:" + trimestre + ".");
            /*DataTable dt =  this.dataGridView1.Rows;
            if (dt != null)
                dt.Clear();*/
            if (!String.IsNullOrEmpty(trimestre))
            {
                listStadistico = businessFacturaImpl.getPorcFactCobradas(trimestre);
                populateDataGridView(listStadistico);
                
            }
        }
        private void populateDataGridView(List<ListStadisticoDTO> list)
        {

            list.ForEach(x => { this.dataGridView1.Rows.Add(convertertoRow(x)); });
        }
        private DataGridViewRow convertertoRow(ListStadisticoDTO item)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = item.id;
            row.Cells[1].Value = item.nombre;
            row.Cells[2].Value = item.cuit;
            row.Cells[3].Value = item.total;
            return row;
        }
    }
}
