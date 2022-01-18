using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class wfrmInicio : System.Web.UI.Page
    {
        LNInicio lNInicio = new LNInicio(Config.getCadConexion); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoUsuario = txtTipoUsuario.SelectedValue;

                if (tipoUsuario != "0")
                {
                    string nombreUsuario = txtUsuario.Text;

                    string contrasena = txtPassword.Text;

                    string condicion;
                    if( tipoUsuario == "Docente")
                    {
                        condicion = $" nombreUsuario = '{nombreUsuario}' and contrasenia = '{contrasena}' ";
                        EProfesor profesor = lNInicio.obtenerProfesor(condicion);
                        if (profesor.Id != 0)
                        {
                            Session.Remove("_exito");
                            Session.Remove("_wrn");
                            Session.Remove("_err");
                            Session["_usuario"] = tipoUsuario;
                            Session["_idProfesor"] = profesor.Id.ToString();

                            Response.Redirect("wfrmVistaInicio.aspx", false);
                        }
                        else
                        {
                            Session["_wrn"] = " Atencion: Acceso denegado";
                            Session["_usuario"] = tipoUsuario;
                        }
                    }
                    else
                    {
                        int acceso = lNInicio.login(contrasena, nombreUsuario);
                        if (acceso !=  -1)
                        {
                            Session.Remove("_exito");
                            Session.Remove("_wrn");
                            Session.Remove("_err");
                            Session["_usuario"] = tipoUsuario;
                            Session["_idUsuario"] = acceso.ToString();
                            Response.Redirect("wfrmVistaInicio.aspx", false);
                        }
                        else
                        {
                            Session["_wrn"] = " Atencion: Acceso denegado";
                        }
                    }
                }
                else
                {
                    Session["_wrn"] = " Atencion: Debe de seleccionar un tipo de usuario";
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }
    }
}