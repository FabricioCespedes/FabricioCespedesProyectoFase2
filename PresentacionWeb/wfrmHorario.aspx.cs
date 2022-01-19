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
    public partial class wfrmHorario : System.Web.UI.Page
    {
        LNHorarios lNHorarios = new LNHorarios(Config.getCadConexion);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Session.RemoveAll();
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            int anio;

            try
            {
                anio = Convert.ToInt32(txtAnio.Text);

                if (anio < 0)
                {
                    Session["_wrn"] = " Atencion: Debe ingresar un año valido";
                    txtAnio.Text = "";
                }
                else
                {
                    string condicion2 = $"  anio = {anio} ";
                    if (lNHorarios.listarGrupos(condicion2).Count > 0)
                    {
                        if (lNHorarios.listarMaterias().Count > 0)
                        {
                            if (lNHorarios.listarAulas($" and  tipoAula = 'normal' ").Count >= 8)
                            {
                                if (lNHorarios.listarAulas($" and  tipoAula = 'Computo' ").Count >= 2)
                                {

                                    if (lNHorarios.listarAulas($" and  tipoAula = 'Contabilidad' ").Count >= 2)
                                    {
                                        if (revisarProfesor() == "")
                                        {
                                            int idGrupo = lNHorarios.listarGrupos($" anio = {anio}")[0].IdGrupo;
                                            condicion2 = $" idGrupo = {idGrupo}";
                                            if (lNHorarios.obtenerTablaHorarios(condicion2).Tables[0].Rows.Count == 0)
                                            {
                                                string mensaje = "";
                                               
                                                mensaje = lNHorarios.procesoCrearHorarios(anio);
                                                if (mensaje != "")
                                                {
                                                    Session["_exito"] = $" Mensaje: {mensaje} ";
                                                }
                                            }
                                            else
                                            {
                                                Session["_wrn"] = " Atencion:Los horarios ya estan creados para ese año";
                                            }
                                        }
                                        else
                                        {
                                            Session["_wrn"] = $" Atencion: {revisarProfesor()}";
                                        }

                                    }
                                    else
                                    {
                                        Session["_wrn"] = " Atencion: No hay aulas sufiencientes de contabilidad";
                                    }
                                }
                                else
                                {
                                    Session["_wrn"] = " Atencion: No hay aulas sufiencientes de computo";
                                }
                            }
                            else
                            {
                                Session["_wrn"] = " Atencion: No hay aulas sufiencientes normales";
                            }

                        }
                        else
                        {
                            Session["_wrn"] = " Atencion: No hay materias registradas";
                        }
                    }
                    else
                    {
                        Session["_wrn"] = " Atencion: No hay grupos creados en para ese año";
                    }
                }

            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }

        }

        private string revisarProfesor()
        {
            string retorno = "";
            string condicion2 = "";
            int idMateria = 0;
            List<EMateria> listaMaterias = lNHorarios.listarMaterias();
            int i = 0;
            while (retorno == "" && i < listaMaterias.Count)
            {
                switch (listaMaterias[i].NombreMateria)
                {
                    case "Matematicas":
                        condicion2 = $"  nombreMateria = '{listaMaterias[i].NombreMateria}' ";
                        idMateria = lNHorarios.listarMaterias(condicion2)[0].IdMateria;
                        condicion2 = $"  idMateria = {idMateria} ";
                        if (lNHorarios.listarProfesores(condicion2).Count < 2)
                        {
                            retorno = "No hay profesores de matematicas";
                        }
                        break;
                    case "español":
                        condicion2 = $"  nombreMateria = '{listaMaterias[i].NombreMateria}' ";
                        idMateria = lNHorarios.listarMaterias(condicion2)[0].IdMateria;
                        condicion2 = $"  idMateria = {idMateria} ";
                        if (lNHorarios.listarProfesores(condicion2).Count < 2)
                        {
                            retorno = "No hay profesores de español";
                        }
                        break;
                    case "ciencias":
                        condicion2 = $"  nombreMateria = '{listaMaterias[i].NombreMateria}' ";
                        idMateria = lNHorarios.listarMaterias(condicion2)[0].IdMateria;
                        condicion2 = $"  idMateria = {idMateria} ";
                        if (lNHorarios.listarProfesores(condicion2).Count < 2)
                        {
                            retorno = "No hay profesores de ciencias";
                        }
                        break;
                    case "Estudios Sociales":
                        condicion2 = $"  nombreMateria = '{listaMaterias[i].NombreMateria}' ";
                        idMateria = lNHorarios.listarMaterias(condicion2)[0].IdMateria;
                        condicion2 = $"  idMateria = {idMateria} ";
                        if (lNHorarios.listarProfesores(condicion2).Count < 2)
                        {
                            retorno = "No hay profesores de Estudios Sociales";
                        }
                        break;
                    case "ingles":
                        condicion2 = $"  nombreMateria = '{listaMaterias[i].NombreMateria}' ";
                        idMateria = lNHorarios.listarMaterias(condicion2)[0].IdMateria;
                        condicion2 = $"  idMateria = {idMateria} ";
                        if (lNHorarios.listarProfesores(condicion2).Count < 2)
                        {
                            retorno = "No hay profesores de ingles";
                        }
                        break;
                    case "frances":
                        condicion2 = $"  nombreMateria = '{listaMaterias[i].NombreMateria}' ";
                        idMateria = lNHorarios.listarMaterias(condicion2)[0].IdMateria;
                        condicion2 = $"  idMateria = {idMateria} ";
                        if (lNHorarios.listarProfesores(condicion2).Count < 1)
                        {
                            retorno = "No hay profesores de frances";
                        }
                        break;
                    case "musica":
                        condicion2 = $"  nombreMateria = '{listaMaterias[i].NombreMateria}' ";
                        idMateria = lNHorarios.listarMaterias(condicion2)[0].IdMateria;
                        condicion2 = $"  idMateria = {idMateria} ";
                        if (lNHorarios.listarProfesores(condicion2).Count < 1)
                        {
                            retorno = "No hay profesores de musica";
                        }
                        break;
                    case "Educacion Fisica":
                        condicion2 = $"  nombreMateria = '{listaMaterias[i].NombreMateria}' ";
                        idMateria = lNHorarios.listarMaterias(condicion2)[0].IdMateria;
                        condicion2 = $"  idMateria = {idMateria} ";
                        if (lNHorarios.listarProfesores(condicion2).Count < 1)
                        {
                            retorno = "No hay profesores de Educacion Fisica";
                        }
                        break;
                    case "Educacion Financiera":
                        condicion2 = $"  nombreMateria = '{listaMaterias[i].NombreMateria}' ";
                        idMateria = lNHorarios.listarMaterias(condicion2)[0].IdMateria;
                        condicion2 = $"  idMateria = {idMateria} ";
                        if (lNHorarios.listarProfesores(condicion2).Count < 1)
                        {
                            retorno = "No hay profesores de Educacion Financiera";
                        }
                        break;
                    case "Contabilidad":
                        condicion2 = $"  nombreMateria = '{listaMaterias[i].NombreMateria}' ";
                        idMateria = lNHorarios.listarMaterias(condicion2)[0].IdMateria;
                        condicion2 = $"  idMateria = {idMateria} ";
                        if (lNHorarios.listarProfesores(condicion2).Count < 2)
                        {
                            retorno = "No hay profesores de Contabilidad";
                        }
                        break;
                    case "Computacion":
                        condicion2 = $"  nombreMateria = '{listaMaterias[i].NombreMateria}' ";
                        idMateria = lNHorarios.listarMaterias(condicion2)[0].IdMateria;
                        condicion2 = $"  idMateria = {idMateria} ";
                        if (lNHorarios.listarProfesores(condicion2).Count < 2)
                        {
                            retorno = "No hay profesores de Computacion";
                        }
                        break;
                }
                i++;

            }

            return retorno;
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {

            try
            {
                int anio = 0;
                anio = Convert.ToInt32(txtAnio.Text);
                if (txtSecciones.Text == "0")
                {
                    Session["_wrn"] = " Atencion: Debe de selecionar una seccion";
                }
                else
                {
                    Session["_seccion"] = txtSecciones.Text;
                    Session["_anio"] = anio.ToString();
                    Session.Remove("_exito");
                    Session.Remove("_wrn");
                    Session.Remove("_err");
                    Response.Redirect("wfrmVistaHorario.aspx", false);
                }


            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int anio;
            string mensaje = "";
            try
            {
                try
                {
                    anio = Convert.ToInt32(txtAnio.Text);
                }
                catch (Exception)
                {
                    txtAnio.Focus();
                    throw new Exception("Ingrese el año");
                }
                string condicion2 = $"  anio = {anio} ";
                if (lNHorarios.listarGrupos(condicion2).Count > 0)
                {
                    List<EGrupo> listaGrupos = lNHorarios.listarGrupos(condicion2);
                    EHorario eHorario = new EHorario();
                    foreach (EGrupo grupo in listaGrupos)
                    {
                        eHorario.EGrupo = grupo;
                        mensaje = lNHorarios.eliminarProcedure(eHorario);
                    }
                    Session["_exito"] = $" Mensaje: {mensaje} ";
                }
                else
                {
                    Session["_wrn"] = " Atencion: No hay grupos creados en para ese año";
                }



            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }
    }
}