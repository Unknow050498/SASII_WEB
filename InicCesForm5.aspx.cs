using SDLX.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace MVP_ASP
{
    public partial class InicCesForm5 : Vista
    {
        Response response = new Response();

        protected override void InicializaControles()
        {
            textBox1.Text = "";
        }
        protected override Response EjecutaProceso()
        {
            return null;
        }
    }
}