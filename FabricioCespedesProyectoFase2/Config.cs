using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricioCespedesProyectoFase2
{
    public static class Config
    {
        public static string getCadenaConexion
        {
            get { return Properties.Settings.Default.CadenaConexion; }
        }

    }
}
