using Business;
using DTO;
using DTO.Enums;
using PagoAgilFrba.MenuRol;
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

        static private String MSG_LOGIN_SUCCESSFUL = "Logueado";
        static private String MSG_INCORRECT_PASSWORD = "Password Incorrecta";
        static private String MSG_ATTEMPS_EXCEDED = "Intentos Excedidos";
        static private String MSG_NOT_EXIST_USUARIO = "Usuario incorrecto";
        static private String MSG_EMPTY_FIELDS = "Falta completar campos";
        static private String MSG_ZERO_ROL = "Su usuario no posee ningun rol habilitado.";
        private BusinessLoginImpl businessLogin;
        private LoginFormDTO loginFormDTO;
        private UsuarioDTO usuarioDTO;
        private MenuRolForm menuRolForm;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (anyEmptyField())
            {
                usuarioDTO = new UsuarioDTO(this.txtBoxUsername.Text, this.txtBoxPassword.Text);
                businessLogin = new BusinessLoginImpl();
                loginFormDTO = businessLogin.checkLogin(usuarioDTO);
                if (loginFormDTO.isLoginSuccessful())
                {
                    showMenuRolForm();
                }
                else
                {
                    showUnsuccessful();
                }
            }
            else
            {
                MessageBox.Show(MSG_EMPTY_FIELDS);
            }

        }


        void showMenuRolForm()
        {
            MessageBox.Show(MSG_LOGIN_SUCCESSFUL);
            menuRolForm = new MenuRolForm(this);
            try{ menuRolForm.Show();}
            catch (System.ObjectDisposedException) { MessageBox.Show(MSG_ZERO_ROL); }
        }

        void showUnsuccessful()
        {
            if (loginFormDTO.isIncorrectPassword())
            {
                MessageBox.Show(MSG_INCORRECT_PASSWORD);
            }
            else if (loginFormDTO.isExcededAttempsLimit())
            {
                MessageBox.Show(MSG_ATTEMPS_EXCEDED);
            }
            else if (loginFormDTO.notExistUsuario())
            {
                MessageBox.Show(MSG_NOT_EXIST_USUARIO);
            }
        }

        Boolean anyEmptyField()
        {
            return !string.IsNullOrWhiteSpace(this.txtBoxUsername.Text) && !string.IsNullOrWhiteSpace(this.txtBoxPassword.Text);
        }

        public UsuarioDTO getUsuarioDTO() {
            return this.usuarioDTO;
        }

    }

}
