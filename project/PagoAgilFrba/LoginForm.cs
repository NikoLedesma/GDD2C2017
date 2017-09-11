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

namespace PagoAgilFrba
{
    public partial class LoginForm : Form
    {

        private BusinessUsuarioImpl businessUsuario;
        private BusinessRolImpl businessRol;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO(this.txtBoxUsername.Text, this.txtBoxPassword.Text);
            businessUsuario = new BusinessUsuarioImpl();
            businessRol = new BusinessRolImpl();
            Boolean successLogin = businessUsuario.checkLogin(usuarioDTO);
            if (successLogin)
            {
            List <RolDTO> rolesDTO = businessRol.getRolesByUsuario(usuarioDTO);
                MessageBox.Show(rolesDTO.Count.ToString());
            }else{
                MessageBox.Show("No Logueado");
            }
            this.Close();
        }
    }
}
