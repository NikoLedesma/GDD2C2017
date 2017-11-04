using Business;
using DTO;
using DTO.Enums;
using PagoAgilFrba.AbmRol;
using PagoAgilFrba.MenuPrincipal;
using PagoAgilFrba.MenuRol;
using PagoAgilFrba.MenuSucursal;
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
        static private String MSG_ONLY_ONE_ROL = "El rol {0} es el unico rol habilitado del usuario {1}";
        private BusinessLoginImpl businessLogin;
        private BusinessRolImpl businessRol;
        private LoginFormDTO loginFormDTO;
        private UsuarioDTO usuarioDTO;
        private Form form;

        public LoginForm()
        {
            InitializeComponent();
            businessLogin = new BusinessLoginImpl();
            businessRol = new BusinessRolImpl();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (anyEmptyField())
            {
                usuarioDTO = new UsuarioDTO(this.txtBoxUsername.Text, GlobalUtils.GetSHA256(this.txtBoxPassword.Text));
                loginFormDTO = businessLogin.checkLogin(usuarioDTO);
                if (loginFormDTO.isLoginSuccessful())
                {
                    GlobalUtils.usuarioGlobalDTO = usuarioDTO;
                    showMenuRolFormOrMenuPpalForm();
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


        void showMenuRolFormOrMenuPpalForm()
        {
            MessageBox.Show(MSG_LOGIN_SUCCESSFUL);
            if (userHaveOnlyOneEnabledRol(usuarioDTO))
            {
                RolDTO rolDTO = this.getTheOnlyOneEnabledRol(usuarioDTO);
                GlobalUtils.rolGlobalDTO = rolDTO;
                MessageBox.Show(String.Format(MSG_ONLY_ONE_ROL, rolDTO.Nombre, usuarioDTO.Username));
                form = new MenuSucursalForm(this);
            }
            else {
                form = new MenuRolForm(this);
            }
            try { form.Show(); }
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


        public Boolean userHaveOnlyOneEnabledRol(UsuarioDTO usuarioDTO)
        {
            return businessRol.getEnabledRolesByUsuario(usuarioDTO).Count == 1 ;
        }


        public RolDTO getTheOnlyOneEnabledRol(UsuarioDTO usuarioDTO)
        {
            return businessRol.getEnabledRolesByUsuario(usuarioDTO)[0];
        }

    }

}
