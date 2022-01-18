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
    public partial class wfrmCalificaciones : System.Web.UI.Page
    {
        LNCalificaciones lNCalificaciones = new LNCalificaciones(Config.getCadConexion);
        EProfesor profesor;
        EMateria materia;
        List<EEstudiante> listaEstudiante;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["_idProfesor"] != null)
                {
                    profesor = lNCalificaciones.obtenerProfesor($" idProfesor = {Session["_idProfesor"] }");
                    txtProfe.Text = profesor.Nombre + " " + profesor.Apellido1;
                    materia = lNCalificaciones.listarMaterias($" idMateria = {profesor.EMateria.IdMateria}")[0];
                    txtMateria.Text = materia.NombreMateria;

                }
                else
                {
                    Session["_err"] = $" Error : Ha ocurrido un error inesperado, reinicie la aplicación.";
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }

        protected void txtAnio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtSecciones.Enabled = true;
                string anio = txtAnio.Text;
                List<EGrupo> listaGrupos = lNCalificaciones.listarGrupos($" h.idProfesor =  {profesor.Id} and h.idMateria = {materia.IdMateria} ");
                if (listaGrupos.Count > 0)
                {
                    txtSecciones.DataSource = listaGrupos;
                    txtSecciones.DataBind();
                    ListItem i;
                    i = new ListItem("", "0");
                    txtSecciones.Items.Add(i);
                    txtSecciones.SelectedIndex = listaGrupos.Count;
                }
                else
                {
                    Session["_wrn"] = " Atencion: El docente no tiene grupos para el año seleccionado ";
                }



            }
            catch (Exception ex)
            {

                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }

        protected void txtSecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnVer.Enabled = true;
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarDGV();
            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }

        private void actualizarDGV()
        {
            string cadena = txtSecciones.Text;
            string[] subs = cadena.Split('-');
            string fecha;
            fecha = txtAnio.Text;
            string condicion2 = $" and g.seccion = {subs[1]} and g.grado = {subs[0]} and g.anio = {fecha}";

            listaEstudiante = lNCalificaciones.listarEstudiantes(condicion2);
            if (listaEstudiante.Count > 0)
            {
                GridView1.DataSource = listaEstudiante;
                GridView1.DataBind();
                cargarCalificaciones();
            }
            else
            {
                Session["_wrn"] = " Atencion: No hay estudiantes registrados en ese grupo";
            }

        

        }

        private void cargarCalificaciones()
        {
            ECicloLectivo eCicloLectivo;
            ECalificacion calificacion = new ECalificacion();
            EEstudiante eEstudiante;
            ECalificacion eCalificacion;
            string cadena = txtSecciones.Text;
            string[] subs = cadena.Split('-');
            string fecha;
            fecha = txtAnio.Text;
            string condicion = "";
            try 
            { 
            
                condicion = $"  trimestre = 1 and anio = {fecha}";
                eCicloLectivo = lNCalificaciones.devolverCiclo(condicion);
                calificacion.ECicloLectivo = eCicloLectivo;
                string condicion2 = $" and g.seccion = {subs[1]} and g.grado = {subs[0]} and g.anio = {fecha}";

                listaEstudiante = lNCalificaciones.listarEstudiantes(condicion2);
                for (int i = 0; i < listaEstudiante.Count; i++)
                {
                    eEstudiante = listaEstudiante[i];
                    condicion = $" idMateria = {materia.IdMateria} and idEstudiante = {listaEstudiante[i].Id} and idCicloLectivo = {calificacion.ECicloLectivo.IdCicloLectivo} ";
                    eCalificacion = lNCalificaciones.devolverCalificacion(condicion);
                    if (eCalificacion.NotaFinal >= 0)
                    {
                        ((TextBox)GridView1.Rows[i].FindControl("txtPrimerTrimestre")).Text = eCalificacion.NotaFinal.ToString();
                        if (calificacion.ECicloLectivo.Estado == 0 )
                        {
                            ((TextBox)GridView1.Rows[i].FindControl("txtPrimerTrimestre")).Enabled = false;

                        }
                    }
                    condicion = $"  trimestre = 2 and anio = {fecha}";
                    eCicloLectivo = lNCalificaciones.devolverCiclo(condicion);
                    calificacion.ECicloLectivo = eCicloLectivo;
                    condicion = $" idMateria = {materia.IdMateria} and idEstudiante = {listaEstudiante[i].Id} and idCicloLectivo = {eCicloLectivo.IdCicloLectivo} ";
                    eCalificacion = lNCalificaciones.devolverCalificacion(condicion);
                    if (eCalificacion.NotaFinal >= 0)
                    {
                        ((TextBox)GridView1.Rows[i].FindControl("txtSegundoTrimestre")).Text = eCalificacion.NotaFinal.ToString();
                        if (calificacion.ECicloLectivo.Estado == 0)
                        {
                            ((TextBox)GridView1.Rows[i].FindControl("txtSegundoTrimestre")).Enabled = false;

                        }
                    }
                    condicion = $"  trimestre = 3 and anio = {fecha}";
                    eCicloLectivo = lNCalificaciones.devolverCiclo(condicion);
                    calificacion.ECicloLectivo = eCicloLectivo;
                    condicion = $" idMateria = {materia.IdMateria} and idEstudiante = {listaEstudiante[i].Id} and idCicloLectivo = {eCicloLectivo.IdCicloLectivo} ";
                    eCalificacion = lNCalificaciones.devolverCalificacion(condicion);
                    if (eCalificacion.NotaFinal >= 0)
                    {
                        ((TextBox)GridView1.Rows[i].FindControl("txtTercerTrimestre")).Text = eCalificacion.NotaFinal.ToString();
                        if (calificacion.ECicloLectivo.Estado == 0)
                        {
                            ((TextBox)GridView1.Rows[i].FindControl("txtTercerTrimestre")).Enabled = false;

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void bntGuardar_Click(object sender, EventArgs e)
        {
            ECicloLectivo eCicloLectivo;
            ECalificacion calificacion = new ECalificacion();
            string fecha;
            fecha = txtAnio.Text;
            int num = 0;
            string cadena = txtSecciones.Text;
            string[] subs = cadena.Split('-');
            string condicion = "";
            try
            {
                calificacion.EMateria = materia;
                calificacion.EProfesor = profesor;
                string condicion2 = $" and g.seccion = {subs[1]} and g.grado = {subs[0]} and g.anio = {fecha}";

                listaEstudiante = lNCalificaciones.listarEstudiantes(condicion2);
                for (int i = 0; i < listaEstudiante.Count; i++)
                {
                    calificacion.EEstudiante = listaEstudiante[i];
                    if (((TextBox)GridView1.Rows[i].FindControl("txtPrimerTrimestre")).Text != "")
                    {
                        string cali1 = ((TextBox)GridView1.Rows[i].FindControl("txtPrimerTrimestre")).Text;
                        calificacion.NotaFinal = Convert.ToInt32(cali1);
                        if (lNCalificaciones.devolverCalificacion( $" idEstudiante = {calificacion.EEstudiante.Id} and idMateria = {calificacion.EMateria.IdMateria} and idCicloLectivo = {1} " ).NotaFinal != calificacion.NotaFinal)
                        {
                            condicion = $"  trimestre = 1 and anio = {fecha}";
                            eCicloLectivo = lNCalificaciones.devolverCiclo(condicion);
                            if (eCicloLectivo.Estado == 1)
                            {
                                calificacion.ECicloLectivo = eCicloLectivo;
                                num = registrarCalificacion(calificacion);
                            }
                            else
                            {
                                Session["_wrn"] = " Atencion: El ciclo lectivo 1 esta cerrado, debe solicitar al director";
                            }
                        }
                    }
                    if (((TextBox)GridView1.Rows[i].FindControl("txtSegundoTrimestre")).Text != "")
                    {
                        string cali1 = ((TextBox)GridView1.Rows[i].FindControl("txtSegundoTrimestre")).Text;
                        calificacion.NotaFinal = Convert.ToInt32(cali1);
                        if (lNCalificaciones.devolverCalificacion($" idEstudiante = {calificacion.EEstudiante.Id} and idMateria = {calificacion.EMateria.IdMateria} and idCicloLectivo = {1} ").NotaFinal != calificacion.NotaFinal)
                        {
                            condicion = $"  trimestre = 2 and anio = {fecha}";
                            eCicloLectivo = lNCalificaciones.devolverCiclo(condicion);
                            if (eCicloLectivo.Estado == 1)
                            {
                                calificacion.ECicloLectivo = eCicloLectivo;
                                num = registrarCalificacion(calificacion);
                            }
                            else
                            {
                                Session["_wrn"] = " Atencion: El ciclo lectivo 2 esta cerrado, debe solicitar al director";
                            }
                        }

                    }
                    if (((TextBox)GridView1.Rows[i].FindControl("txtTercerTrimestre")).Text != "")
                    {
                        string cali1 = ((TextBox)GridView1.Rows[i].FindControl("txtTercerTrimestre")).Text;
                        calificacion.NotaFinal = Convert.ToInt32(cali1);
                        if (lNCalificaciones.devolverCalificacion($" idEstudiante = {calificacion.EEstudiante.Id} and idMateria = {calificacion.EMateria.IdMateria} and idCicloLectivo = {1} ").NotaFinal != calificacion.NotaFinal)
                        {
                            condicion = $"  trimestre = 3 and anio = {fecha}";
                            eCicloLectivo = lNCalificaciones.devolverCiclo(condicion);
                            if (eCicloLectivo.Estado == 1)
                            {
                                calificacion.ECicloLectivo = eCicloLectivo;
                                num = registrarCalificacion(calificacion);
                            }
                            else
                            {
                                Session["_wrn"] = " Atencion: El ciclo lectivo 3 esta cerrado, debe solicitar al director";
                            }
                        }

                    }
                }
                if (num > 0)
                {
                    Session["_exito"] = $" Mensaje: Se ha guardado correctamente ";
                }
                //GridView1.Columns[].Clear();
                actualizarDGV();
                cargarCalificaciones();

            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }

        private int registrarCalificacion(ECalificacion calificacion)
        {
            int retorno = 0;
            string condicion = $" idMateria = {calificacion.EMateria.IdMateria} and idEstudiante = {calificacion.EEstudiante.Id} and idCicloLectivo = {calificacion.ECicloLectivo.IdCicloLectivo} ";
            if (lNCalificaciones.devolverCalificacion(condicion).NotaFinal >= 0)
            {
                retorno = lNCalificaciones.modificar(calificacion);
            }
            else
            {
                retorno = lNCalificaciones.insertarCalificacion(calificacion);
            }
            return retorno;
        }
        // I
        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            borrarCalificacion(1,e);
        }


        // II
        protected void LinkButton3_Command(object sender, CommandEventArgs e)
        {
            borrarCalificacion(2,e);
        }

        // III
        protected void LinkButton4_Command(object sender, CommandEventArgs e)
        {
            borrarCalificacion(3, e);
        }

        private void borrarCalificacion(int trimestre, CommandEventArgs e)
        {
            string fecha;
            fecha = txtAnio.Text;
            ECicloLectivo eCicloLectivo = lNCalificaciones.devolverCiclo( $" trimestre = {trimestre} and anio = {fecha}");
            try
            {
                if (lNCalificaciones.devolverCalificacion($" idMateria = {materia.IdMateria} and idEstudiante = {e.CommandArgument.ToString()} and idCicloLectivo = {eCicloLectivo.IdCicloLectivo} ").NotaFinal != -1) 
                {
                    if (eCicloLectivo.Estado == 0)
                    {
                        Session["_wrn"] = " Atencion: El ciclo lectivo esta cerrado, no se puede eliminar";
                    }
                    else
                    {
                        int resultado = lNCalificaciones.eliminar($" idMateria = {materia.IdMateria} and idEstudiante = {e.CommandArgument.ToString()} and idCicloLectivo = {eCicloLectivo.IdCicloLectivo} ");
                        if (resultado > 0)
                        {
                            Session["_exito"] = $" Mensaje: Se ha guardado correctamente ";
                            actualizarDGV();
                        }
                        else
                        {
                            Session["_wrn"] = " Atencion: Error al eliminar";
                        }
                    }
                }
                else
                {
                    Session["_wrn"] = " Atencion: Error al eliminar, el estudiante no tiene nota";
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }




        private void gestionarSolicitud(int trimestre, CommandEventArgs e)
        {
            string fecha;
            fecha = txtAnio.Text;

            ECicloLectivo eCicloLectivo = lNCalificaciones.devolverCiclo($"  trimestre = {trimestre} and anio = {fecha}");
            ECalificacion calificacion = lNCalificaciones.devolverCalificacion($" idMateria = {materia.IdMateria} and idEstudiante = {e.CommandArgument.ToString()} and idCicloLectivo = {eCicloLectivo.IdCicloLectivo} ");
            if (eCicloLectivo.Estado == 1)
            {
                Session["_wrn"] = " Atencion: El ciclo esta abierto, no puede hacer solicitud";
            }
            else
            {
                Session["_idEstudiante"] = e.CommandArgument.ToString();
                Session["_idCicloLectivo"] = eCicloLectivo.IdCicloLectivo.ToString();
                Session["_notaVieja"] = calificacion.NotaFinal;
                Session.Remove("_exito");
                Session.Remove("_wrn");
                Session.Remove("_err");
                Response.Redirect("wfrmSolicitud.aspx", false);
            }


        }

        // I
        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            gestionarSolicitud(1, e);
        }

        // II
        protected void lnkSolicitarII_Command(object sender, CommandEventArgs e)
        {
            gestionarSolicitud(2, e);
        }
            
        // III
        protected void lnkSolicitarII_Command1(object sender, CommandEventArgs e)
        {
            gestionarSolicitud(3, e);
        }
    }
}