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
        }

        private void cargarDGVHorario(int grado, int seccion , int anio, string condicion )
        {
            try
            {
                lvHorarios.Items.Clear();

                List<EHorario> listaHorariosL = lNHorarios.listaHorario(grado, seccion, anio, "L", condicion);
                List<EHorario> listaHorariosK = lNHorarios.listaHorario(grado, seccion, anio, "K", condicion);
                List<EHorario> listaHorariosM = lNHorarios.listaHorario(grado, seccion, anio, "M", condicion);
                List<EHorario> listaHorariosJ = lNHorarios.listaHorario(grado, seccion, anio, "J", condicion);
                List<EHorario> listaHorariosV = lNHorarios.listaHorario(grado, seccion, anio, "V", condicion);

                for (int i = 0; i < 10; i++)
                {
                    ListViewItem item = new ListViewItem();

                    item = lvHorarios.Items.Add(i.ToString());
                    item.SubItems.Add(listaHorariosL[i].ToString());
                    item.SubItems.Add(listaHorariosK[i].ToString());
                    item.SubItems.Add(listaHorariosM[i].ToString());
                    item.SubItems.Add(listaHorariosJ[i].ToString());
                    item.SubItems.Add(listaHorariosV[i].ToString());
                }
                lvHorarios.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvHorarios.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnCrearHorario_Click(object sender, EventArgs e)
        {
           
            lNHorarios.procesoCrearHorarios();
        }

        private void frmCreacionHorarios_Load(object sender, EventArgs e)
        {

        }

        private void btnVerHorarios_Click(object sender, EventArgs e)
        {
            try
            {
                
                string cadena = cbxSecciones.Text;

                string[] subs = cadena.Split('-');
                string condicion = "";
                int anio = Convert.ToInt32(txtAnio.Text);
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
                    // string grupoDivido = cbxEspecialidad.
                }
                else
                {
                    cbxEspecialidad.Visible = false;

                }

                cargarDGVHorario(Convert.ToInt32(subs[0]), Convert.ToInt32(subs[1]), anio, condicion);
            }
            catch (Exception)
            {

                MessageBox.Show("Ingrese solo numeros");
            }

        }
    }
}
