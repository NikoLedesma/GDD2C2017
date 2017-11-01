using Business;
using DTO;
using PagoAgilFrba.MenuRol;
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

namespace PagoAgilFrba.MenuPrincipal
{
    public partial class MenuPrincipalForm : Form
    {
        
        private MenuPrincipalBusiness menuPrincipalBusiness;
        private List<FuncionalidadDTO> listFuncionalidadDTO;
        private List<Button> buttons;
        private FactoryFormMenu factoryFormMenu;
        private Form selectedFormOption;
        static private String labelException = "Problema con el funcionamiento de la opcion seleccionada:" ;
        private Form prevForm;
        private RolDTO rolDTO;
        int top;

        public MenuPrincipalForm(Form menuRolForm)
        {
            InitializeComponent();
            factoryFormMenu = new FactoryFormMenu();
            this.prevForm = menuRolForm;
            menuRolForm.Hide();
            this.rolDTO = GlobalUtils.rolGlobalDTO;
            buttons = new List<Button>();
            InitializeButtons();
        }


        public void InitializeButtons()
        {
            top = 50;
            buttons.ForEach(x => { this.Controls.Remove(x); });
            menuPrincipalBusiness = new MenuPrincipalBusiness();
            listFuncionalidadDTO = menuPrincipalBusiness.getFuncionalidadByRol(rolDTO);
            listFuncionalidadDTO.ForEach(x => { addButtons(x); });
        }

        private void addButtons(FuncionalidadDTO funcionalidadDTO) {
            Button newButton = new Button();
            SizeF size = CreateGraphics().MeasureString(funcionalidadDTO.Nombre, newButton.Font);
            newButton.AutoSize = true;
            newButton.Text = funcionalidadDTO.Nombre;
            newButton.Left = (this.Width / 2) - (int) (size.Width / 2);
            newButton.Top = top;
            newButton.Click += new EventHandler(showForm);
            buttons.Add(newButton);
            top += newButton.Height + 5;
            this.Controls.Add(newButton);   
        }

        protected void showForm(object sender, EventArgs e)
        {
            string selectedTag = ((Button)sender).Text;
            selectedFormOption = factoryFormMenu.getFormMenu(selectedTag,this);
            try{
                selectedFormOption.Show();
            }
            catch ( Exception ex){
                MessageBox.Show( labelException + ex.Message);
            }
        }

        private void MenuPrincipalForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            prevForm.Show();
        }

    }
}
