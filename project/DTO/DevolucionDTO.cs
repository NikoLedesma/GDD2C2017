﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO
{
    public class DevolucionDTO
    {
        public int id {get; set;}
        public int idRendicion { get; set; }
        public string razon { get; set; }
        public int idFact { get; set; }
    }
}
