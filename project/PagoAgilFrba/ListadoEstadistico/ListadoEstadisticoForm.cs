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
    }
}
