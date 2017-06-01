using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Lavanderia
{
    public class ConexionSQLServer
    {
        SqlConnection con = null;
        string strCon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Lavanderia.mdf;Integrated Security=True;";

        public SqlDataReader conexionSendData(String sqlCadena)
        {
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection(strCon);
                con.Open();
                SqlCommand com = con.CreateCommand();
                com.CommandText = sqlCadena;
                reader = com.ExecuteReader();
            }
            catch (Exception ex)
            {

            }
            return reader;
        }

        public SqlDataAdapter conexionGetData(String sqlCadena)
        {
            SqlDataAdapter adapter = null;
            try
            {
                con = new SqlConnection(strCon);
                con.Open();
                SqlCommand com = con.CreateCommand();
                com.CommandText = sqlCadena;
                adapter = new SqlDataAdapter(com);
            }
            catch (Exception ex)
            {

            }
            return adapter;
        }

        public void conexionClose()
        {
            con.Close();
        }
    }
}