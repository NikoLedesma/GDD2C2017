using Business;
using DTO;
using PagoAgilFrba.MenuPrincipal;
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

namespace PagoAgilFrba.MenuRol
{
    public partial class MenuRolForm : Form
    {

        private BusinessRolImpl businessRol;
        private UsuarioDTO usuarioDTO;
        private List<RolDTO> rolDTOS;
        private RolDTO selectedRolDTO;
        private static String RolListBoxMember = "Nombre";
        private LoginForm loginForm;
        private MenuSucursalForm menuPrincipalForm;

        public MenuRolForm(LoginForm loginForm)
        {
            InitializeComponent();
            businessRol = new BusinessRolImpl();
            this.loginForm = loginForm;
            this.usuarioDTO = loginForm.getUsuarioDTO();
            rolDTOS = businessRol.getEnabledRolesByUsuario(usuarioDTO);
            if (existAnyRol(rolDTOS))
            {
                InitializeListBoxRol();
                this.loginForm.Hide();
            }
            else
            {
                this.Dispose();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            selectedRolDTO = (RolDTO)rolMenuListBox.SelectedItem;
            showMenuPrincipalForm();
        }


        void showMenuPrincipalForm()
        {
            GlobalUtils.rolGlobalDTO = this.getSelectedRolDTO();
            menuPrincipalForm = new MenuSucursalForm(this);


            try { menuPrincipalForm.Show(); }
            catch (System.ObjectDisposedException) {  }


        }

        void InitializeListBoxRol()
        {
            rolMenuListBox.DisplayMember = RolListBoxMember;
            rolMenuListBox.ValueMember = RolListBoxMember;
            rolMenuListBox.DataSource = rolDTOS;
        }

        private Boolean existAnyRol(List<RolDTO> rolDTOS)
        {
            return rolDTOS != null && rolDTOS.Count > 0;
        }

        private Boolean existOnlyOneRol(List<RolDTO> rolDTOS)
        {
            return rolDTOS.Count == 1;
        }


        private void MenuRolForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.loginForm.Show();
        }

        public RolDTO getSelectedRolDTO()
        {
            return this.selectedRolDTO;
        }


    }
}
