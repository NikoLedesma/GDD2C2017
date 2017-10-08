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

namespace PagoAgilFrba.AbmRol
{
    public partial class AltaRolForm : Form
    {
        private RolForm prevForm;
        private BusinessRolImpl businessRolImpl;
        private static String FUNC_LIST_BOX_MEMBER = "Nombre";
        private static String CREATE_MSG ="Rol CREADO";
        private static String  NOT_OK_CREATE_MSG="No se pudo crear el rol, puede que ya exista";
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
            List<FuncionalidadDTO> listSelectedFuncDTO = new List <FuncionalidadDTO>();
                foreach (var item in funcionalidadesListBox.SelectedItems){
                    listSelectedFuncDTO.Add((FuncionalidadDTO) item);
                }

            RolDTO rolDTO = new RolDTO(txtRolName.Text, true, listSelectedFuncDTO);
            try { 
                businessRolImpl.addRol(rolDTO);
                MessageBox.Show(CREATE_MSG);
            }catch(Exception ){
                MessageBox.Show(NOT_OK_CREATE_MSG);
            }
        }

        private void AltaRolForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            prevForm.updateListRol();
            prevForm.Show();
        }
        
    }
}
