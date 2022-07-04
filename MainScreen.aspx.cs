using SDLX.DTO;
using SDLX.Utilerias;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

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

                if (!File.Exists(Path.GetFullPath("INV.Sql")))
                {
                    using (SqlConnection connectINV = new SqlConnection("Data source=" + Path.GetFullPath("INV.Sql") + ";Version=3;"))
                    {
                        connectINV.Open();
                        using (SqlCommand cmd = new SqlCommand("CREATE TABLE contras (con_admin TEXT, con_mast TEXT)", connectINV))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("CREATE TABLE direccion (dirLocal TEXT, correo TEXT)", connectINV))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("CREATE TABLE audit (fecha TEXT, hora TEXT, operacion TEXT, cambioRealizado TEXT)", connectINV))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("CREATE TABLE provedores (clave TEXT, provedor TEXT, correo TEXT, telefono TEXT)", connectINV))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("CREATE TABLE folios (ID INTEGER, noFolio TEXT)", connectINV))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("CREATE TABLE inventario (clave TEXT, producto TEXT, presentacion TEXT, precio REAL, costo REAL, montounit REAL, cantidad INTEGER, limite_inferior INTEGER, iva REAL)", connectINV))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("CREATE TABLE ventas (vendedor TEXT, folioAsociado TEXT)", connectINV))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("CREATE TABLE vendedores (claveVendedor TEXT, nombre TEXT, ventas INTEGER, puesto TEXT, salario TEXT)", connectINV))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd = new SqlCommand("CREATE TABLE proveedores (clave TEXT, proveedor TEXT, tel INTEGER, correo TEXT)", connectINV))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd = new SqlCommand("INSERT INTO contras (con_admin, con_mast) VALUES (@conAdmin, @conMaestra)", connectINV))
                        {
                            cmd.Parameters.Add("@conAdmin", DbType.AnsiString).Value = "0";
                            byte[] tmpSource;
                            byte[] tmpHash;
                            tmpSource = ASCIIEncoding.ASCII.GetBytes("S3DL4X4R?¿DSNPr0?");
                            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                            cmd.Parameters.Add("@conMaestra", DbType.AnsiString).Value = BitConverter.ToString(tmpHash).Replace("-", "");
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO folios (ID, noFolio) VALUES (@id, @folio)", connectINV))
                        {
                            cmd.Parameters.Add("@id", DbType.Int32).Value = 1;
                            cmd.Parameters.Add("@folio", DbType.AnsiString).Value = "A000000";
                            cmd.ExecuteNonQuery();
                        }
                    }
                    SqlConnection.ClearAllPools();
                }
                
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
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Sedlaxar"].ConnectionString))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("Select con_admin from contras", conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
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
            SqlConnection.ClearAllPools();
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