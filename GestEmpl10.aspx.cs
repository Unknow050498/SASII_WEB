using MySql.Data.MySqlClient;
using SDLX.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVP_ASP
{
    public partial class GestEmpl10 : Vista 
    {
        protected override void InicializaControles()
        {
        }
        protected override Response EjecutaProceso()
        {
            return null;
        }

        public string getWhileLoopData()
        {
            string connection = "Server=localhost;UserID=root;Password=root;Database=Sedlaxar;";
            string htmlStr = "";
            MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand cmd = con.CreateCommand();
            
            cmd.CommandText = "SELECT * FORM vendedores";
            con.Open();

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                {
                    string Clave = reader.GetString(20);
                    string Empleado = reader.GetString(50);
                    string Puesto = reader.GetString(50);
                    string Salario = reader.GetString(50);
                    htmlStr += "<tr><td>" + Clave + "</td><td>" + Empleado + "</td><td>" + Puesto + "</td><td>" + Salario + " </td></tr> ";
                }

            con.Close();
            return htmlStr;

        }
    }
}