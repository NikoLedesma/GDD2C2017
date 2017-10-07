using Business;
using DTO;
using PagoAgilFrba.MenuPrincipal;
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
        private MenuPrincipalForm menuPrincipalForm;

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
            menuPrincipalForm = new MenuPrincipalForm(this,this.getSelectedRolDTO());
            menuPrincipalForm.Show();
        }

        void InitializeListBoxRol()
        {
            rolMenuListBox.DisplayMember = RolListBoxMember;
            rolMenuListBox.ValueMember = RolListBoxMember;
            rolMenuListBox.DataSource = rolDTOS;
           // TODO : ver como solucioner en el caso que solo se tenga un rol
            /*if (existOnlyOneRol(rolDTOS))
            {
                selectedRolDTO = rolDTOS[0];
                showMenuPrincipalForm();
            }*/
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
