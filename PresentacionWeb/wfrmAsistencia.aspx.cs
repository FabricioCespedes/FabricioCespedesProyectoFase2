using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class wfrmAsistencia : System.Web.UI.Page
    {
        LNAsistencia lNAsistencia = new LNAsistencia(Config.getCadConexion);
        List<EEstudiante> listaEstudiante;
        List<string> listaEstados;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtSecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMaterias.Enabled = true;
            try
            {
                ddlMaterias.Items.Clear();
                ddlLecciones.Items.Clear();
                string cadena = txtSecciones.Text;
                string[] subs = cadena.Split('-');
                string fecha;
                fecha = txtFecha.Text;
                string[] subs2 = fecha.Split('-');
                string dia = obtenerDia(fecha);

                cargarMaterias(subs, subs2, dia);
            }
            catch (Exception ex)
            {

                Session["_err"] = $" Error : '{ex.Message}' ";

            }
        }

        private string obtenerDia(string fecha)
        {
            DateTime dateValue =  Convert.ToDateTime(fecha);
            string dia = dateValue.ToString("dddd",
                        new CultureInfo("es-ES"));
            switch (dia)
            {
                case "lunes":
                    dia = "L";
                    break;
                case "martes":
                    dia = "K";
                    break;
                case "miércoles":
                    dia = "M";
                    break;
                case "jueves":
                    dia = "J";
                    break;
                case "viernes":
                    dia = "V";
                    break;
                default:
                    dia = "X";
                    break;
            }
            return dia;
        }

        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            txtSecciones.Enabled = true;
            ddlMaterias.Items.Clear();
            ddlLecciones.Items.Clear();
            txtSecciones.SelectedIndex = 0;
            ddlLecciones.Enabled = false;
            ddlMaterias.Enabled = false; 
        }

        private bool cargarMaterias(string[] subs, string[] subs2, string dia)
        {
            bool bandera = false;
            ddlMaterias.Items.Clear();
            ddlLecciones.Items.Clear();

            string condicion = $" g.seccion = {Convert.ToInt32(subs[1])} and g.grado = {Convert.ToInt32(subs[0])} and g.anio = {Convert.ToInt32(subs2[0])} and h.dia = '{dia}' ";
            if (lNAsistencia.listarMaterias(condicion).Count > 0)
            {
                ListItem i;
                i = new ListItem("-- Seleccione --", "0");
                ddlMaterias.Items.Add(i);
                ddlMaterias.DataSource = lNAsistencia.listarMaterias(condicion);                
                ddlMaterias.DataBind();    
                
            }
            else
            {
                Session["_wrn"] = " Atencion: No hay materias registradas";
            }
            return bandera;
        }

        protected void ddlMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cadena = txtSecciones.Text;
                string[] subs = cadena.Split('-');
                string fecha;
                fecha = txtFecha.Text;
                string[] subs2 = fecha.Split('-');
                string dia = obtenerDia(fecha);
                string materia = ddlMaterias.Text;
                ddlLecciones.Enabled = true;
                cargarLecciones(subs, subs2, dia, materia);

            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }

        private void cargarLecciones(string[] subs, string[] subs2, string dia, string materia)
        {
            ddlLecciones.Items.Clear();
            ListItem i;
            i = new ListItem("-- Seleccione --", "0");
            ddlLecciones.Items.Add(i);
            string condicion = $" g.seccion = {subs[1]} and g.grado = {subs[0]} and g.anio = {subs2[0]} and h.dia = '{dia}' and m.nombreMateria =  '{materia}'";
            ddlLecciones.DataSource = lNAsistencia.listarHorario(condicion);
            ddlLecciones.DataBind();
        }

        protected void ddlLecciones_SelectedIndexChanged(object sender, EventArgs e)
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
            fecha = txtFecha.Text;
            string[] subs2 = fecha.Split('-');
            string dia = obtenerDia(fecha);
            string cadena2 = ddlLecciones.Text;
            string[] subs3 = cadena2.Split('a');
            string condicion2 = $" grado= {subs[0]} and seccion = {subs[1]} AND anio = {subs2[0]} ";
            listaEstados = new List<string>() { "Presente", "Ausente", "Tardia", "Permiso salida", "Salida emergencia" };

            if (lNAsistencia.listarGrupos(condicion2).Count > 0)
            {
                int idGrupo = lNAsistencia.listarGrupos(condicion2)[0].IdGrupo;
                condicion2 = $" idGrupo = {idGrupo}";

                if (lNAsistencia.obtenerTablaHorarios(condicion2).Tables[0].Rows.Count > 0)
                {
                    condicion2 = $" and g.seccion = {subs[1]} and g.grado = {subs[0]} and g.anio = {subs2[0]}";

                    listaEstudiante = lNAsistencia.listarEstudiantes(condicion2);
                    if (listaEstudiante.Count > 0)
                    {
                        GridView1.DataSource = listaEstudiante;
                        GridView1.DataBind();

                        string  materia = ddlMaterias.Text;
                        int idMateria = lNAsistencia.listarMaterias($" nombreMateria = '{materia}'")[0].IdMateria;
                        condicion2 = $" dia = '{dia}' and horaInicio = '{subs3[0]}' and horaFin = '{subs3[1]}' and idMateria = {idMateria} and idGrupo = {idGrupo} ";
                        int idHorario = lNAsistencia.devolverHorario(condicion2).IdHorario;
                        if (idHorario != 0)
                        {
                            for (int i = 0; i < listaEstudiante.Count; i++)
                            {
                                int idEstu = listaEstudiante[i].Id;
                                condicion2 = $" idEstudiante = {idEstu} and idHorario = {idHorario} and fecha = '{Convert.ToDateTime(fecha).ToString("dd/MM/yyyy")}'";

                                if (lNAsistencia.devolverAsistencia(condicion2).Estado != null)
                                {
                                    EAsistencia eAsistencia = new EAsistencia();
                                    eAsistencia = lNAsistencia.devolverAsistencia(condicion2);
                                    bool bandera = false;
                                    int y = 0;
                                    while (bandera == false)
                                    {
                                        if (eAsistencia.Estado == listaEstados[y])
                                        {
                                            ((DropDownList)GridView1.Rows[i].FindControl("ddlEstado")).SelectedValue = listaEstados[y];
                                            //dgvEstudiantes.Rows[i].Cells[16].Value = ;
                                            bandera = true;
                                        }
                                        y++;
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        Session["_wrn"] = " Atencion: No hay estudiantes registrados en ese grupo";
                    }

                }
                else
                {
                    Session["_wrn"] = " Atencion: No existe horarios para ese grupo";
                }
            }
            else
            {
                Session["_wrn"] = " Atencion: El grupo seleccionado no existe";
            }
        }

        protected void bntGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = 0;
                string cadena = txtSecciones.Text;
                string[] subs = cadena.Split('-');
                string fecha;
                fecha = txtFecha.Text;
                string[] subs2 = fecha.Split('-');
                string dia = obtenerDia(fecha);
                string cadena2 = ddlLecciones.Text;
                string[] subs3 = cadena2.Split('a');
                string materia = ddlMaterias.Text;
                int idMateria = lNAsistencia.listarMaterias($" nombreMateria = '{materia}'")[0].IdMateria;
                string condicion2 = $" grado= {subs[0]} and seccion = {subs[1]} AND anio = {subs2[0]} ";
                int idGrupo = lNAsistencia.listarGrupos(condicion2)[0].IdGrupo;
                condicion2 = $" dia = '{dia}' and horaInicio = '{subs3[0]}' and horaFin = '{subs3[1]}' and idMateria = {idMateria} and idGrupo = {idGrupo} ";
                int idHorario = lNAsistencia.devolverHorario(condicion2).IdHorario;
                condicion2 = $" and g.seccion = {subs[1]} and g.grado = {subs[0]} and g.anio = {subs2[0]}";

                listaEstudiante = lNAsistencia.listarEstudiantes(condicion2);
                for (int i = 0; i < listaEstudiante.Count; i++)
                {
                    int idEstu = listaEstudiante[i].Id;
                    condicion2 = $" idEstudiante = {idEstu} and idHorario = {idHorario} and fecha = '{fecha}'";

                    string estado = ((DropDownList)GridView1.Rows[i].FindControl("ddlEstado")).SelectedValue;


                    if (estado != "0")
                    {
                        string estadoNuevo = ((DropDownList)GridView1.Rows[i].FindControl("ddlEstado")).SelectedValue;
                        EAsistencia asistencia = new EAsistencia();
                        EEstudiante eEstudiante = new EEstudiante();
                        eEstudiante.Id = idEstu;
                        asistencia.EEstudiante = eEstudiante;
                        EHorario eHorario = new EHorario();
                        asistencia.Estado = estadoNuevo;
                        eHorario.IdHorario = idHorario;
                        asistencia.EHorario = eHorario;
                        asistencia.Fecha = fecha;
                        resultado = guardarAsistencia(asistencia);
                    }


                }
                if (resultado > 0)
                {
                    Session["_exito"] = $" Mensaje: Se ha guardado correctamente ";
                    actualizarDGV();
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

        private int guardarAsistencia(EAsistencia asistencia)
        {
            int resultado = 0;
            string condicion2 = $" idEstudiante = {asistencia.EEstudiante.Id} and idHorario = {asistencia.EHorario.IdHorario} and fecha = '{Convert.ToDateTime(asistencia.Fecha).ToString("dd/MM/yyyy")}'";
            if (lNAsistencia.devolverAsistencia(condicion2).Estado != null)
            {
                resultado = lNAsistencia.modificar(asistencia);
            }
            else
            {
                resultado = lNAsistencia.insertarAsistencia(asistencia);
            }
            return resultado;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int resultado = 0;
                string cadena = txtSecciones.Text;
                string[] subs = cadena.Split('-');
                string fecha;
                fecha = txtFecha.Text;
                string[] subs2 = fecha.Split('-');
                string dia = obtenerDia(fecha);
                string cadena2 = ddlLecciones.Text;
                string[] subs3 = cadena2.Split('a');
                string materia = ddlMaterias.Text;
                int idMateria = lNAsistencia.listarMaterias($" nombreMateria = '{materia}'")[0].IdMateria;
                string condicion2 = $" grado= {subs[0]} and seccion = {subs[1]} AND anio = {subs2[0]} ";
                int idGrupo = lNAsistencia.listarGrupos(condicion2)[0].IdGrupo;
                condicion2 = $" dia = '{dia}' and horaInicio = '{subs3[0]}' and horaFin = '{subs3[1]}' and idMateria = {idMateria} and idGrupo = {idGrupo} ";
                int idHorario = lNAsistencia.devolverHorario(condicion2).IdHorario;

                condicion2 = $" idEstudiante = {e.CommandArgument.ToString()} and idHorario = {idHorario} and fecha = '{Convert.ToDateTime(fecha).ToString("dd/MM/yyyy")}'";

                EAsistencia asistencia = lNAsistencia.devolverAsistencia(condicion2);

                if (asistencia.Estado != null)
                {
                    resultado =  lNAsistencia.eliminar($" idEstudiante = {e.CommandArgument.ToString()} and idHorario = {idHorario} and fecha = '{Convert.ToDateTime(fecha).ToString("dd/MM/yyyy")}'");

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
                else
                {
                    Session["_wrn"] = " Atencion: No hay nada que eliminar";
                }



            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }
    }
}