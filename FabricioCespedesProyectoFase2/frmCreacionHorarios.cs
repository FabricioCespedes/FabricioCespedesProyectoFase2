using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FabricioCespedesProyectoFase2
{
    public partial class frmCreacionHorarios : Form
    {
        LNHorarios lNHorarios = new LNHorarios(Config.getCadenaConexion);
        public frmCreacionHorarios()
        {
            InitializeComponent();
            cbxEspecialidad.SelectedIndex = 0;
            cbxSecciones.SelectedIndex = 0;
        }

        private void cargarDGVHorario(int grado, int seccion , int anio, string condicion )
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
                        lvHorarios.Items.Clear();

                        List<string> listaHorariosL = lNHorarios.listaHorario(grado, seccion, anio, "L", condicion);
                        List<string> listaHorariosK = lNHorarios.listaHorario(grado, seccion, anio, "K", condicion);
                        List<string> listaHorariosM = lNHorarios.listaHorario(grado, seccion, anio, "M", condicion);
                        List<string> listaHorariosJ = lNHorarios.listaHorario(grado, seccion, anio, "J", condicion);
                        List<string> listaHorariosV = lNHorarios.listaHorario(grado, seccion, anio, "V", condicion);

                        List<string> listaHoras = obtenerListaHora();

                        for (int i = 0; i < 34; i++)
                        {
                            ListViewItem item = new ListViewItem();
                            
                            item = lvHorarios.Items.Add(listaHoras[i]);
                            item.SubItems.Add(listaHorariosL[i].ToString());
                            item.SubItems.Add(listaHorariosK[i].ToString());
                            item.SubItems.Add(listaHorariosM[i].ToString());
                            item.SubItems.Add(listaHorariosJ[i].ToString());
                            item.SubItems.Add(listaHorariosV[i].ToString());
                        }
                        lvHorarios.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        lvHorarios.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                        for (int i = 0; i < 34;i++)
                        {
                            lvHorarios.Items[i].BackColor = Color.AntiqueWhite;

                            if (i  == 7 || i == 14 || i == 21 || i == 28)
                            {
                                lvHorarios.Items[i-1].BackColor = Color.DarkGray;
                            }

                        }



                        colLunes.Width = 250;
                        colMartes.Width = 250;
                        colMiercoles.Width =250;
                        colJueves.Width = 250;
                        colViernes.Width = 250;
                    }
                    else
                    {
                        throw new Exception("No existe horarios para ese grupo");
                    }
                }else
                {
                    txtAnio.Focus();
                    throw new Exception("El grupo seleccionado no existe");
                }
            }
            catch (Exception)
            {

                throw new Exception("No existe horarios para ese grupo");
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
                listaHoras.Add(lecciones[i,0] + " a " + lecciones[i, 1]);
                listaHoras.Add(" ");
                switch (i)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                        listaHoras.Add(lecciones[i, 1] + " a " + lecciones[i+1, 0]);
                        break;
                }
            }
            return listaHoras;
        }

        private void btnCrearHorario_Click(object sender, EventArgs e)
        {
            int anio;
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
                    if (lNHorarios.listarMaterias().Count > 0)
                    {
                        if (lNHorarios.listarAulas($" and  tipoAula = 'normal' ").Count >= 8 )
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
                                            MessageBox.Show("Precione aceptar y espera un momento mientras se crean los horarios");
                                            mensaje = lNHorarios.procesoCrearHorarios(anio);
                                            if (mensaje != "")
                                            {
                                                MessageBox.Show(mensaje);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Los horarios ya estan creados para ese año");
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception(revisarProfesor());
                                    }
                                    
                                }
                                else
                                {
                                    throw new Exception("No hay aulas sufiencientes de contabilidad");
                                }
                            }
                            else
                            {
                                throw new Exception("No hay aulas sufiencientes de computo");
                            }
                        }
                        else
                        {
                            throw new Exception("No hay aulas sufiencientes normales");
                        }

                    }
                    else
                    {
                        throw new Exception("No hay materias");
                    }
                }
                else
                {
                    txtAnio.Focus();
                    throw new Exception("No hay grupos creados en para ese año");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private string revisarProfesor()
        {
            string retorno = "";
            string condicion2 = "";
            int idMateria = 0;
            List<EMateria> listaMaterias = lNHorarios.listarMaterias();
            int i = 0;
            while (retorno == "" && i < listaMaterias.Count )
            {
                switch (listaMaterias[i].NombreMateria)
                {
                    case "Matematicas":
                        condicion2 = $"  nombreMateria = '{listaMaterias[i].NombreMateria}' ";
                        idMateria = lNHorarios.listarMaterias(condicion2)[0].IdMateria;
                        condicion2 = $"  idMateria = {idMateria} ";
                        if (lNHorarios.listarProfesores(condicion2).Count < 2)
                        {
                            retorno  = "No hay profesores de matematicas";
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

        private void frmCreacionHorarios_Load(object sender, EventArgs e)
        {

        }

        private void btnVerHorarios_Click(object sender, EventArgs e)
        {
            try
            {
                int anio = 0;
                string cadena = cbxSecciones.Text;
                string[] subs = cadena.Split('-');
                string condicion = "";
                try
                {
                    anio = Convert.ToInt32(txtAnio.Text);
                }
                catch (Exception)
                {
                    txtAnio.Focus();
                    throw new Exception("Ingrese solo números");                   
                }

                if (Convert.ToInt32(subs[0]) > 9)
                {                    
                    cbxEspecialidad.Visible = true;
                    string grupoDivido = cbxEspecialidad.Text;

                    if (grupoDivido == "A")
                    {
                        condicion = "and m.nombreMateria != 'Contabilidad'";
                    }
                    else
                    {
                        condicion = "and m.nombreMateria != 'Computacion'";
                    }
                }
                else
                {
                    cbxEspecialidad.Visible = false;
                }

                cargarDGVHorario(Convert.ToInt32(subs[0]), Convert.ToInt32(subs[1]), anio, condicion);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }

        }

        private void lvHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBorrarHorarios_Click(object sender, EventArgs e)
        {
            int anio;
            string mensaje="";
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
                    MessageBox.Show(mensaje);
                }
                else
                {
                    txtAnio.Focus();
                    throw new Exception("No hay grupos creados en para ese año");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
