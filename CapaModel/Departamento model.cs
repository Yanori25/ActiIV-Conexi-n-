using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ActiIV_Conection .CapaModel
{
    class DepartamentoModel 
    {
        public int IdDepartamento { get; set; }

        public string Departamento { get; set; }

        public string Abreviatura { get; set; }

        public bool Activo { get; set; }

        public static DataTable GetDepartamentos { get; set; }

        public DepartamentoModel () { }
}
}
