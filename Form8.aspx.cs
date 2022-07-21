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
    public partial class Form8 : Vista
    {
        Response response = new Response();

        protected override void InicializaControles()
        {
            textBox1.Text = "";
        }

        protected override Response EjecutaProceso()
        {
            return null;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
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
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(textBox1.Text);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            conAdminTxtBox = BitConverter.ToString(tmpHash).Replace("-", "");
            if (conAdminTxt == conAdminTxtBox)
            {
                //RFD Redirect Form 9
                Form9 form9 = new Form9();
                Utilerias.RegisterStartupScriptAlert(form9, "Mandar flujo alta_adm");
                //Response.Redirect(WebConfigurationManager.AppSettings["pageAltaAdm"]);
                response.msg = "OK";
            }
            else
            {
                //MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                response.msgErr = "Contraseña incorrecta.";
            }

        }
    }
}