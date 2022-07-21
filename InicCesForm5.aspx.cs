using SDLX.DTO;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using SDLX.Utilerias;

namespace MVP_ASP
{
    public partial class InicCesForm5 : Vista
    {
        Response response = new Response();
        String contraseña, contComparar, contraseñaMaestra, mail;
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWYZabcdefghijklmnopqrstuvwyz0123456789";

        protected override void InicializaControles()
        {
            textBox1.Text = "";
        }
        protected override Response EjecutaProceso()
        {
            return null;
        }

        protected void LinkForgPsswd_Click(object sender, EventArgs e)
        {
            string connection = "Server=localhost;UserID=root;Database=Sedlaxar;Password=root";
            string nvaCont = nuevaContra();
            using (MySqlConnection conex = new MySqlConnection(connection))
            {
                conex.Open();
                using (MySqlCommand cmd = new MySqlCommand("UPDATE contras SET con_admin=@nvaContra WHERE con_mast=@conMaestra", conex))
                {
                    byte[] tmpSource;
                    byte[] tmpHash;
                    tmpSource = ASCIIEncoding.ASCII.GetBytes("S3DL4X4R?¿DSNPr0?");
                    tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                    cmd.Parameters.AddWithValue("@conMaestra", DbType.AnsiString).Value = BitConverter.ToString(tmpHash).Replace("-", "");
                    tmpSource = ASCIIEncoding.ASCII.GetBytes(nvaCont);
                    tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                    cmd.Parameters.AddWithValue("nvaContra", DbType.AnsiString).Value = BitConverter.ToString(tmpHash).Replace("-", "");
                    cmd.BeginExecuteNonQuery();
                }
                using (MySqlCommand cmd = new MySqlCommand("SELECT correo FROM direccion", conex))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mail = reader.GetString(reader.GetOrdinal("correo"));
                        }
                    }
                }
            }
            MySqlConnection.ClearAllPools();
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

        protected void LinkResPsswd_Click(object sender, EventArgs e)
        {
            Form8 cambiarCont = new Form8();
            Utilerias.RegisterStartupScriptAlert(cambiarCont, "Mandar a Fom8");
        }

        public string nuevaContra()
        {
            Random rnd = new Random();
            string nvaContra = "";
            for(short i = 0; i < 8; i++)
            {
                nvaContra += chars[rnd.Next(0, chars.Length)];
            }
            return nvaContra;
        }
    }
}