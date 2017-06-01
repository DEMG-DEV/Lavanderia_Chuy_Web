using MySql.Data.MySqlClient;
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
    public partial class About : Page
    {
        // Precios: $65 Carga Ligera, $9 por prenda
        // Precios: $95 Carga Pesada Pz
        // Precios: $8 Pz Planchada, $75 por 12
        private int[] precio = { 65, 95, 8 };

        // Contador de carga ligera, por Pieza, Lavado y Secado
        double contLigera = 0;
        // Contador de carga pesada, por Pieza, Lavado y Secado
        double contPesada = 0;
        // Contador de planchado, por Pieza
        int planchado = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPrendas();
            }
            else if (IsPostBack)
            {
                // Recuperar valores de venta, motivo: porque se recarga la pagina y se pierde la informacion
                recuperarValores();
            }
        }

        // Carga de los combobox, se llenan con las prendas.
        private void cargarPrendas()
        {
            ConexionSQLServer conexion = new ConexionSQLServer();
            try
            {
                string Query = "SELECT * FROM dbo.prendas;";
                SqlDataAdapter adapter = conexion.conexionGetData(Query);
                DataTable datos = new DataTable();
                adapter.Fill(datos);
                conexion.conexionClose();

                cmbPrendas1.Items.Clear();
                cmbPrendas2.Items.Clear();
                cmbPrendas3.Items.Clear();

                foreach (DataRow row in datos.Rows)
                {
                    cmbPrendas1.Items.Add(row["nombrePrenda"].ToString());
                    cmbPrendas2.Items.Add(row["nombrePrenda"].ToString());
                    cmbPrendas3.Items.Add(row["nombrePrenda"].ToString());
                }

                cmbPrendas1.SelectedIndex = 0;
                cmbPrendas2.SelectedIndex = 0;
                cmbPrendas3.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
            }
        }

        // Click del boton de SECADO
        protected void btnAñadir2_Click(object sender, EventArgs e)
        {
            // Prenda Seleccionada
            String val = cmbPrendas2.SelectedItem.ToString();
            // Cantidad de esa Prenda
            int cant = Convert.ToInt32(txtCantSecado.Text);

            if (val == "Blusas, Playeras, Camisas, Interior" || val == "Pantalones, Tenis" || val == "Ropa de Cama" || val == "Manteles")
            {
                // Asignamos en nuevo numero de piezas, se suma por si ya esxistia un previo numero
                contLigera += cant;
                // Obtenemos el numero de cargas
                double res = contLigera / 8;
                // Redondeamos el numero de cargas
                int cargasL = Convert.ToInt32(Math.Ceiling(res));
                // sacamos el numero de piezas individuales
                int cargasLI = Convert.ToInt32(contLigera - (cargasL * 8));
                // Obtenemos el total en $$$ de las cargas
                double total = (cargasL * precio[0]) + (cargasLI * (precio[0] / 8));
                // Asignamos los valores a los textbox
                txtCCL.Text = "" + contLigera;
                txtTCL.Text = "" + total;
            }
            else if (val == "Edredon, Cobertor")
            {
                // Asignamos en nuevo numero de piezas, se suma por si ya esxistia un previo numero
                contPesada += cant;
                // Se obtiene el total en $$$ de las cargas
                double total = contPesada * precio[1];
                // Asignamos los valores a los textbox
                txtCCP.Text = "" + contPesada;
                txtTCP.Text = "" + total;
            }
            // Se añade la venta al ListBox
            lstSecado.Items.Add(cant + " - " + val);
            // Se calcula el Total de Venta
            calcularTotal();
            // Se guarda la informacion, motivo recarga de la pagina se pierde la informacion
            guardarValores();
        }

        // Click del Boton de Planchado
        protected void btnAñadir3_Click(object sender, EventArgs e)
        {
            // Variable usada para guardar el total de Venta en Planchado
            int total = 0; ;
            // Prenda seleccionada
            String val = cmbPrendas3.SelectedItem.ToString();
            // Cantidad de esa prenda a Planchar
            int cant = Convert.ToInt32(txtCantPlanchado.Text);

            if (val == "Blusas, Playeras, Camisas, Interior")
            {
                planchado += cant;
            }
            else if (val == "Pantalones, Tenis")
            {
                planchado += cant;
            }
            else if (val == "Ropa de Cama")
            {
                planchado += cant;
            }
            else if (val == "Manteles")
            {
                planchado += cant;
            }
            else if (val == "Edredon, Cobertor")
            {
                planchado += cant;
            }

            if (planchado > 0)
            {
                // Aqui se realizan los calculos para poder hacer el descuento por cada 12 prendas planchadas en $75
                // despues se saca el valor de las prendas individuales que no estan en una docena y se saca su total
                // Luego se suman ambos totales para hacer el total general de Planchado
                double div = planchado / 12;
                int tot12 = Convert.ToInt32(Math.Floor(div));
                int tot8 = planchado - (tot12 * 12);
                total = (tot12 * 75) + (tot8 * 8);
            }
            // Se asignan valores a los textbox
            txtCP.Text = "" + planchado;
            txtTP.Text = "" + total;
            // Se añaden a la lista las prendas a planchar
            lstPlanchado.Items.Add(cant + " - " + val);
            // Se calcula el total de venta
            calcularTotal();
            // Se guarda la informacion, motivo recarga de la pagina se pierde la informacion
            guardarValores();
        }

        protected void btnAñadir1_Click(object sender, EventArgs e)
        {
            // Prenda seleccionada
            String val = cmbPrendas1.SelectedItem.ToString();
            // Cantidad de esa prenda a Lavar
            int cant = Convert.ToInt32(txtCantLavado.Text);

            if (val == "Blusas, Playeras, Camisas, Interior" || val == "Pantalones, Tenis" || val == "Ropa de Cama" || val == "Manteles")
            {
                // Asignamos en nuevo numero de piezas, se suma por si ya esxistia un previo numero
                contLigera += cant;
                // Obtenemos el numero de cargas
                double res = contLigera / 8;
                // Redondeamos el numero de cargas
                int cargasL = Convert.ToInt32(Math.Ceiling(res));
                // sacamos el numero de piezas individuales
                int cargasLI = Convert.ToInt32(contLigera - (cargasL * 8));
                // Obtenemos el total en $$$ de las cargas
                double total = (cargasL * precio[0]) + (cargasLI * (precio[0] / 8));
                // Asignamos los valores a los textbox
                txtCCL.Text = "" + contLigera;
                txtTCL.Text = "" + total;
            }
            else if (val == "Edredon, Cobertor")
            {
                // Asignamos en nuevo numero de piezas, se suma por si ya esxistia un previo numero
                contPesada += cant;
                // Se obtiene el total en $$$ de las cargas
                double total = contPesada * precio[1];
                // Asignamos los valores a los textbox
                txtCCP.Text = "" + contPesada;
                txtTCP.Text = "" + total;
            }
            // Se añade la prenda a la lista
            lstLavado.Items.Add(cant + " - " + val);
            // Se calcula el total de venta
            calcularTotal();
            // Se guarda la informacion, motivo recarga de la pagina se pierde la informacion
            guardarValores();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            // Accion del boton Cancelar, solo recarga la pagina de nuevo sin guardar ningun tipo de informacion
            Response.Redirect("Ventas.aspx");
        }

        // Accion del boton de Aceptar, guarda la informacion en la BD y muestra el ticket
        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            // Checa si el Total de venta es mayor a "0"
            if (Convert.ToInt32(txtTaP.Text) > 0)
            {
                ConexionSQLServer conexion = new ConexionSQLServer();
                try
                {
                    string Query = "INSERT INTO dbo.ventas(cantidadCargaLigera, totalCargaLigera,cantidadCargaPesada, totalCargaPesada,cantidadPlanchado, totalPlanchado,totalVenta) VALUES(" + Convert.ToInt32(txtCCL.Text) + "," + Convert.ToDouble(txtTCL.Text) + "," + Convert.ToInt32(txtCCP.Text) + "," + Convert.ToDouble(txtTCP.Text) + "," + Convert.ToInt32(txtCP.Text) + "," + Convert.ToDouble(txtTP.Text) + "," + Convert.ToDouble(txtTaP.Text) + ");";
                    SqlDataReader adapter = conexion.conexionSendData(Query);
                    while (adapter.Read())
                    {
                    }
                    conexion.conexionClose();
                    // Guarda las cantidades y totales de: Carga Ligera, Carga Pesada y Planchado, para enviarlas al ticket.
                    Session["CCL"] = txtCCL.Text;
                    Session["TCL"] = txtTCL.Text;
                    Session["CCP"] = txtCCP.Text;
                    Session["TCP"] = txtTCP.Text;
                    Session["CP"] = txtCP.Text;
                    Session["TP"] = txtTP.Text;
                    Session["TaP"] = txtTaP.Text;
                    // Redireccion al ticket, hasta este momento el ticket es solo informativo ya que se realizo la venta
                    // y se guardo en la BD de forma correcta
                    Response.Redirect("Ticket.aspx");
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
            // Regresa al inicio si se le oprime salir
            Response.Redirect("Default.aspx");
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
            // Guarda los valores solo durante la pagina actual siga activa, si se recarga o se aprieta cancelar
            // se pierde esta informacion guardada
            ViewState["contLigera"] = contLigera;
            ViewState["contPesada"] = contPesada;
            ViewState["planchado"] = planchado;
        }

        private void recuperarValores()
        {
            // Metodo que recupera los valores guardados cada vez que se aprieta un boton de Añadir
            try
            {
                contLigera = (double)ViewState["contLigera"];
                contPesada = (double)ViewState["contPesada"];
                planchado = (int)ViewState["planchado"];
            }
            catch (Exception ex)
            {
                Console.WriteLine("No existen valores en variables viewstate");
            }
        }

        protected void btnReportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }
    }
}