﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmpresaDTO
    {

        public int id { get; set; }
        public String nombre { get; set; }
        public String cuit { get; set; }
        public String direccion { get; set; }
        public String rubro { get; set; }
        public Boolean habilitado { get; set; }

    }

}