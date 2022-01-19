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
    public partial class wfrmProfesores : System.Web.UI.Page
    {

        LNProfesores lNProfesores = new LNProfesores(Config.getCadConexion);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpiar();

            }
            cargarDataGrid();

        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {

        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = condicion = $" p.nombreProfe like '%{txtNombreProfe.Text}%' or p.apellido1Profe like '%{txtNombreProfe.Text}%'";
            cargarDataGrid(condicion);
        }

        private void limpiar(string condicion = "")
        {
            txtNombreProfe.Text = "";
            cargarDataGrid();
        }

        private void cargarDataGrid(string condicion = "")
        {
            DataSet dataTable;
            try
            {
                if (condicion != "")
                {
                    dataTable = lNProfesores.listarProfesores(condicion);
                    if (dataTable != null)
                    {
                        gvProfesores.DataSource = dataTable;
                        gvProfesores.DataBind();
                    }
                    else
                    {
                        Session["_wrn"] = "No se encontraron profesores";
                    }
                }
                else
                {
                    dataTable = lNProfesores.listarProfesores(condicion);
                    if (dataTable != null)
                    {
                        gvProfesores.DataSource = dataTable;
                        gvProfesores.DataBind();
                    }
                    else
                    {
                        Session["_wrn"] = "No se encontraron profesores";
                    }
                }

            }
            catch (Exception ex)
            {
                Session["_err"] = $"Error: {ex.Message}";
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }


        protected void gvProfesores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProfesores.PageIndex = e.NewPageIndex;
            cargarDataGrid();
        }
    }
}