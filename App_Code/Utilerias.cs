using SDLX.DTO;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for Utilerias
/// </summary>
/// 
namespace SDLX.Utilerias
{
    public class Utilerias
    {
        public static string EncryptMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] bytesMD5 = null;
            StringBuilder stringMD5 = new StringBuilder();
            bytesMD5 = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            md5.Clear();
            for (int i = 0; i < bytesMD5.Length; i++) stringMD5.AppendFormat("{0:x2}", bytesMD5[i]);
            return stringMD5.ToString();
        }
        public static Response DescargarArchivo(HttpResponse httpResponse, string strFile, string contentType)
        {

            Response response = new Response();
            FileInfo file = new FileInfo(strFile);
            if (file.Exists)
            {
                httpResponse.ClearContent();
                httpResponse.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                httpResponse.AddHeader("Content-Length", file.Length.ToString());
                httpResponse.ContentType = contentType;
                httpResponse.TransmitFile(file.FullName);
                httpResponse.End();
                response.msg = WebConfigurationManager.AppSettings["msgOK"];
            }
            else
            {
                response.msgErr = "Archivo no existe";
            }
            return response;

        }
        public static Response DescargarMemoryStream(HttpResponse httpResponse, string fileName, MemoryStream ms, string contentType)
        {

            Response response = new Response();


            httpResponse.ClearContent();
            httpResponse.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            //httpResponse.AddHeader("Content-Length", byteArray.Length.ToString());
            httpResponse.AddHeader("Content-Length", ms.Length.ToString());
            httpResponse.ContentType = contentType;
            httpResponse.BinaryWrite(ms.ToArray());
            //httpResponse.BinaryWrite(ms);
            httpResponse.End();
            response.msg = WebConfigurationManager.AppSettings["msgOK"];
            return response;

        }

        public static string QuitarAcentos(string input)
        {
            string stFormD = input.Normalize(NormalizationForm.FormD);
            int len = stFormD.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[i]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }



        public static string RawUrlAplicativa(HttpRequest request)
        {
            //Quita a la página el directorio virtual, si está sin directorio virtual (raíz) le deja la /
            return HttpUtility.UrlDecode(request.RawUrl).Replace(request.ApplicationPath, request.ApplicationPath == "/" ? "/" : "");
        }

        public static void saveEventViewer(string msg, System.Diagnostics.EventLogEntryType eventLogEntry = System.Diagnostics.EventLogEntryType.Warning, int number = 1)
        {
            if (!System.Diagnostics.EventLog.SourceExists(WebConfigurationManager.AppSettings["application"]))
                System.Diagnostics.EventLog.CreateEventSource(WebConfigurationManager.AppSettings["application"], "Application");
            System.Diagnostics.EventLog.WriteEntry(WebConfigurationManager.AppSettings["application"], msg, eventLogEntry, number);
        }
        public static void RegisterStartupScriptAlert(System.Web.UI.Page Page, string message)
        {
            //string msgDepurado = System.Text.RegularExpressions.Regex.Replace(message, @"[^\w\.@()-]", " ");
            string msgDepurado = System.Text.RegularExpressions.Regex.Replace(message, @"[^\w\.\:\-,@$()-]", " "); // \w - aceptar alfanuméricos y guión bajo \. acepta punto \: acepta :, etc
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "alert('" + msgDepurado + "');", true);
        }



        public static void ActivarCreditoTablas(bool activar, string numCredito, string[] tablasAfectadas, SqlTransaction sqlTransaction, SqlConnection sqlConnection)
        {
            string sqlExclude;
            foreach (string tabla in tablasAfectadas)
            {
                //Excluye desactivar comprobantes con proceso de pago bancario, solo deja desactivarlos si no han tenido pago
                if (activar == false && tabla.Trim().ToUpper() == "CREDITO_BLOQUE_COMPROBANTE")
                {
                    sqlExclude = " AND Cve_Pago IS NULL";
                }
                else
                {
                    sqlExclude = "";
                }
                using (SqlCommand cmd = new SqlCommand(
                "UPDATE " + tabla + Environment.NewLine +
                    "SET Activo = @activo " + Environment.NewLine +
                    "WHERE Num_Credito = @numCredito AND Activo <> @activo " + sqlExclude
                , sqlConnection))
                {
                    cmd.Transaction = sqlTransaction;
                    cmd.Parameters.AddWithValue("@numCredito", numCredito);
                    cmd.Parameters.AddWithValue("@activo", activar);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static object initParameterDatabase(object parameter)
        {
            return parameter == null || parameter.ToString().Trim() == "" ? DBNull.Value : (object)parameter;
        }
    }
}
