using System;
using SDLX.Utilerias;
using SDLX.DTO;

public abstract partial class Vista : System.Web.UI.Page
{

    protected virtual void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InicializaControles();
        }
    }

    protected virtual void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            Response respuesta;
            if (ValidarPre())
            {
                respuesta = EjecutaProceso();

                if (respuesta.msgErr != null)
                {
                    Utilerias.RegisterStartupScriptAlert(Page, respuesta.msgErr);
                }
                else
                {
                    ProcesaRespuesta(respuesta);
                    if (respuesta.msg != null)
                    {
                        Utilerias.RegisterStartupScriptAlert(Page, respuesta.msg );
                    }
                }
            }

        } catch (Exception ex)
        {
            reportFail(ex);
        }
    }

    protected virtual void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }

    protected virtual void btnDescargar_Click(object sender, EventArgs e) { }

    protected virtual void InicializaControles() { }

    protected virtual bool ValidarPre()
    {
        return true;
    }

    protected abstract Response EjecutaProceso();
    protected virtual void ProcesaRespuesta(Response respuesta)
    {

    }

    public void reportFail(Exception ex)
    {
        Utilerias.RegisterStartupScriptAlert(Page, ex.Message + ". Reporte a su Administrador de Sistemas.");
    }

}
