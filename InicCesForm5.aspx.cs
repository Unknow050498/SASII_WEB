using SDLX.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVP_ASP
{
    public partial class InicCesForm5 : Vista
    {
        protected override void InicializaControles()
        {
            textBox1.Text = "";
        }

        protected override Response EjecutaProceso()
        {
            Response response = new Response();
            string nvaCont = nuevaContra();
            using (SqlConnection conex = new SqlConnection("Data source=" + Path.GetFullPath("INV.Sql") + "; Version=3"))
            {
                conex.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE contras SET con_admin=@nvaContra WHERE con_mast=@conMaestra",conex))
                {
                    byte[] tmpSource;
                    byte[] tmpHash;
                    tmpSource = ASCIIEncoding.ASCII.GetBytes("S3DL4X4R?¿DSNPr0?");
                    tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                    cmd.Parameters.Add("@conMaestra", DbType.AnsiString).Value = BitConverter.ToString(tmpHash).Replace("-", "");
                    tmpSource = ASCIIEncoding.ASCII.GetBytes(nvaCont);
                    tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                    cmd.Parameters.Add("nvaContra", DbType.AnsiString).Value = BitConverter.ToString(tmpHash).Replace("-", "");
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT correo FROM direccion",conex))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mail = reader.GetString(reader.GetOrdinal("correo"));
                        }
                    }    
                }
            }
            SqlConnection.ClearAllPools();
            var fromAddress = new MailAddress("contacto@sedlaxartech.com", "Soporte Sedlaxar");
            var toAddress = new MailAddress(mail, "A cliente");
            const string fromPassword = "Tecnoinge31920$sed";
            const string subject = "Cambio contraseña";
            string body = nvaCont;
            var smtpclient = new SmtpClient
            {
                Host = "sedlaxartech.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = "Don't panic! \n Tu nueva contraseña es: " + body
            })
            {
                smtpclient.Send(message);
            }
        }
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