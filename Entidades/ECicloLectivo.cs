using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ECicloLectivo
    {
        int idCicloLectivo;
        int estado;
        int trimestre;
        int anio;
        public ECicloLectivo()
        {
        }

        public ECicloLectivo(int idCicloLectivo, int estado, int trimestre, int anio)
        {
            this.idCicloLectivo = idCicloLectivo;
            this.estado = estado;
            this.trimestre = trimestre;
            this.anio = anio;
        }

        public int IdCicloLectivo { get => idCicloLectivo; set => idCicloLectivo = value; }
        public int Estado { get => estado; set => estado = value; }
        public int Trimestre { get => trimestre; set => trimestre = value; }
        public int Anio { get => anio; set => anio = value; }
    }
}
