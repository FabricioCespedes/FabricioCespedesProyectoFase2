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
    public partial class wfrmVistaHorario : System.Web.UI.Page
    {
        LNHorarios lNHorarios = new LNHorarios(Config.getCadConexion);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int anio = Convert.ToInt32(Session["_anio"]);

                string cadena = Session["_seccion"].ToString();

                string[] subs = cadena.Split('-');
                string condicion = "";

                if (Convert.ToInt32(subs[0]) > 9)
                {
                    lblSecciones.Visible = true;
                    txtSecciones.Visible = true;
                    btnCambiar.Visible = true;
                    string grupoDivido = txtSecciones.Text;

                    if (grupoDivido == "A")
                    {
                        condicion = "and m.nombreMateria != 'Contabilidad'";
                    }
                    else
                    {
                        condicion = "and m.nombreMateria != 'Computacion'";
                    }
                }

                cargarDGVHorario(Convert.ToInt32(subs[0]), Convert.ToInt32(subs[1]), anio, condicion);

            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error: {ex.Message} ";
            }

        }


        private void cargarDGVHorario(int grado, int seccion, int anio,string  condicion)
        {
            try
            {

                string condicion2 = $" grado= {grado} and seccion = {seccion} AND anio = {anio} ";
                if (lNHorarios.listarGrupos(condicion2).Count > 0)
                {
                    int idGrupo = lNHorarios.listarGrupos(condicion2)[0].IdGrupo;
                    condicion2 = $" idGrupo = {idGrupo}";

                    if (lNHorarios.obtenerTablaHorarios(condicion2).Tables[0].Rows.Count > 0)
                    {

                        List<string> listaHorariosL = lNHorarios.listaHorario(grado, seccion, anio, "L", condicion);
                        List<string> listaHorariosK = lNHorarios.listaHorario(grado, seccion, anio, "K", condicion);
                        List<string> listaHorariosM = lNHorarios.listaHorario(grado, seccion, anio, "M", condicion);
                        List<string> listaHorariosJ = lNHorarios.listaHorario(grado, seccion, anio, "J", condicion);
                        List<string> listaHorariosV = lNHorarios.listaHorario(grado, seccion, anio, "V", condicion);

                        List<string> listaHoras = obtenerListaHora();

                        DataTable workTable = new DataTable("Horario");
                        DataColumn column1 = new DataColumn("Lecciones");
                        DataColumn column2 = new DataColumn("Lunes");
                        DataColumn column3 = new DataColumn("Martes");
                        DataColumn column4 = new DataColumn("Miercoles");
                        DataColumn column5 = new DataColumn("Jueves");
                        DataColumn column6 = new DataColumn("Viernes");


                        workTable.Columns.Add(column1);
                        workTable.Columns.Add(column2);
                        workTable.Columns.Add(column3);
                        workTable.Columns.Add(column4);
                        workTable.Columns.Add(column5);
                        workTable.Columns.Add(column6);



                        for (int i = 0; i < 34; i++)
                        {
                            DataRow row1 = workTable.NewRow();
                            row1["Lecciones"] = listaHoras[i].ToString();
                            row1["Lunes"] = listaHorariosL[i].ToString();
                            row1["Martes"] = listaHorariosK[i].ToString();
                            row1["Miercoles"] = listaHorariosM[i].ToString();
                            row1["Jueves"] = listaHorariosJ[i].ToString();
                            row1["Viernes"] = listaHorariosV[i].ToString();
                            workTable.Rows.Add(row1);
                        }
                        GridView1.DataSource = workTable;
                        GridView1.DataBind();
                        for (int i = 0; i < 4; i++)
                        {
                            GridView1.Columns[i].ItemStyle.Width = 200;
                        }

                        for (int i = 1; i < 35; i++)
                        {
                            if (i == 7 || i == 14 || i == 21 || i == 28)
                            {
                                GridView1.Rows[i-1].BackColor = System.Drawing.Color.AntiqueWhite;
                            }
                            else
                            {
                                GridView1.Rows[i - 1].BackColor = System.Drawing.Color.GhostWhite;

                            }

                        }
                    }
                    else
                    {
                        Session["_wrn"] = " Atencion: No existe horarios ";
                    }
                }
                else
                {
                    Session["_wrn"] = "  Atencion: No existe horarios ";
                }
            }
            catch (Exception)
            {
                Session["_err"] = " Atencion: ";
            }
        }


        private List<string> obtenerListaHora()
        {
            List<string> listaHoras = new List<string>();
            string[,] lecciones;
            lecciones = new string[10, 2]
            {
                { "07:20", "08:00" },
                { "08:00", "08:40" },
                { "09:00", "09:40" },
                { "09:40", "10:20" },
                { "10:40", "11:20" },
                { "11:20", "12:00" },
                { "13:00", "13:40" },
                { "13:40", "14:20" },
                { "14:40", "15:20" },
                { "15:20", "16:00" },
            };

            for (int i = 0; i < 10; i++)
            {
                listaHoras.Add(" ");
                listaHoras.Add(lecciones[i, 0] + " a " + lecciones[i, 1]);
                listaHoras.Add(" ");
                switch (i)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                        listaHoras.Add(lecciones[i, 1] + " a " + lecciones[i + 1, 0]);
                        break;
                }
            }
            return listaHoras;
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                int anio = Convert.ToInt32(Session["_anio"]);


                string cadena = Session["_seccion"].ToString();
                string[] subs = cadena.Split('-');
                string condicion = "";

                if (Convert.ToInt32(subs[0]) > 9)
                {
                    lblSecciones.Visible = true;
                    txtSecciones.Visible = true;
                    string grupoDivido = txtSecciones.Text;

                    if (grupoDivido == "A")
                    {
                        condicion = "and m.nombreMateria != 'Contabilidad'";
                    }
                    else
                    {
                        condicion = "and m.nombreMateria != 'Computacion'";
                    }
                }

                cargarDGVHorario(Convert.ToInt32(subs[0]), Convert.ToInt32(subs[1]), anio, condicion);
            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error: {ex.Message} ";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("_exito");
            Session.Remove("_wrn");
            Session.Remove("_err");
            Response.Redirect("wfrmHorario.aspx", false);

        }

    }
}