using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        LNCalificaciones lNCalificaciones = new LNCalificaciones(Config.getCadConexion);
        DataSet tabla;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                tabla = lNCalificaciones.listarSolicitudes(" s.estado = 'ACT' ");
                if (tabla.Tables[0].Rows.Count > 0 )
                {
                    GridView1.DataSource = tabla;
                    GridView1.DataBind();
                }
                else
                {
                    Session["_wrn"] = " Atencion: No solicitudes";
                }

            }
            catch (Exception ex)
            {

                Session["_err"] = $" Error : '{ex.Message}' ";
            }

        }

        protected void lnkAceptar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                Session["_idSolicitud"] = e.CommandArgument.ToString();
                Response.Redirect("wfrmVistaSolicitud.aspx", false);
            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }



    }
}