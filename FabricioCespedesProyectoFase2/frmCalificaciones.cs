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
    public partial class frmCalificaciones : Form
    {
        LNCalificaciones lNCalificaciones = new LNCalificaciones(Config.getCadenaConexion);
        List<EEstudiante> listaEstudiante;

        public frmCalificaciones()
        {
            InitializeComponent();
        }

        private void frmCalificaciones_Load(object sender, EventArgs e)
        {

        }

        private void cbxSecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cadena = cbxSecciones.Text;
                string[] subs = cadena.Split('-');
                int anio = (int)numAnio.Value;
                cbxMaterias.Enabled = true;
                cbxProfesores.Enabled = true;
                cargarMaterias(subs, anio);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private bool cargarMaterias(string[] subs, int anio)
        {
            bool bandera = false;

            string condicion = $" g.seccion = {Convert.ToInt32(subs[1])} and g.grado = {Convert.ToInt32(subs[0])} and g.anio = {anio} ";
            if (lNCalificaciones.listarMaterias(condicion).Count > 0)
            {
                cbxMaterias.DataSource = lNCalificaciones.listarMaterias(condicion);
            }
            else
            {
                throw new Exception("No hay materias registradas");
            }
            return bandera;
        }

        private void cbxMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EMateria materia = (EMateria)cbxMaterias.SelectedItem;
                string condicion = $" idMateria = {materia.IdMateria} ";
                cbxProfesores.DataSource = lNCalificaciones.listarProfesores(condicion);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cargarEstudiantes(string[] subs)
        {

            string condicion = $" and g.grado= {subs[0]} and g.seccion = {subs[1]} AND g.anio = {(int)numAnio.Value} ";
            listaEstudiante = lNCalificaciones.listarEstudiantes(condicion);
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
                dgvEstudiantes.Columns.Add("1", "Primer trimestre");
                dgvEstudiantes.Columns.Add("2", "Segundo trimestre");
                dgvEstudiantes.Columns.Add("3", "Tercer trimestre");
                dgvEstudiantes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                dgvEstudiantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                throw new Exception("No hay estudiantes en el grupo solicitado");
            }
        }

        private void cargarCalificaciones()
        {
            ECicloLectivo eCicloLectivo;
            ECalificacion calificacion = new ECalificacion();
            EEstudiante eEstudiante;
            ECalificacion eCalificacion;
            string condicion = "";
            try
            {
                condicion = $"  trimestre = 1 and anio = {(int)numAnio.Value}";
                eCicloLectivo = lNCalificaciones.devolverCiclo(condicion);
                calificacion.ECicloLectivo = eCicloLectivo;
                calificacion.EMateria = (EMateria)cbxMaterias.SelectedItem;
                
                for (int i = 0; i < listaEstudiante.Count; i++)
                {
                    eEstudiante = listaEstudiante[i];
                    condicion = $" idMateria = {calificacion.EMateria.IdMateria} and idEstudiante = {listaEstudiante[i].Id} and idCicloLectivo = {calificacion.ECicloLectivo.IdCicloLectivo} ";
                    eCalificacion = lNCalificaciones.devolverCalificacion(condicion);
                    if (eCalificacion.NotaFinal >= 0)
                    {
                        dgvEstudiantes.Rows[i].Cells[16].Value = eCalificacion.NotaFinal;
                    }
                    condicion = $"  trimestre = 2 and anio = {(int)numAnio.Value}";
                    eCicloLectivo = lNCalificaciones.devolverCiclo(condicion);
                    condicion = $" idMateria = {calificacion.EMateria.IdMateria} and idEstudiante = {listaEstudiante[i].Id} and idCicloLectivo = {eCicloLectivo.IdCicloLectivo} ";
                    eCalificacion = lNCalificaciones.devolverCalificacion(condicion);
                    if (eCalificacion.NotaFinal >= 0)
                    {
                        dgvEstudiantes.Rows[i].Cells[17].Value = eCalificacion.NotaFinal;
                    }
                    condicion = $"  trimestre = 3 and anio = {(int)numAnio.Value}";
                    eCicloLectivo = lNCalificaciones.devolverCiclo(condicion);
                    condicion = $" idMateria = {calificacion.EMateria.IdMateria} and idEstudiante = {listaEstudiante[i].Id} and idCicloLectivo = {eCicloLectivo.IdCicloLectivo} ";
                    eCalificacion = lNCalificaciones.devolverCalificacion(condicion);
                    if (eCalificacion.NotaFinal >= 0)
                    {
                        dgvEstudiantes.Rows[i].Cells[18].Value = eCalificacion.NotaFinal;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cbxProfesores_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRegistrar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            ECicloLectivo eCicloLectivo;
            ECalificacion calificacion = new ECalificacion();

            int num= 0;
            string condicion = "";
            try
            {
                calificacion.EMateria = (EMateria)cbxMaterias.SelectedItem;
                calificacion.EProfesor = (EProfesor)cbxProfesores.SelectedItem;
                for (int i = 0; i < listaEstudiante.Count; i++)
                {
                    calificacion.EEstudiante = listaEstudiante[i];
                    if (dgvEstudiantes.Rows[i].Cells[16].Value != null)
                    {
                        string cali1 = dgvEstudiantes.Rows[i].Cells[16].Value.ToString();
                        calificacion.NotaFinal = Convert.ToInt32(cali1);
                        condicion = $"  trimestre = 1 and anio = {(int)numAnio.Value}";
                        eCicloLectivo = lNCalificaciones.devolverCiclo(condicion);
                        if (eCicloLectivo.Estado == 1)
                        {
                            calificacion.ECicloLectivo = eCicloLectivo;
                            num = registrarCalificacion(calificacion);
                        }
                        else
                        {
                            MessageBox.Show("El ciclo lectivo 1 esta cerrado, debe solicitar al director");
                            break;
                        }

                    }
                    if (dgvEstudiantes.Rows[i].Cells[17].Value != null)
                    {
                        string cali1 = dgvEstudiantes.Rows[i].Cells[17].Value.ToString();
                        calificacion.NotaFinal = Convert.ToInt32(cali1);
                        condicion = $"  trimestre = 2 and anio = {(int)numAnio.Value}";
                        eCicloLectivo = lNCalificaciones.devolverCiclo(condicion);
                        if (eCicloLectivo.Estado == 1)
                        {
                            calificacion.ECicloLectivo = eCicloLectivo;
                            num = registrarCalificacion(calificacion);
                        }
                        else
                        {
                            MessageBox.Show("El ciclo lectivo 2 esta cerrado, debe solicitar al director");
                            break;
                        }
                    }
                    if (dgvEstudiantes.Rows[i].Cells[18].Value != null)
                    {
                        string cali1 = dgvEstudiantes.Rows[i].Cells[18].Value.ToString();
                        calificacion.NotaFinal = Convert.ToInt32(cali1);
                        condicion = $"  trimestre = 3 and anio = {(int)numAnio.Value}";
                        eCicloLectivo = lNCalificaciones.devolverCiclo(condicion);
                        if (eCicloLectivo.Estado == 1)
                        {
                            calificacion.ECicloLectivo = eCicloLectivo;
                            num = registrarCalificacion(calificacion);
                        }
                        else
                        {
                            MessageBox.Show("El ciclo lectivo 3 esta cerrado, debe solicitar al director");
                        }
                    }
                }
                if (num > 0)
                {
                    MessageBox.Show("Se ha guardado con exito");
                }
                dgvEstudiantes.Columns.Clear();
                string cadena = cbxSecciones.Text;
                string[] subs = cadena.Split('-');
                cargarEstudiantes(subs);
                cargarCalificaciones();

            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese solo numeros");
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dgvEstudiantes.Columns.Clear();
            string cadena = cbxSecciones.Text;
            string[] subs = cadena.Split('-');
            cargarEstudiantes(subs);
            cargarCalificaciones();
        }
    }
}
