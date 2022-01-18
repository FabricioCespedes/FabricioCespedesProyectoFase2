using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FabricioCespedesProyectoFase2
{
    public partial class frmAsistencia : Form
    {
        LNAsistencia lNAsistencia = new LNAsistencia(Config.getCadenaConexion);
        List<EEstudiante> listaEstudiante;
        List<string> listaEstados;
        public frmAsistencia()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarDGV();
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void actualizarDGV()
        {
            dgvEstudiantes.Columns.Clear();
            string cadena = cbxSecciones.Text;
            string[] subs = cadena.Split('-');
            string fecha;
            fecha = dtpFecha.Value.ToString("yyyy-MM-ddd");
            string[] subs2 = fecha.Split('-');
            string dia = obtenerDia();
            string cadena2 = cbxLecciones.Text;
            string[] subs3 = cadena2.Split('a');
            string condicion2 = $" grado= {subs[0]} and seccion = {subs[1]} AND anio = {subs2[0]} ";

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
                        dgvEstudiantes.DataSource = listaEstudiante;
                        dgvEstudiantes.Columns[0].Visible = false;
                        dgvEstudiantes.Columns[1].Visible = false;
                        dgvEstudiantes.Columns[2].Visible = false;
                        dgvEstudiantes.Columns[3].Visible = false;
                        dgvEstudiantes.Columns[4].Visible = false;
                        dgvEstudiantes.Columns[8].Visible = false;
                        dgvEstudiantes.Columns[9].Visible = false;
                        dgvEstudiantes.Columns[10].Visible = false;
                        dgvEstudiantes.Columns[11].Visible = false;
                        dgvEstudiantes.Columns[12].Visible = false;
                        dgvEstudiantes.Columns[13].Visible = false;
                        dgvEstudiantes.Columns[14].Visible = false;
                        dgvEstudiantes.Columns[15].Visible = false;
                        dgvEstudiantes.Columns[5].ReadOnly = true;
                        dgvEstudiantes.Columns[6].ReadOnly = true;
                        dgvEstudiantes.Columns[7].ReadOnly = true;
                        DataGridViewComboBoxColumn estadoEstu = new DataGridViewComboBoxColumn();
                        listaEstados = new List<string>() { "Presente", "Ausente", "Tardia", "Permiso salida", "Salida emergencia" };
                        estadoEstu.DataSource = listaEstados;
                        estadoEstu.HeaderText = "Seleccione un estado";
                        dgvEstudiantes.Columns.Add(estadoEstu);
                        dgvEstudiantes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                        dgvEstudiantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        EMateria materia = (EMateria)cbxMateria.SelectedItem;
                        condicion2 = $" dia = '{dia}' and horaInicio = '{subs3[0]}' and horaFin = '{subs3[1]}' and idMateria = {materia.IdMateria} and idGrupo = {idGrupo} ";
                        int idHorario = lNAsistencia.devolverHorario(condicion2).IdHorario;
                        if (idHorario != 0)
                        {
                            fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
                            for (int i = 0; i < listaEstudiante.Count; i++)
                            {
                                int idEstu = listaEstudiante[i].Id;
                                condicion2 = $" idEstudiante = {idEstu} and idHorario = {idHorario} and fecha = '{fecha}'";

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
                                            dgvEstudiantes.Rows[i].Cells[16].Value = listaEstados[y];
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
                        throw new Exception("No hay estudiantes registrados en ese grupo");
                    }

                }
                else
                {
                    throw new Exception("No existe horarios para ese grupo");
                }
            }
            else
            {
                throw new Exception("El grupo seleccionado no existe");
            }
        }

        private void frmAsistencia_Load(object sender, EventArgs e)
        {

        }

        private void cargarLecciones(string[] subs, string[] subs2, string dia, string materia)
        {

            string condicion = $" g.seccion = {subs[1]} and g.grado = {subs[0]} and g.anio = {subs2[0]} and h.dia = '{dia}' and m.nombreMateria =  '{materia}'";
            cbxLecciones.DataSource = lNAsistencia.listarHorario(condicion);

        }

        private bool cargarMaterias(string[] subs, string[] subs2, string dia)
        {
            bool bandera = false;

            string condicion = $" g.seccion = {Convert.ToInt32(subs[1])} and g.grado = {Convert.ToInt32(subs[0])} and g.anio = {Convert.ToInt32(subs2[0])} and h.dia = '{dia}' ";
            if (lNAsistencia.listarMaterias(condicion).Count > 0)
            {
                cbxMateria.DataSource = lNAsistencia.listarMaterias(condicion);
            }
            else
            {
                 throw new Exception("No hay materias registradas");
            }
            return bandera;
        }

        private void cbxSecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvEstudiantes.Columns.Clear();
                string cadena = cbxSecciones.Text;
                string[] subs = cadena.Split('-');
                string fecha;
                fecha = dtpFecha.Value.ToString("yyyy-MM-ddd");
                string[] subs2 = fecha.Split('-');
                string dia = obtenerDia();
                cbxMateria.Enabled = true;
                cbxMateria.DataSource = null;
                cbxMateria.Items.Clear();
                cbxLecciones.DataSource = null;
                cbxLecciones.Items.Clear();
                cargarMaterias(subs, subs2, dia);
                btnRegistrarAsistencias.Enabled = true;
                btnVerAsistencia.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void cbxMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cadena = cbxSecciones.Text;
                string[] subs = cadena.Split('-');
                string fecha;
                string dia = obtenerDia();
                fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
                string[] subs2 = fecha.Split('-');
                cbxLecciones.Enabled = true;
                
                string materia = cbxMateria.Text;
                cargarLecciones(subs,subs2, dia, materia);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private string obtenerDia()
        {
            DateTime dateValue = dtpFecha.Value;
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

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            cbxSecciones.DataSource = null;
            cbxSecciones.Items.Clear();
            cbxSecciones.Items.Add("7-1");
            cbxSecciones.Items.Add("7-2");
            cbxSecciones.Items.Add("7-3");
            cbxSecciones.Items.Add("7-4");
            cbxSecciones.Items.Add("8-1");
            cbxSecciones.Items.Add("8-2");
            cbxSecciones.Items.Add("8-3");
            cbxSecciones.Items.Add("9-1");
            cbxSecciones.Items.Add("9-2");
            cbxSecciones.Items.Add("10-1");
            cbxSecciones.Items.Add("10-2");
            cbxSecciones.Items.Add("11-1");
            cbxSecciones.Items.Add("11-2");
            cbxMateria.Enabled = false;
            cbxLecciones.Enabled = false;
            dgvEstudiantes.Columns.Clear();
            btnRegistrarAsistencias.Enabled = false;
            btnVerAsistencia.Enabled = false;
        }
       
        private void frmAsistencia_TextChanged(object sender, EventArgs e)
        {
            cbxSecciones.SelectedIndex = 0;
            cbxMateria.Enabled = false;
            cbxLecciones.Enabled = false;
        }

        private void btnRegistrarAsistencias_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = 0;
                string cadena = cbxSecciones.Text;
                string[] subs = cadena.Split('-');
                string fecha;
                fecha = dtpFecha.Value.ToString("yyyy-MM-ddd");
                string[] subs2 = fecha.Split('-');
                string dia = obtenerDia();
                string cadena2 = cbxLecciones.Text;
                string[] subs3 = cadena2.Split('a');
                fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
                string condicion2 = $" grado= {subs[0]} and seccion = {subs[1]} AND anio = {subs2[0]} ";
                int idGrupo = lNAsistencia.listarGrupos(condicion2)[0].IdGrupo;
                EMateria materia = (EMateria)cbxMateria.SelectedItem;
                condicion2 = $" dia = '{dia}' and horaInicio = '{subs3[0]}' and horaFin = '{subs3[1]}' and idMateria = {materia.IdMateria} and idGrupo = {idGrupo} ";
                int idHorario = lNAsistencia.devolverHorario(condicion2).IdHorario;

                for (int i = 0; i < listaEstudiante.Count; i++)
                {
                    int idEstu = listaEstudiante[i].Id;
                    condicion2 = $" idEstudiante = {idEstu} and idHorario = {idHorario} and fecha = '{fecha}'";
                    if (dgvEstudiantes.Rows[i].Cells[16].Value != null)
                    {
                        string estadoNuevo = dgvEstudiantes.Rows[i].Cells[16].Value.ToString();
                        EAsistencia asistencia = new EAsistencia();
                        EEstudiante eEstudiante = new EEstudiante();
                        eEstudiante.Id = idEstu;
                        asistencia.EEstudiante= eEstudiante;
                        EHorario eHorario = new EHorario();
                        asistencia.Estado = estadoNuevo;
                        eHorario.IdHorario = idHorario;
                        asistencia.EHorario = eHorario;
                        asistencia.Fecha = fecha;
                        resultado = guardarAsistencia(asistencia);

                        ;
                    }


                }
                if (resultado > 0)
                {

                    MessageBox.Show("Se ha guardado correctamente");
                    actualizarDGV();
                }
                else
                {
                    MessageBox.Show("Error al actualizar");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private int guardarAsistencia(EAsistencia asistencia)
        {
            int resultado = 0;
            string condicion2 = $" idEstudiante = {asistencia.EEstudiante.Id} and idHorario = {asistencia.EHorario.IdHorario} and fecha = '{asistencia.Fecha}'";
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

        private void cbxSecciones_ValueMemberChanged(object sender, EventArgs e)
        {
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string fecha;
            fecha = dtpFecha.Value.ToString("yyyy-MM-dd");

        }
    }
}
