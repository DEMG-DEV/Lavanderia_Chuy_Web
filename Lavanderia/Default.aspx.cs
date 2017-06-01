using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace Lavanderia
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            // Checa si hay conexion con la base de datos
            bool dato = checarConexion();

            if (dato == true)
            {
                // Redirecciona a la pagina de Ventas despues de un login exitoso
                Response.Redirect("Ventas.aspx");
            }
            else if (dato == false)
            {
                // Vuelve a recargar lapagina si no fue un login exitoso
                Response.Redirect("Default.aspx");
            }
        }

        private bool checarConexion()
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            //SqlConnection con = null;
            //// Aqui se checa la conexion con sql server
            //try
            //{
            //    DataTable datosRow = new DataTable();
            //    SqlDataAdapter reader = null;
            //    string strCon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Lavanderia.mdf;Integrated Security=True;";
            //    con = new SqlConnection(strCon);
            //    con.Open();

            //    SqlCommand com = con.CreateCommand();
            //    com.CommandText = "SELECT COUNT(*) FROM dbo.usuarios WHERE nombreUsuario =\'" + user + "\';";
            //    reader = new SqlDataAdapter(com);
            //    reader.Fill(datosRow);
            //    if (datosRow.Rows.Count >= 0)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
            //finally
            //{
            //    con.Close();
            //}
            ConexionSQLServer conexion = new ConexionSQLServer();
            DataTable datosRow = new DataTable();
            try
            {
                string Query = "SELECT COUNT(*) FROM dbo.usuarios WHERE nombreUsuario =\'" + user + "\';";
                SqlDataAdapter adapter = conexion.conexionGetData(Query);
                adapter.Fill(datosRow);
                if (datosRow.Rows.Count >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conexion.conexionClose();
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Recarga la pagina
            Response.Redirect("Default.aspx");
        }
    }
}