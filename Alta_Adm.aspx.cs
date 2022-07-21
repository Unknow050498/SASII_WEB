using SDLX.DTO;
using SDLX.Utilerias;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;


namespace MVP_ASP
{
    public partial class Alta_Adm : Vista
    {
        protected override void InicializaControles()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            
        }

        protected override Response EjecutaProceso()
        {
            return null;
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            string connection = "Server=localhost;Port=3306;UserID=root;Database=sedlaxar;Password=root;";

            if (textBox1.Text != textBox2.Text || (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                textBox1.Text = "Establece una contraseñ";
                textBox2.Text = "Confirma la contraseña";
                textBox3.Text = "Ingrese un correo electrónico";
                Utilerias.RegisterStartupScriptAlert(Page, "Las contraseñas no coinciden");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    Utilerias.RegisterStartupScriptAlert(Page, "No has ingresado una dirección para la generación de tickets.");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(textBox4.Text) || !ValidarMail(textBox4.Text))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Correo electrónico invalido." + "');", true);
                        textBox1.Text = "Correo Electrónico";
                        textBox2.Text = "Establece una contraseña";
                        textBox3.Text = "Confirma la contraseña";
                        textBox1.Text = "Ingresa la dirección que sera utilizada en los tickets";
                    }
                    else
                    {
                        using (MySqlConnection con = new MySqlConnection(connection))
                        {
                            con.Open();
                            byte[] tmpSource;
                            byte[] tmpHash;
                            tmpSource = ASCIIEncoding.ASCII.GetBytes(textBox1.Text);
                            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                            using (MySqlCommand cmd = new MySqlCommand("UPDATE contras SET con_admin=@nvaContra WHERE con_admin='0'", con))
                            {
                                cmd.Parameters.AddWithValue("@nvaContra", DbType.AnsiString).Value = BitConverter.ToString(tmpHash).Replace("-", "");
                                cmd.BeginExecuteNonQuery();
                            }
                            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO direccion (dirLocal, correo) VALUES (@direc, @mail)", con))
                            {
                                cmd.Parameters.AddWithValue("@direc", DbType.AnsiString).Value = textBox3.Text;
                                cmd.Parameters.AddWithValue("@mail", DbType.AnsiString).Value = textBox4.Text;
                                cmd.BeginExecuteNonQuery();
                            }
                            Utilerias.RegisterStartupScriptAlert(Page, "Contraseña y dirección guardadas con éxito.");

                            con.Close();
                        }
                    }
                }
            }
        }

        protected override void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        bool ValidarMail(string email)
        {
            EmailAddressAttribute correo = new EmailAddressAttribute();
            if (correo.IsValid(email))
            {
                return true;
            }
            return false;
        }
    }
}