using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ActiIV_Conection.CapaModel
{
    public class EmpleadoModel

    {
        
        public int Idempleado { get; set;  }

        public string Nombre { get; set; }
        public string Identidad { get; set; }

        public DateTime Fecha  { get; set;} 

        public string Activo { get; set; }

        public int IdDepartamento { get; set; }

        public string Puesto { get; set; }

        public static DataTable GetUsuarios { get; set; }

      public EmpleadoModel() { }

    }
}
