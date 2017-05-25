using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lavanderia
{
    public partial class Ticket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Este if sirve solo para recargar la informacion 1 sola vez
            if (!IsPostBack)
            {
                // Toda esta es la informacion del ticket
                lblCL.Text = "Cantidad Carga Ligera:" + Session["CCL"].ToString();
                lblTL.Text = " Total Carga Ligera:$" + Session["TCL"].ToString();
                lblCP.Text = "Cantidad Carga Pesada:" + Session["CCP"].ToString();
                lblTP.Text = " Total Carga Pesada:$" + Session["TCP"].ToString();
                lblcaP.Text = "Cantidad Planchado:" + Session["CP"].ToString();
                lbltoP.Text = " Total Planchado:$" + Session["TP"].ToString();
                lblTaP.Text = "Total a Pagar:$" + Session["TaP"].ToString();
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            // Regresa la web a la pagina de ventas para realizar una nueva venta
            Response.Redirect("Ventas.aspx");
        }
    }
}