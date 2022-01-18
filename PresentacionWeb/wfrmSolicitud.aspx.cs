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
    public partial class wfrmSolicitud : System.Web.UI.Page
    {
        LNCalificaciones lNCalificaciones = new LNCalificaciones(Config.getCadConexion);
        EProfesor profesor = new EProfesor();
        EMateria materia = new EMateria();
        ECicloLectivo eCiclo = new ECicloLectivo();
        ESolicitud solicitud = new ESolicitud();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                profesor = lNCalificaciones.obtenerProfesor($" idProfesor = {Session["_idProfesor"] }");
                solicitud.EProfesor = profesor;
                txtProfe.Text = profesor.Nombre + " " + profesor.Apellido1;
                materia = lNCalificaciones.listarMaterias($" idMateria = {profesor.EMateria.IdMateria}")[0];
                solicitud.EMateria = materia;   
                txtMateria.Text = materia.NombreMateria;
                eCiclo = lNCalificaciones.devolverCiclo($" idCicloLectivo = {Session["_idCicloLectivo"]} ") ;
                txtNotaActual.Text = Session["_notaVieja"].ToString();
                solicitud.NotaVieja =Convert.ToInt32(Session["_notaVieja"].ToString());
                EEstudiante estudiante = lNCalificaciones.listarEstudiantes($" and e.idEstudiante = {Session["_idEstudiante"].ToString()}")[0];
                txtEstudiante.Text = estudiante.ToString();
                solicitud.EEstudiante = estudiante;
                solicitud.ECicloLectivo = eCiclo;
                txtTrimestre.Text = eCiclo.Trimestre.ToString();
                txtAnio.Text = eCiclo.Anio.ToString();


            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int notaNueva =  Convert.ToInt32(txtNotaNueva.Text);
                if (notaNueva >= 0 && notaNueva <= 100 && notaNueva != solicitud.NotaVieja)
                {
                    solicitud.NotaNueva = notaNueva;
                    solicitud.Justificacion = txtJusti.Text;
                    int resultado = lNCalificaciones.insert(solicitud);
                    if (resultado > 0)
                    {
                        Session["_exito"] = $" Mensaje: Se ha guardado correctamente ";
                    }
                    else
                    {
                        Session["_wrn"] = " Atencion: Error al insertar la solicitud";
                    }
                }
                else
                {
                    Session["_wrn"] = " Atencion: La nota introducida es incorrecta";
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }
    }
}