using SDLX.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using SDLX.Utilerias;

namespace MVP_ASP
{
    public partial class AltaEmpl11 : Vista
    {
        private String cveAlta;
        private bool operacion;

        protected override void InicializaControles()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            string connection = "Server=localhost;UserID=root;Database=Sedlaxar;Password=root;";

            using (MySqlConnection conexion = new MySqlConnection(connection))
            {
                conexion.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT nombre,puesto,salario FROM vendedores WHERE claveVendedor=@Cve", conexion))
                {
                    cmd.Parameters.AddWithValue("@Cve", DbType.AnsiString).Value = this.cveAlta;
                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox1.Text = reader.GetString(reader.GetOrdinal("nombre"));
                            textBox2.Text = reader.GetString(reader.GetOrdinal("puesto"));
                            textBox3.Text = reader.GetString(reader.GetOrdinal("salario")).Substring(2, reader.GetString(reader.GetOrdinal("salario")).Length - 2); 
                        }
                    }
                }
            }
            MySqlConnection.ClearAllPools();
            
        }

        protected override Response EjecutaProceso()
        {
            
            return null;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string connection = "Server=localhost;UserID=root;Database=sedlaxar;Password=root;";

            if (this.operacion)
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    var regex = new Regex(@"^\d+\.\d{2}?$");
                    var flg = regex.IsMatch(textBox3.Text);
                    if (!flg)
                    {
                        Utilerias.RegisterStartupScriptAlert(Page, "Ingresar sólo números en la campo de Salario (eg. 12000.50, 500.00).");
                    }
                    else
                    {
                        int sal = Int32.Parse(textBox3.Text.Substring(0, textBox3.Text.Length - 3));
                        using (MySqlConnection conexion = new MySqlConnection(connection))
                        {
                            conexion.Open();
                            using (MySqlCommand cmd = new MySqlCommand("UPDATE vendedores SET nombre=@Nombre, puesto=@Puesto, salario=@Salario WHERE claveVendedor=@CVE", conexion))
                            {
                                cmd.Parameters.AddWithValue("@CVE", DbType.AnsiString).Value = this.cveAlta;
                                cmd.Parameters.AddWithValue("@Nombre", DbType.AnsiString).Value = textBox1.Text;
                                cmd.Parameters.AddWithValue("@Puesto", DbType.AnsiString).Value = textBox2.Text;
                                cmd.Parameters.AddWithValue("@Salario", DbType.AnsiString).Value = "$ " + Convert.ToDecimal(sal).ToString("#,##0") + textBox3.Text.Substring(textBox3.Text.Length - 3, 3);
                                cmd.BeginExecuteNonQuery();
                                if (MessageBox.Show("Registro modificado con éxito.", "", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                {
                                    conexion.Close();
                                }
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
                    var regex = new Regex(@"^\d+\.\d{2}?$");
                    var flg = regex.IsMatch(textBox3.Text);
                    if (!flg)
                    {
                        Utilerias.RegisterStartupScriptAlert(Page, "Ingresar sólo números en la campo de Salario (eg. 12000.50, 500.00).");
                    }
                    else
                    {
                        int sal = Int32.Parse(textBox3.Text.Substring(0, textBox3.Text.Length - 3));
                        using (MySqlConnection conexion = new MySqlConnection(connection))
                        {
                            conexion.Open();
                            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO vendedores(claveVendedor,nombre,ventas,puesto,salario) VALUES (@CVE,@Nombre,@Ventas,@Puesto,@Salario)", conexion))
                            {
                                cmd.Parameters.AddWithValue("@CVE", DbType.AnsiString).Value = this.cveAlta;
                                cmd.Parameters.AddWithValue("@Nombre", DbType.AnsiString).Value = textBox1.Text;
                                cmd.Parameters.AddWithValue("@Puesto", DbType.AnsiString).Value = textBox2.Text;
                                cmd.Parameters.AddWithValue("@Salario", DbType.AnsiString).Value = "$ " + Convert.ToDecimal(sal).ToString("#,##0") + textBox3.Text.Substring(textBox3.Text.Length - 3, 3);
                                cmd.Parameters.AddWithValue("@Ventas", DbType.Int32).Value = 0;
                                cmd.BeginExecuteNonQuery();
                                if (MessageBox.Show("Registro guardado con éxito.", "", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                {
                                    conexion.Close();
                                }
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