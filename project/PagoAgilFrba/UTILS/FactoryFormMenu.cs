using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.AbmSucursal;
using PagoAgilFrba.AbmRol;
using PagoAgilFrba.AbmEmpresa;
using PagoAgilFrba.AbmFactura;
using PagoAgilFrba.Rendicion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.RegistroPago;

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
                form = new ModClienteForm(prevForm);
            }else if(selectedTag.Equals("ABM de Empresa")){
                form = new ModEmpresaForm(prevForm);
            }else if(selectedTag.Equals("ABM de Sucursal")){
                form = new ModSucursalForm(prevForm);
            }else if(selectedTag.Equals("ABM Facturas")){
                form = new modFacturaForm(prevForm);
            }else if(selectedTag.Equals("Registro de Pago de Facturas")){
                form = new RegistroDePagoForm(prevForm);
            }else if(selectedTag.Equals("Rendicion de Facturas cobradas")){
                form = new RendicionForm(prevForm);
            }else if(selectedTag.Equals("Listado Estadistico")){
                form = new RolForm(prevForm);
            }
            return form;
        }


    }



}
