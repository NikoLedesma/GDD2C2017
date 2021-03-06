﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClienteDTO
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public int dni { get; set; }
        public String mail { get; set; }
        public String direccion { get; set; }
        public int nroPiso { get; set; }
        public char departamento { get; set; }
        public String localidad { get; set; }
        public int nroTelefono { get; set; }
        public String codPostal { get; set; }
        public DateTime fechaDeNacimiento { get; set; }
        public Boolean habilitado { get; set; }
    }
}
