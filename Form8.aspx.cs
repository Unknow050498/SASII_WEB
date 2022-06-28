using SDLX.DTO;
using SDLX.Utilerias;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVP_ASP
{
    public partial class Form8 : Vista
    {
        protected override void InicializaControles()
        {
            textBox1.Text = "";
        }

        protected override Response EjecutaProceso()
        {
            Response response = new Response();
            string conAdminTxt = "", conAdminTxtBox;
            using (SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Sedlaxar"].ConnectionString))

            {
                conex.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT con_admin FROM contras", conex))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
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