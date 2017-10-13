using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.AbmSucursal;
using PagoAgilFrba.AbmRol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.UTILS
{
    
    
    public class FactoryFormMenu
    {
        
        public Form getFormMenu(String selectedTag,Form prevForm){
            Form form = null;
            if(selectedTag.Equals("ABM de Rol")){
                form = new RolForm(prevForm);
            }else if(selectedTag.Equals("Login y Seguridad")){
                form = null;
            }else if(selectedTag.Equals("Registro de Usuario")){
                form = new RolForm(prevForm);
            }else if(selectedTag.Equals("ABM de Cliente")){
                form = new AltaClienteForm(prevForm);
            }else if(selectedTag.Equals("ABM de Empresa")){
                form = new RolForm(prevForm);
            }else if(selectedTag.Equals("ABM de Sucursal")){
                form = new altaSucursalForm(prevForm);
            }else if(selectedTag.Equals("ABM Facturas")){
                form = new RolForm(prevForm);
            }else if(selectedTag.Equals("Registro de Pago de Facturas")){
                form = new RolForm(prevForm);
            }else if(selectedTag.Equals("Rendicion de Facturas cobradas")){
                form = new RolForm(prevForm);
            }else if(selectedTag.Equals("Listado Estadistico")){
                form = new RolForm(prevForm);
            }
            return form;
        }


    }



}
