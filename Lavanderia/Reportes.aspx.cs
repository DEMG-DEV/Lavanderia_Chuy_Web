using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lavanderia
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarReporte();
        }

        // En este metodo se trae toda la informacion de ventas y llena el DataGridView con ellos
        private void cargarReporte()
        {
            ConexionSQLServer conexion = new ConexionSQLServer();
            try
            {
                string Query = "SELECT * FROM dbo.ventas;";
                SqlDataAdapter adapter = conexion.conexionGetData(Query);
                DataTable datos = new DataTable();
                adapter.Fill(datos);

                GridView1.DataSource = datos;
                GridView1.DataBind();

                // Modificar nombres de columnas
                GridView1.Columns[0].HeaderText = "ID";
                GridView1.Columns[1].HeaderText = "Cantidad Carga Ligera";
                GridView1.Columns[2].HeaderText = "Total Carga Ligera";
                GridView1.Columns[3].HeaderText = "Cantidad Carga Pesada";
                GridView1.Columns[4].HeaderText = "Total Carga Pesada";
                GridView1.Columns[5].HeaderText = "Cantidad Planchado";
                GridView1.Columns[6].HeaderText = "Total Planchado";
                GridView1.Columns[7].HeaderText = "Total de venta";

                conexion.conexionClose();
            }
            catch (Exception ex) { }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx");
        }
    }
}