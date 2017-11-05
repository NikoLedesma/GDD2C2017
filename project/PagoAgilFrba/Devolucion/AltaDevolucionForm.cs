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
            this.comboBox2.DataSource = null;
            this.comboBox2.Items.Clear();
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
            if (this.comboBox2.SelectedValue != null)
                devolucionDTO.idRendicion = (int)this.comboBox2.SelectedValue;

            devolucionDTO.razon = this.textBox1.Text;
            if (devolucionDTO.idRendicion <= 0)
            {
                MessageBox.Show("La empresa no tiene Devoluciones disponibles");
                return;
            }
            if (string.IsNullOrEmpty(devolucionDTO.razon))
                MessageBox.Show("Ingrese un motivo");
            else
            {
                businessDevolucionImpl = new BusinessDevolucionImpl();

                int resu = businessDevolucionImpl.saveDevolucion(devolucionDTO);
                MessageBox.Show("La devolucion se dio con exito, resu:" + resu);
            }
        }
    }
}
