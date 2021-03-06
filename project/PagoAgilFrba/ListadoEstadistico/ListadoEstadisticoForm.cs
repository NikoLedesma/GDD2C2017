﻿using Business;
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

            if (!String.IsNullOrEmpty(trimestre))
            {
                listStadistico = businessFacturaImpl.getPorcFactCobradas(trimestre);
                populateDataGridView1(listStadistico);
                
            }
        }
        private void populateDataGridView1(List<ListStadisticoDTO> list)
        {

            list.ForEach(x => { this.dataGridView1.Rows.Add(convertertoRowEmpr(x)); });
        }
        private DataGridViewRow convertertoRowCLie(ListStadisticoDTO item)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = item.id;
            row.Cells[1].Value = item.nombre;
            row.Cells[2].Value = item.dni;
            row.Cells[3].Value = item.total;
            return row;
        }
        private DataGridViewRow convertertoRowEmpr(ListStadisticoDTO item)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = item.id;
            row.Cells[1].Value = item.nombre;
            row.Cells[2].Value = item.cuit;
            row.Cells[3].Value = item.total;
            return row;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trimestre = (string)this.comboBox2.SelectedItem;
            List<ListStadisticoDTO> listStadistico;
            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Refresh();

            if (!String.IsNullOrEmpty(trimestre))
            {
                listStadistico = businessFacturaImpl.getEmprMayorRendidas(trimestre);
                populateDataGridView2(listStadistico);

            }
        }
        private void populateDataGridView2(List<ListStadisticoDTO> list)
        {

            list.ForEach(x => { this.dataGridView2.Rows.Add(convertertoRowEmpr(x)); });
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trimestre = (string)this.comboBox3.SelectedItem;
            List<ListStadisticoDTO> listStadistico;
            this.dataGridView3.Rows.Clear();
            this.dataGridView3.Refresh();

            if (!String.IsNullOrEmpty(trimestre))
            {
                listStadistico = businessFacturaImpl.getClieConMasPagos(trimestre);
                populateDataGridView3(listStadistico);

            }
        }
        private void populateDataGridView3(List<ListStadisticoDTO> list)
        {

            list.ForEach(x => { this.dataGridView3.Rows.Add(convertertoRowCLie(x)); });
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trimestre = (string)this.comboBox4.SelectedItem;
            List<ListStadisticoDTO> listStadistico;
            this.dataGridView4.Rows.Clear();
            this.dataGridView4.Refresh();

            if (!String.IsNullOrEmpty(trimestre))
            {
                listStadistico = businessFacturaImpl.getClieCumplidores(trimestre);
                populateDataGridView4(listStadistico);

            }
        }
        private void populateDataGridView4(List<ListStadisticoDTO> list)
        {

            list.ForEach(x => { this.dataGridView4.Rows.Add(convertertoRowCLie(x)); });
        }
    }
}
