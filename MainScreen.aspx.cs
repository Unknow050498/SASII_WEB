using SDLX.DTO;
using SDLX.Utilerias;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Web.UI;
using MySql.Data.MySqlClient;


namespace MVP_ASP
{
    public partial class MainScreen : Vista
    {
        Boolean primeraVez;
        private Boolean validarCont = false, usuarioIng = false;
        String path;
        private String usuario;

        Response response = new Response();

        protected override void InicializaControles()
        {
            adm_button.Enabled = false;
            usr_button.Enabled = false;

            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Folios";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string connection = "Server=localhost;UserID=root;Database=Sedlaxar;Password=root;";

            using (MySqlConnection connectINV = new MySqlConnection(connection))
                {
                    connectINV.Open();
                    using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE contras (con_admin TEXT, con_mast TEXT)", connectINV))
                    {
                        cmd.BeginExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE direccion (dirLocal TEXT, correo TEXT)", connectINV))
                    {
                        cmd.BeginExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE audit (fecha TEXT, hora TEXT, operacion TEXT, cambioRealizado TEXT)", connectINV))
                    {
                        cmd.BeginExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE provedores (clave TEXT, provedor TEXT, correo TEXT, telefono TEXT)", connectINV))
                    {
                        cmd.BeginExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE folios (ID INTEGER, noFolio TEXT)", connectINV))
                    {
                        cmd.BeginExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE inventario (clave TEXT, producto TEXT, presentacion TEXT, precio REAL, costo REAL, montounit REAL, cantidad INTEGER, limite_inferior INTEGER, iva REAL)", connectINV))
                    {
                        cmd.BeginExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE ventas (vendedor TEXT, folioAsociado TEXT)", connectINV))
                    {
                        cmd.BeginExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE vendedores (claveVendedor TEXT, nombre TEXT, ventas INTEGER, puesto TEXT, salario TEXT)", connectINV))
                    {
                        cmd.BeginExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE proveedores (clave TEXT, proveedor TEXT, tel INTEGER, correo TEXT)", connectINV))
                    {
                        cmd.BeginExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO contras (con_admin, con_mast) VALUES (@conAdmin, @conMaestra)", connectINV))
                    {
                        cmd.Parameters.AddWithValue("@conAdmin", (MySqlDbType)DbType.AnsiString).Value = "0";
                        byte[] tmpSource;
                        byte[] tmpHash;
                        tmpSource = ASCIIEncoding.ASCII.GetBytes("S3DL4X4R?¿DSNPr0?");
                        tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                        cmd.Parameters.AddWithValue("@conMaestra", (MySqlDbType)DbType.AnsiString).Value = BitConverter.ToString(tmpHash).Replace("-", "");
                        cmd.BeginExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO folios (ID, noFolio) VALUES (@id, @folio)", connectINV))
                    {
                        cmd.Parameters.AddWithValue("@id", (MySqlDbType)DbType.Int32).Value = 1;
                        cmd.Parameters.AddWithValue("@folio", (MySqlDbType)DbType.AnsiString).Value = "A000000";
                        cmd.BeginExecuteNonQuery();
                    }
                }
                MySqlConnection.ClearAllPools();
     
            adm_button.Enabled = true;
            usr_button.Enabled = true;

        }

        protected void usr_button_Click(object sender, ImageClickEventArgs e)
        {
            //RFD - Redirect FormUsuario
            Utilerias.RegisterStartupScriptAlert(Page, "Redirect to Form XXXXXX");
            //Response.Redirect(WebConfigurationManager.AppSettings["pageAltaAdm"]);
            response.msg = "OK";

            adm_button.Enabled = false;
            usr_button.Enabled = false;
        }

        protected override Response EjecutaProceso()
        {
            return null;
        }

        protected void adm_button_Click(object sender, ImageClickEventArgs e)
        {
            using (MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sedlaxar"].ConnectionString))
            {
                conexion.Open();
                using (MySqlCommand cmd = new MySqlCommand("Select con_admin from contras", conexion))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(reader.GetOrdinal("con_admin")) != "0")
                            {
                                primeraVez = false;
                            }
                            else
                            {
                                primeraVez = true;
                            }
                        }
                    }
                }
            }

            MySqlConnection.ClearAllPools();

            if (primeraVez)
            {
                //RFD-redirect --> alta_adm guardarContra = new alta_adm();
                //guardarContra.Show();
                Utilerias.RegisterStartupScriptAlert(Page, "Mandar flujo alta_adm");
                Response.Redirect(WebConfigurationManager.AppSettings["pageAltaAdm"]);

            }
            else
            {
                //RFD-redirect --> Form 5
                Utilerias.RegisterStartupScriptAlert(Page, "Show form 5");
                adm_button.Enabled = false;
                usr_button.Enabled = false;
            }
        }
    }
}