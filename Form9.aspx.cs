using SDLX.DTO;
using SDLX.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }
    }
}