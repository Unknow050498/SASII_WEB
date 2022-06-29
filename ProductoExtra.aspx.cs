using SDLX.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVP_ASP
{
    public partial class ProductoExtra : Vista
    {
        protected override void InicializaControles()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        protected override Response EjecutaProceso()
        {
            Response response = new Response(); 
        }
    }
}