using ActiIV_Conection.CapaModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiIV_Conection.CapaController
{
    class DepartamentoController
    {
          public DepartamentoController() { }

        public bool CrearDepartamento(DepartamentoModel Modelo)
        {
            try
            {
                using (SqlConnection Con = new Conexion().GetConexion("BDDConexion"))
                {
                    Con.Open();

                    string sql = "execute EventosDepartamento '" + Modelo.Departamento + "','" + Modelo.Abreviatura + "' ";

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

        public DataTable getdepartamento()
        {
            SqlConnection Con = new Conexion().GetConexion("BDDConexion");
            Con.Open();




            DataTable dataTable = new DataTable();
                    string query = "SELECT IdDepartamento , Departamento , Abreviatura ,  Activo from  Departamento";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.CommandTimeout = 99999;
                    new SqlDataAdapter(cmd).Fill(dataTable);

                    Con.Close();
                    return dataTable;

                    

                
                
           

        }


        public DataTable getdepar()
        {
            SqlConnection Con = new Conexion().GetConexion("BDDConexion");
            Con.Open();




            DataTable dataTable = new DataTable();
            string query = "SELECT IdDepartamento , Abreviatura  from  Departamento";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.CommandTimeout = 99999;
            new SqlDataAdapter(cmd).Fill(dataTable);

            Con.Close();
            return dataTable;







        }

        /* private int valor;
         
        public UsuariosController(int Valor) { valor = Valor; }

        public UsuariosController(string Valor) { }*/




    }
}
