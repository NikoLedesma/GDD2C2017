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

namespace PagoAgilFrba.AbmCliente
{
    public partial class ModClienteForm : Form
    {


        private Form prevForm;


        public ModClienteForm(Form form)
        {
            InitializeComponent();
            form.Hide();
            this.prevForm = form;
            var list = new List <ClienteDTO> ();
            ClienteDTO clienteDTO = new ClienteDTO();
            clienteDTO.nombre ="PEPE" ;
            clienteDTO.apellido = "ARGENTO";
            ClienteDTO clienteDTOB = new ClienteDTO();
            clienteDTOB.nombre ="JUAN" ;
            clienteDTOB.apellido = "BENITEZ";
            list.Add(clienteDTO);
            list.Add(clienteDTOB);
            var bindingList =  new BindingList<ClienteDTO> (list);
            var source = new BindingSource(bindingList, null);
            dataGVClientes.DataSource =source;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }



        private void ModClienteForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.prevForm.Show();
        }






    }
}
