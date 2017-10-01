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
    public partial class RolForm : Form
    {

        private BusinessRolImpl businessRolImpl;

        public RolForm()
        {
            InitializeComponent();
            btnRemoveFromRol.Enabled = false;
            btnAddToRol.Enabled = false;
            btnDeleteRol.Enabled = false;
            btnAddRol.Enabled = false;
            businessRolImpl = new BusinessRolImpl();
            List<RolDTO> listRolDTO = businessRolImpl.getAllRolesWithFunctionalidades();
            listRolDTO.ForEach(rolDTOSource => populateRolTreeView(rolDTOSource));
        }

        private void populateRolTreeView(RolDTO rolDTOSource)
        {
            List<FuncionalidadDTO> listFuncionalidadDTO = rolDTOSource.listFuncionalidadDTO;
            List<TreeNode> listNodeFuncionalidad = new List<TreeNode>();
            TreeNode treeNode;
            if (rolDTOSource.Habilitado)
            {
                listFuncionalidadDTO.ForEach(funcionalidadDTOSource => { listNodeFuncionalidad.Add(new TreeNode(funcionalidadDTOSource.Nombre)); });
                treeNode = new TreeNode(rolDTOSource.Nombre, listNodeFuncionalidad.ToArray());
            }
            else
            {
                listFuncionalidadDTO.ForEach(funcionalidadDTOSource => { createTreeFuncNodeWithColorRed(listNodeFuncionalidad, funcionalidadDTOSource.Nombre); });
                treeNode = new TreeNode(rolDTOSource.Nombre, listNodeFuncionalidad.ToArray());
                treeNode.ForeColor = Color.Gray;
            }
            rolTreeView.Nodes.Add(treeNode);
        }

        public void createTreeFuncNodeWithColorRed( List<TreeNode> listNodeFuncionalidad, String Nombre){
            TreeNode treeNode= new TreeNode(Nombre);
            treeNode.ForeColor = Color.Gray;
            listNodeFuncionalidad.Add(treeNode);
        }


        private void rolTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView rolTreeView = (TreeView)sender;
            if (isAParentNode(rolTreeView.SelectedNode))
            {
                btnDeleteRol.Enabled = true;
                btnRemoveFromRol.Enabled = false;
                btnAddToRol.Enabled = false;
                rolTreeView.SelectedNode.Expand();
                populateFuncionalidadTreeView(rolTreeView.SelectedNode);
            }
            else
            {
                btnDeleteRol.Enabled = false;
                btnRemoveFromRol.Enabled = true;
                btnAddToRol.Enabled = false;
                populateFuncionalidadTreeView(rolTreeView.SelectedNode.Parent);
            }

        }


        private void rolTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeView rolTreeView = (TreeView)sender;

            if (Color.Gray == e.Node.ForeColor)
            {
                e.Cancel = true;
            }

        }


        private void funcionalidadTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnAddToRol.Enabled = true;
            btnDeleteRol.Enabled = false;
        }

        private void populateFuncionalidadTreeView(TreeNode parentRolNode)
        {
            funcionalidadTreeView.Nodes.Clear();
            List<FuncionalidadDTO> funcionalidadDTONotAddedList = businessRolImpl.getFuncionalidadesNotAddedByRolName(parentRolNode.Text);
            funcionalidadDTONotAddedList.ForEach(x => { funcionalidadTreeView.Nodes.Add(x.Nombre); });
        }

        private void btnRemoveFromRol_Click(object sender, EventArgs e)
        {
            if (isANodeSelected(rolTreeView.SelectedNode) && !isAParentNode(rolTreeView.SelectedNode))
            {
                businessRolImpl.removeFuncionalidadFromRol(SelectedFuncRolDTO.create(rolTreeView.SelectedNode.Parent.Text, rolTreeView.SelectedNode.Text));
                populateFuncionalidadTreeView(rolTreeView.SelectedNode.Parent);
                TreeNode parent = rolTreeView.SelectedNode.Parent;
                rolTreeView.Nodes.Remove(rolTreeView.SelectedNode);
                rolTreeView.SelectedNode = parent;
                rolTreeView.Focus();
                btnRemoveFromRol.Enabled = false;
            }
        }

        private void btnAddToRol_Click(object sender, EventArgs e)
        {
            if (isANodeSelected(funcionalidadTreeView.SelectedNode) && (isANodeSelected(rolTreeView.SelectedNode)))
            {
                SelectedFuncRolDTO selectedFuncRolDTO = SelectedFuncRolDTO.create(getNameParent(rolTreeView.SelectedNode), funcionalidadTreeView.SelectedNode.Text);
                businessRolImpl.addFuncionalidadToRol(selectedFuncRolDTO);
                addFuncionalidadNodeToRolTree(rolTreeView.SelectedNode);
                funcionalidadTreeView.Nodes.Remove(funcionalidadTreeView.SelectedNode);
                populateFuncionalidadTreeView(isAParentNode(rolTreeView.SelectedNode) ? rolTreeView.SelectedNode : rolTreeView.SelectedNode.Parent);
                btnAddToRol.Enabled = false;

                if (isAParentNode(rolTreeView.SelectedNode))
                {
                    btnDeleteRol.Enabled = true;
                    rolTreeView.Focus();
                }
            }
        }

        private Boolean isANodeSelected(TreeNode node)
        {
            return node != null;
        }

        private Boolean isAParentNode(TreeNode node)
        {
            return node.Parent == null;
        }

        private String getNameParent(TreeNode node)
        {
            return isAParentNode(node) ? node.Text : node.Parent.Text;
        }

        private void disableButton(Button btn)
        {
            btn.Enabled = false;
        }

        private void enableButton(Button btn)
        {
            btn.Enabled = true;
        }

        private void addFuncionalidadNodeToRolTree(TreeNode node)
        {
            if (isAParentNode(rolTreeView.SelectedNode))
            {
                rolTreeView.SelectedNode.Nodes.Add((TreeNode)funcionalidadTreeView.SelectedNode.Clone());
            }
            else
            {
                rolTreeView.SelectedNode.Parent.Nodes.Add((TreeNode)funcionalidadTreeView.SelectedNode.Clone());
            }
        }

        private void btnDeleteRol_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desea eliminar el rol" + rolTreeView.SelectedNode.Text, "Baja de rol", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                RolDTO rolDTO = new RolDTO(rolTreeView.SelectedNode.Text, false);
                List<RolDTO> listRolDTO = businessRolImpl.deleteRol(rolDTO);
                rolTreeView.Nodes.Clear();
                funcionalidadTreeView.Nodes.Clear();
                listRolDTO.ForEach(rolDTOSource => populateRolTreeView(rolDTOSource));
                btnDeleteRol.Enabled = false;
            }
            else if (dialogResult == DialogResult.No)
            {
                ///NOTHING
            }
        }

        private void btnAddRol_Click(object sender, EventArgs e)
        {

        }
    }
}
