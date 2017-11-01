using Business;
using DTO;
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

namespace PagoAgilFrba.AbmRol
{
    public partial class AltaRolForm : Form
    {
        private RolForm prevForm;
        private BusinessRolImpl businessRolImpl;
        private static String FUNC_LIST_BOX_MEMBER = "Nombre";
        private static String CREATE_MSG ="ROL CREADO";
        private static String NOT_OK_CREATE_MSG ="NO SE PUDO CREAR EL ROL, PUEDE QUE YA EXISTA";
        private static String MSG_NAME_ROL_ALREADY_EXISTS = "EL NOMBRE DEL ROL INGRESADO YA EXISTE, INGRESE OTRO";
        private static String MSG_IS_NOT_ANY_SELECTED = "NO SELECCIONO NINGUNA FUNCIONALIDAD";

        public AltaRolForm( RolForm form)
        {
            InitializeComponent();
            prevForm = form;
            prevForm.Hide();
            businessRolImpl = new BusinessRolImpl();
            InitializeFuncionalidadesListBox();
        }

        void InitializeFuncionalidadesListBox()
        {
            List <FuncionalidadDTO> funcionalidadDTOS =businessRolImpl.getAllFunctionalidades();
            funcionalidadesListBox.DisplayMember = FUNC_LIST_BOX_MEMBER;
            funcionalidadesListBox.ValueMember = FUNC_LIST_BOX_MEMBER;
            funcionalidadesListBox.DataSource = funcionalidadDTOS; 
        }

        private void btnAddRol_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                List<FuncionalidadDTO> listSelectedFuncDTO = new List <FuncionalidadDTO>();
                foreach (var item in funcionalidadesListBox.SelectedItems){
                    listSelectedFuncDTO.Add((FuncionalidadDTO) item);
                }
                RolDTO rolDTO = new RolDTO(txtRolName.Text, true, listSelectedFuncDTO);
                try { 
                    businessRolImpl.addRol(rolDTO);
                    MessageBox.Show(CREATE_MSG);
                    this.Close();
                }catch(Exception ){
                    MessageBox.Show(NOT_OK_CREATE_MSG);
                }
            }
        }



        private Boolean validateForm(){
         return Validator.validateEmptyTextBox(txtRolName, " ROL ") && !isExistingName(txtRolName) && isAtLeastOneFuncSelected();
        }

        private Boolean isExistingName(TextBox txtRolName)
        {
            Boolean isExistingName = businessRolImpl.isExistingName(txtRolName.Text);
            if (isExistingName)
            {
                MessageBox.Show(MSG_NAME_ROL_ALREADY_EXISTS);
            }
            return isExistingName;
        }


        private Boolean isAtLeastOneFuncSelected()
        {
            Boolean isAtLeastOneFuncSelected = funcionalidadesListBox.SelectedItems.Count>0?true:false;
            if (!isAtLeastOneFuncSelected)
            {
                MessageBox.Show(MSG_IS_NOT_ANY_SELECTED);
            }
            return isAtLeastOneFuncSelected;
        }



        private void AltaRolForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            prevForm.updateListRol();
            prevForm.Show();
        }
        
    }
}
