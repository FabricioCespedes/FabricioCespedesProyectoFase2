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
    public partial class frmMenuPrincipal : Form
    {

        frmAsistencia vistaAsistencia;
        frmCalificaciones vistaCalificaciones;
        frmCreacionHorarios vistaHorarios;
        public frmMenuPrincipal()
        {
            InitializeComponent();

        }

        private void cerrarFormulario(object sender, FormClosedEventArgs e)
        {
            vistaAsistencia = null;
            vistaCalificaciones = null;
            vistaHorarios = null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (vistaHorarios == null)
            {
                vistaHorarios = new frmCreacionHorarios();

                vistaHorarios.MdiParent = this;

                vistaHorarios.FormClosed += new FormClosedEventHandler(cerrarFormulario);

                vistaHorarios.Show();
            }
            else
            {
                vistaHorarios.Activate();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (vistaAsistencia == null)
            {
                vistaAsistencia = new  frmAsistencia();

                vistaAsistencia.MdiParent = this;

                vistaAsistencia.FormClosed += new FormClosedEventHandler(cerrarFormulario);

                vistaAsistencia.Show();
            }
            else
            {
                vistaAsistencia.Activate();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (vistaCalificaciones == null)
            {
                vistaCalificaciones = new frmCalificaciones();

                vistaCalificaciones.MdiParent = this;

                vistaCalificaciones.FormClosed += new FormClosedEventHandler(cerrarFormulario);

                vistaCalificaciones.Show();
            }
            else
            {
                vistaCalificaciones.Activate();
            }
        }
    }
}
