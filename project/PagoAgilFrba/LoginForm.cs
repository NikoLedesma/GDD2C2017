using Business;
using DTO;
using DTO.Enums;
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
        private LoginFormDTO loginFormDTO;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO(this.txtBoxUsername.Text, this.txtBoxPassword.Text);
            businessUsuario = new BusinessUsuarioImpl();
            businessRol = new BusinessRolImpl();
            loginFormDTO = businessUsuario.checkLogin(usuarioDTO);

            if(ResultCheckLogin.LOGIN_SUCCESSFUL == loginFormDTO.resultCheckLogin){
                //List<RolDTO> rolesDTO = businessRol.getRolesByUsuario(usuarioDTO);
                MessageBox.Show("Logueado");
            }
            else if (ResultCheckLogin.INCORRECT_PASSWORD == loginFormDTO.resultCheckLogin)
            {
                MessageBox.Show("Password Incorrecta");
            }
            else if (ResultCheckLogin.ATTEMPS_EXCEDED == loginFormDTO.resultCheckLogin)
            {
                MessageBox.Show("Intentos Excedidos");
            }
            else if (ResultCheckLogin.NOT_EXIST_USUARIO == loginFormDTO.resultCheckLogin)
            {
                MessageBox.Show("Usuario incorrecto");
            }

            /*if (successLogin)
            {
            List <RolDTO> rolesDTO = businessRol.getRolesByUsuario(usuarioDTO);
                MessageBox.Show(rolesDTO.Count.ToString());
            }else{
                MessageBox.Show("No Logueado");
            }
            this.Close();*/
        }
    }
}
