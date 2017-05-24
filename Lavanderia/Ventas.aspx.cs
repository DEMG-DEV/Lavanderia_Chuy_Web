using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lavanderia
{
    public partial class About : Page
    {
        private int[] precio = { 65, 95, 8 };

        // Variables a Cargar en cada PostBack
        private String[] data;

        double contLigera = 0;
        double contPesada = 0;
        int planchado = 0;
        double pantalones = 0, playeras = 0, manteles = 0, sabanas = 0, edredon = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicializar los datos de la bd                
                data = new String[3];
                data[0] = Session["ipservidor"].ToString();
                data[1] = Session["usuario"].ToString();
                data[2] = Session["contraseña"].ToString();

                cargarPrendas();
            }
            else if (IsPostBack)
            {
                recuperarValores();
            }
        }
        private void cargarPrendas()
        {
            ConexionMySQL conexion = new ConexionMySQL(data);
            try
            {
                string Query = "SELECT * FROM lavanderia.prendas;";
                MySqlDataAdapter adapter = conexion.conexionGetData(Query);
                DataTable datos = new DataTable();
                adapter.Fill(datos);
                conexion.conexionClose();

                cmbPrendas1.Items.Clear();
                cmbPrendas2.Items.Clear();
                cmbPrendas3.Items.Clear();

                foreach (DataRow row in datos.Rows)
                {
                    cmbPrendas1.Items.Add(row["cantidadPrenda"].ToString() + " - " + row["nombrePrenda"].ToString());
                    cmbPrendas2.Items.Add(row["cantidadPrenda"].ToString() + " - " + row["nombrePrenda"].ToString());
                    cmbPrendas3.Items.Add(row["cantidadPrenda"].ToString() + " - " + row["nombrePrenda"].ToString());
                }

                cmbPrendas1.SelectedIndex = 0;
                cmbPrendas2.SelectedIndex = 0;
                cmbPrendas3.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
            }
        }



        protected void btnAñadir2_Click(object sender, EventArgs e)
        {
            String val = cmbPrendas2.SelectedItem.ToString();

            if (val == "8 - Blusas, Playeras, Camisas, Interior")
            {
                playeras += 1;
                double res = playeras / 8;
                contLigera = contLigera + Convert.ToInt32(Math.Ceiling(res));
                txtCCL.Text = "" + contLigera;
            }
            else if (val == "6 - Pantalones, Tenis")
            {
                pantalones += 1;
                double res = pantalones / 6;
                contLigera = contLigera + Convert.ToInt32(Math.Ceiling(res));
                txtCCL.Text = "" + contLigera;
            }
            else if (val == "4 - Ropa de Cama")
            {
                sabanas += 1;
                double res = sabanas / 4;
                contLigera = contLigera + Convert.ToInt32(Math.Ceiling(res));
                txtCCL.Text = "" + contLigera;
            }
            else if (val == "5 - Manteles")
            {
                manteles += 1;
                double res = manteles / 5;
                contLigera = contLigera + Convert.ToInt32(Math.Ceiling(res));
                txtCCL.Text = "" + contLigera;
            }
            else if (val == "1 - Edredon, Cobertor")
            {
                edredon += 1;
                contPesada = contPesada + edredon;
                txtCCP.Text = "" + contPesada;
            }
            calcularTotalLigera();
            calcularTotalPesada();
            lstSecado.Items.Add(val);
            calcularTotal();
            guardarValores();
        }

        protected void btnAñadir3_Click(object sender, EventArgs e)
        {
            int total = 0; ;
            String val = cmbPrendas3.SelectedItem.ToString();

            if (val == "8 - Blusas, Playeras, Camisas, Interior")
            {
                planchado += 8;
            }
            else if (val == "6 - Pantalones, Tenis")
            {
                planchado += 6;
            }
            else if (val == "4 - Ropa de Cama")
            {
                planchado += 4;
            }
            else if (val == "5 - Manteles")
            {
                planchado += 5;
            }
            else if (val == "1 - Edredon, Cobertor")
            {
                planchado += 1;
            }

            if (planchado > 0)
            {
                double div = planchado / 12;
                int tot12 = Convert.ToInt32(Math.Floor(div));
                int tot8 = planchado - (tot12 * 12);
                total = (tot12 * 75) + (tot8 * 8);
            }

            txtCP.Text = "" + planchado;
            txtTP.Text = "" + total;
            lstPlanchado.Items.Add(val);
            calcularTotal();
            guardarValores();
        }

        protected void btnAñadir1_Click(object sender, EventArgs e)
        {
            String val = cmbPrendas1.SelectedItem.ToString();

            if (val == "8 - Blusas, Playeras, Camisas, Interior")
            {
                playeras += 1;
                double res = playeras / 8;
                contLigera = contLigera + Convert.ToInt32(Math.Ceiling(res));
                txtCCL.Text = "" + contLigera;
            }
            else if (val == "6 - Pantalones, Tenis")
            {
                pantalones += 1;
                double res = pantalones / 6;
                contLigera = contLigera + Convert.ToInt32(Math.Ceiling(res));
                txtCCL.Text = "" + contLigera;
            }
            else if (val == "4 - Ropa de Cama")
            {
                sabanas += 1;
                double res = sabanas / 4;
                contLigera = contLigera + Convert.ToInt32(Math.Ceiling(res));
                txtCCL.Text = "" + contLigera;
            }
            else if (val == "5 - Manteles")
            {
                manteles += 1;
                double res = manteles / 5;
                contLigera = contLigera + Convert.ToInt32(Math.Ceiling(res));
                txtCCL.Text = "" + contLigera;
            }
            else if (val == "1 - Edredon, Cobertor")
            {
                edredon += 1;
                contPesada = contPesada + edredon;
                txtCCP.Text = "" + contPesada;
            }
            calcularTotalLigera();
            calcularTotalPesada();
            lstLavado.Items.Add(val);
            calcularTotal();
            guardarValores();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx");
        }

        private void calcularTotalLigera()
        {
            int carga = Convert.ToInt32(txtCCL.Text);
            txtTCL.Text = "" + carga * precio[0];
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTaP.Text) > 0)
            {
                string msg = "Tu pago sera de:\n"
                        + "Carga Ligera:" + txtCCL.Text + " Total Carga Ligera($):$" + txtTCL.Text + "\n"
                        + "Carga Pesada:" + txtCCP.Text + " Total Carga Pesada($):$" + txtTCP.Text + "\n"
                        + "Planchado:" + txtCP.Text + " Total Planchado($):" + txtTP.Text + "\n\n"
                        + "Total a Pagar:$" + txtTaP.Text;
                Response.Write("<script type=\"text/javascript\">window.alert('" + msg + "');</script>");

                ConexionMySQL conexion = new ConexionMySQL(data);
                try
                {
                    string Query = "INSERT INTO lavanderia.ventas(cantidadCargaLigera, totalCargaLigera,cantidadCargaPesada, totalCargaPesada,cantidadPlanchado, totalPlanchado,totalVenta) VALUES(" + Convert.ToInt32(txtCCL.Text) + "," + Convert.ToDouble(txtTCL.Text) + "," + Convert.ToInt32(txtCCP.Text) + "," + Convert.ToDouble(txtTCP.Text) + "," + Convert.ToInt32(txtCP.Text) + "," + Convert.ToDouble(txtTP.Text) + "," + Convert.ToDouble(txtTaP.Text) + ");";
                    MySqlDataReader adapter = conexion.conexionSendData(Query);
                    while (adapter.Read())
                    {
                    }
                    conexion.conexionClose();
                    Response.Redirect("Ventas.aspx");
                }
                catch (Exception ex)
                {

                }
            }
            else
            {

            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        private void calcularTotalPesada()
        {
            int carga = Convert.ToInt32(txtCCP.Text);
            txtTCP.Text = "" + carga * precio[1];
        }

        private void calcularTotal()
        {
            double cl = Convert.ToDouble(txtTCL.Text);
            double cp = Convert.ToDouble(txtTCP.Text);
            double pl = Convert.ToDouble(txtTP.Text);

            txtTaP.Text = "" + (cl + cp + pl);
        }

        private void guardarValores()
        {
            ViewState["contLigera"] = contLigera;
            ViewState["contPesada"] = contPesada;
            ViewState["planchado"] = planchado;
            //ViewState["pantalones"] = pantalones;
            //ViewState["playeras"] = playeras;
            //ViewState["manteles"] = manteles;
            //ViewState["Sabanas"] = sabanas;
            //ViewState["edredon"] = edredon;
        }

        private void recuperarValores()
        {
            try
            {
                data = new String[3];
                data[0] = Session["ipservidor"].ToString();
                data[1] = Session["usuario"].ToString();
                data[2] = Session["contraseña"].ToString();
                contLigera = (double)ViewState["contLigera"];
                contPesada = (double)ViewState["contPesada"];
                planchado = (int)ViewState["planchado"];
                //pantalones = (double)ViewState["pantalones"];
                //playeras = (double)ViewState["playeras"];
                //manteles = (double)ViewState["manteles"];
                //sabanas = (double)ViewState["Sabanas"];
                //edredon = (double)ViewState["edredon"];
            }
            catch (Exception ex)
            {
                Console.WriteLine("No existen valores en variables viewstate");
            }
        }

    }
}