using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EAsistencia
    {
        EHorario eHorario;
        EEstudiante eEstudiante;
        string estado;
        string fecha;
        public EAsistencia()
        {
        }

        public EAsistencia(EHorario eHorario, EEstudiante eEstudiante, string estado, string fecha)
        {
            this.eHorario = eHorario;
            this.eEstudiante = eEstudiante;
            this.estado = estado;
            this.fecha = fecha;
        }

        public EHorario EHorario { get => eHorario; set => eHorario = value; }
        public EEstudiante EEstudiante { get => eEstudiante; set => eEstudiante = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Fecha { get => fecha; set => fecha = value; }
    }
}
