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

namespace PagoAgilFrba.Devolucion
{
    public partial class AltaDevolucionForm : Form
    {   
        private Form prevForm;
        private BusinessFacturaImpl businessFacturaImpl;
        private BusinessClienteImpl businessClienteImpl;
        private BusinessEmpresaImpl businessEmpresaImpl;
        private BusinessRendicionImpl businessRendicionImpl;
        private List<ClienteDTO> listClienteDTO;
        private List<EmpresaDTO> listEmpresaDTO;
        private List<ItemFacturaDTO> listItemDTOs;
        private List<RendicionDTO> listRendicionDTOs;

        public AltaDevolucionForm(Form prevForm)
        {
            InitializeComponent();
            businessFacturaImpl = new BusinessFacturaImpl();
            businessClienteImpl = new BusinessClienteImpl();
            businessEmpresaImpl = new BusinessEmpresaImpl();
            businessRendicionImpl = new BusinessRendicionImpl();

            listEmpresaDTO = businessEmpresaImpl.getEmpresas();
            this.comboBox1.DataSource = listEmpresaDTO;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DisplayMember = "cuit";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            int empresaId = (int)cmb.SelectedValue;


            //int empresaId = (string) this.comboBox1.SelectedValue;
            businessRendicionImpl = new BusinessRendicionImpl();

            listRendicionDTOs = businessRendicionImpl.getRendByEmpresa(empresaId);

            this.comboBox1.DataSource = listRendicionDTOs;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DisplayMember = "numero";
        }
    }
}
