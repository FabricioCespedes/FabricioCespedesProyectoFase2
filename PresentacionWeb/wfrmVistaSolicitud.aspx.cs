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
    public partial class wfrmVistaSolicitud : System.Web.UI.Page
    {
        LNCalificaciones lNCalificaciones = new LNCalificaciones(Config.getCadConexion);
        EProfesor profesor = new EProfesor();
        EMateria materia = new EMateria();
        ECicloLectivo eCiclo = new ECicloLectivo();
        ESolicitud solicitud = new ESolicitud();
        EEstudiante estudiante = new EEstudiante();
        ECalificacion calificacion = new ECalificacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                solicitud = lNCalificaciones.devolverSolicitud($" idSolicitud = {Session["_idSolicitud"]} ");
                profesor = lNCalificaciones.obtenerProfesor($" idProfesor = { solicitud.EProfesor.Id }");
                txtProfe.Text = profesor.Nombre + " " + profesor.Apellido1;
                materia = lNCalificaciones.listarMaterias($" idMateria = {solicitud.EMateria.IdMateria}")[0];
                solicitud.EMateria = materia;
                txtMateria.Text = materia.NombreMateria;
                eCiclo = lNCalificaciones.devolverCiclo($" idCicloLectivo = {solicitud.ECicloLectivo.IdCicloLectivo} ");
                txtNotaActual.Text = solicitud.NotaVieja.ToString();
                estudiante = lNCalificaciones.listarEstudiantes($" and e.idEstudiante = {solicitud.EEstudiante.Id}")[0];
                txtEstudiante.Text = estudiante.ToString();
                txtTrimestre.Text = eCiclo.Trimestre.ToString();
                txtAnio.Text = eCiclo.Anio.ToString();
                txtNotaNueva.Text = solicitud.NotaNueva.ToString();
                txtJusti.Text = solicitud.Justificacion.ToString();
                calificacion.EEstudiante = estudiante;
                calificacion.EMateria = materia;
                calificacion.ECicloLectivo = eCiclo;
                calificacion.NotaFinal = Convert.ToInt32(txtNotaNueva.Text);

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
                 string aprobacion = txtRevision.Text;
                if (aprobacion != "0")
                {
                    if (aprobacion == "Aprobar")
                    {
                        aprobarSolicitud(txtObservacion.Text, Session["_idUsuario"].ToString(), Session["_idSolicitud"].ToString(), calificacion);
                    }
                    else
                    {
                        noAprobarSolicitud(txtObservacion.Text, Session["_idUsuario"].ToString() , Session["_idSolicitud"].ToString());
                    }
                }
                else
                {
                    Session["_wrn"] = " Atencion: Error debe de seleccionar un revision";
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }

        private void noAprobarSolicitud(string observacion , string idUuario, string idSolicitud)
        {
            try
            {
                int resultado = 0;
                resultado = lNCalificaciones.modificar(observacion, idUuario, idSolicitud);
                if (resultado > 0)
                {
                    Session["_exito"] = $" Mensaje: Se ha guardado correctamente ";
                }
                else
                {
                    Session["_wrn"] = " Atencion: Error al actualizar";
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }

        private void aprobarSolicitud(string observacion, string idUuario, string idSolicitud, ECalificacion eCalificacion)
        {
            try
            {
                int resultado = 0;
                resultado = lNCalificaciones.modificar(observacion, idUuario, idSolicitud);
                resultado = lNCalificaciones.modificar(eCalificacion);

                if (resultado > 0)
                {
                    Session["_exito"] = $" Mensaje: Se ha guardado correctamente ";
                }
                else
                {
                    Session["_wrn"] = " Atencion: Error al actualizar";
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }
    }
}