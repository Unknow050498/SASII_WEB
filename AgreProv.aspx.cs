using SDLX.DTO;
using SDLX.Utilerias;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace MVP_ASP
{
    public partial class AgreProv : Vista
    {
        private readonly String cveAlta;
        private readonly bool operacion;

        protected override void InicializaControles()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            string connection = "Server=localhost;UserID=root;Database=Sedlaxar;Password=root;";

            if (operacion)
            {
                using (MySqlConnection conexion = new MySqlConnection(connection))
                {
                    conexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT provedor,correo,telefono FROM provedores WHERE clave=@Cve", conexion))
                    {
                        cmd.Parameters.AddWithValue("@Cve", DbType.AnsiString).Value = this.cveAlta;
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                textBox1.Text = reader.GetString(reader.GetOrdinal("provedor"));
                                textBox2.Text = reader.GetString(reader.GetOrdinal("correo"));
                                textBox3.Text = reader.GetString(reader.GetOrdinal("telefono"));
                            }
                        }
                    }
                }
                MySqlConnection.ClearAllPools();
            }

        }
        protected override Response EjecutaProceso()
        {
            return null;
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            string connection = "Server=localhost;UserID=root;Database=Sedlaxar;Password=root;";
            if (this.operacion)
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    var regex = new Regex(@"[0-9]{10}");
                    var flg = regex.IsMatch(textBox3.Text);
                    if (!flg)
                    {
                        Utilerias.RegisterStartupScriptAlert(Page, "Ingresar sólo números en la campo de teléfono (eg. 5543664520).");
                    }
                    else
                    {
                        _ = Int32.Parse(textBox3.Text.Substring(0, textBox3.Text.Length - 3));
                        using (MySqlConnection conexion = new MySqlConnection(connection))
                        {
                            conexion.Open();
                            using (MySqlCommand cmd = new MySqlCommand("UPDATE provedores SET provedor=@Provedor, correo=@Correo, telefono=@Telefono WHERE clave=@CVE", conexion))
                            {
                                cmd.Parameters.AddWithValue("@Provedor", DbType.AnsiString).Value = textBox1.Text;
                                cmd.Parameters.AddWithValue("@Correo", DbType.AnsiString).Value = textBox2.Text;
                                cmd.Parameters.AddWithValue("@Telefono", DbType.AnsiString).Value = textBox3.Text;
                                cmd.Parameters.AddWithValue("@CVE", DbType.AnsiString).Value = this.cveAlta;
                                cmd.BeginExecuteNonQuery();

                            }
                        }
                        MySqlConnection.ClearAllPools();
                    }
                }
                else
                {
                    Utilerias.RegisterStartupScriptAlert(Page, "Hay campos que no han sido llenados.");
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    var regex = new Regex(@"[0-9]{10}");
                    var flg = regex.IsMatch(textBox3.Text);
                    if (!flg)
                    {
                        Utilerias.RegisterStartupScriptAlert(Page, "Ingresar sólo números en la campo de Teléfono (eg. 5561728394).");
                    }
                    else
                    {
                        _ = Int32.Parse(textBox3.Text.Substring(0, textBox3.Text.Length - 3));
                        using (MySqlConnection conexion = new MySqlConnection(connection))
                        {
                            conexion.Open();
                            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO provedores(clave,provedor,correo,telefono) VALUES (@CVE,@Provedor,@Correo,@Telefono)", conexion))
                            {
                                cmd.Parameters.AddWithValue("@CVE", DbType.AnsiString).Value = this.cveAlta;
                                cmd.Parameters.AddWithValue("@Provedor", DbType.AnsiString).Value = textBox1.Text;
                                cmd.Parameters.AddWithValue("@Correo", DbType.AnsiString).Value = textBox2.Text;
                                cmd.Parameters.AddWithValue("@Telefono", DbType.AnsiString).Value = textBox3.Text;
                                cmd.BeginExecuteNonQuery();

                            }
                        }
                        MySqlConnection.ClearAllPools();
                    }
                }
                else
                {
                    Utilerias.RegisterStartupScriptAlert(Page, "Hay campos que no han sido llenados.");
                }
            }
        }
    }
}