using Business;
using DTO;
using PagoAgilFrba.MenuPrincipal;
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

namespace PagoAgilFrba.MenuSucursal
{
    public partial class MenuSucursalForm : Form
    {
        private Form prevForm;
        private SucursalDTO selectedSucursalDTO;
        private MenuPrincipalForm menuPrincipalForm;
        private BusinessSucursalImpl businessSucursal;
        private List<SucursalDTO> sucursalDTOS;
        private static String RolListBoxDisplayMember = "nombre";
        private static String RolListBoxValueMember = "id";
            
        private static String MSG_NOT_EXIST_SUCURSAL = "NO EXISTE NINGUNA SUCURSAL ACTIVA PARA EL USUARIO";

        public MenuSucursalForm(Form form)
        {
            InitializeComponent();
            prevForm = form;
            businessSucursal = new BusinessSucursalImpl();
            sucursalDTOS = businessSucursal.getEnabledSucursalesByUsuario(GlobalUtils.usuarioGlobalDTO);
            if (existAnySucursal(sucursalDTOS))
            {
                InitializeListBoxRol();
                prevForm.Hide();
            }
            else
            {
                MessageBox.Show(MSG_NOT_EXIST_SUCURSAL);
                this.Dispose();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            selectedSucursalDTO = (SucursalDTO)sucursalMenuListBox.SelectedItem;
            showMenuPrincipalForm();
        }



        void InitializeListBoxRol()
        {
            sucursalMenuListBox.DisplayMember = RolListBoxDisplayMember;
            sucursalMenuListBox.ValueMember = RolListBoxValueMember;
            sucursalMenuListBox.DataSource = sucursalDTOS;
        }

        void showMenuPrincipalForm()
        {
            GlobalUtils.sucursalGlobalDTO = this.selectedSucursalDTO;
            menuPrincipalForm = new MenuPrincipalForm(this);
            menuPrincipalForm.Show();
        }


        private Boolean existAnySucursal(List<SucursalDTO> sucursalDTOS)
        {
            return sucursalDTOS != null && sucursalDTOS.Count > 0;
        }



        private void MenuSucursalForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.prevForm.Show();
        }


    }
}
