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
        }

        private void btnCrearHorario_Click(object sender, EventArgs e)
        {

           MessageBox.Show(lNHorarios.procesoCrearHorarios());
        }
    }
}
