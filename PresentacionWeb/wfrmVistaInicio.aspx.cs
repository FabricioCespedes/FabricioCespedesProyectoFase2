using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_usuario"] != null)
            {
                switch (Session["_usuario"].ToString())
                {
                    case "Director":
                        btnSolicitudes.Visible = true;
                        break;
                    case "Asistente":
                        btnHorarios.Visible = true;
                        break;
                    case "Docente":
                        btnCalifaciones.Visible = true;
                        btnAsistencia.Visible = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Session["_wrn"] = " Atencion: se ha presentado un error no esperado reinicia la pagina";
            }
        }

        protected void btnHorarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrmHorario.aspx", false);

        }

        protected void btnSolicitudes_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrmRevisarSolicitudes.aspx", false);
        }

        protected void btnCalifaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrmCalificaciones.aspx", false);
        }

        protected void btnAsistencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrmAsistencia.aspx", false);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Remove("_exito");
            Session.Remove("_wrn");
            Session.Remove("_err");
            Session.Remove("_usuario");
            Session.Remove("_idProfesor");
            Response.Redirect("wfrmInicio.aspx", false);
        }
    }
}