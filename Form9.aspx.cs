using SDLX.DTO;
using SDLX.Utilerias;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace MVP_ASP
{
    public partial class Form9 : Vista
    {
        protected override void InicializaControles()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        protected override Response EjecutaProceso()
        {
            Response response = new Response();
            string conAdminTxt = "", conAdminTxtBox;

            using (MySqlConnection conex = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sedlaxar"].ConnectionString))
            {
                conex.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT con_admin FROM contras", conex))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            conAdminTxt = reader.GetString(reader.GetOrdinal("con_admin"));
                        }
                    }
                }
            }
            SqlConnection.ClearAllPools();
            byte[] tmpSource1, tmpSource2;
            byte[] tmpHash;
            tmpSource1 = ASCIIEncoding.ASCII.GetBytes(textBox1.Text);
            tmpSource2 = ASCIIEncoding.ASCII.GetBytes(textBox2.Text);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource1);
            conAdminTxtBox = BitConverter.ToString(tmpHash).Replace("-", "");
            if (conAdminTxt == conAdminTxtBox)
            {
                //RFD Redirect Form 9
                Utilerias.RegisterStartupScriptAlert(Page, "Mandar flujo alta_adm");
                //Response.Redirect(WebConfigurationManager.AppSettings["pageAltaAdm"]);
                response.msg = "OK";
            }
            else
            {
                //MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                response.msgErr = "Contraseña incorrecta.";
            }
            return response;
        }
    }
}