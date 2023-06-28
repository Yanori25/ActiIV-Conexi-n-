using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ActiIV_Conection.CapaModel;

namespace ActiIV_Conection.CapaController
{
    class EmpleadosController
    {
        public EmpleadosController() { }

        public bool CrearEmpleado( EmpleadoModel Modelo)
        {
            try
            {
                using (SqlConnection Con = new Conexion().GetConexion("BDDConexion"))
                {
                    Con.Open();

                    string sql = "execute EventoEmpleados '" + Modelo.Nombre + "' , '" + Modelo.Identidad +
                        "' ,  '"+ Modelo.Fecha + "' , "+Modelo.IdDepartamento + " , '"+ Modelo.Puesto+ "'";

                    //string sql = "insert into Usuarios(IdUsuario,NombreUsuario,)"

                    using (SqlCommand cmd = new SqlCommand(sql, Con))
                    {
                        cmd.CommandTimeout = 600;
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Se agrego exitosamente");

                    Con.Close();
                }

                return true;
            }
            catch (Exception errores)
            {
                MessageBox.Show(errores.Message, "Informacion del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
        }

        public DataTable getempleados()
        {
            SqlConnection Con = new Conexion().GetConexion("BDDConexion");
            Con.Open();




            DataTable dataTable = new DataTable();
            string query = "SELECT  Idempleado,	Nombre,	Identidad,	Fecha,	emp.Activo ,	Puesto, Departamento	from Empleados emp " +
                 " inner join Departamento  dep on emp.IdDepartamento = dep.IdDepartamento ";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.CommandTimeout = 99999;
            new SqlDataAdapter(cmd).Fill(dataTable);

            Con.Close();
            return dataTable;







        }

    }
}
