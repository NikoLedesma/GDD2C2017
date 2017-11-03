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
        private BusinessDevolucionImpl businessDevolucionImpl;
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
            
            //MessageBox.Show("empresa:" + listEmpresaDTO[0].id);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            EmpresaDTO empresaSelected = (EmpresaDTO)this.comboBox1.SelectedItem;

            int empresaId = empresaSelected.id;
            if (empresaId > 0)
            {

                businessRendicionImpl = new BusinessRendicionImpl();

                listRendicionDTOs = businessRendicionImpl.getRendByEmpresa(empresaId);

                this.comboBox2.DataSource = listRendicionDTOs;
                this.comboBox2.ValueMember = "id";
                this.comboBox2.DisplayMember = "fecha";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DevolucionDTO devolucionDTO = new DevolucionDTO();
            devolucionDTO.idRendicion = (int)this.comboBox2.SelectedValue;
            devolucionDTO.razon = this.textBox1.Text;
            businessDevolucionImpl = new BusinessDevolucionImpl();

            int resu = businessDevolucionImpl.saveDevolucion(devolucionDTO);
            MessageBox.Show("La devolucion se dio con exito, resu:" + resu);
        }
    }
}
