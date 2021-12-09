using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ESolicitud
    {
        int idSolicitud;
        EProfesor eProfesor;
        EEstudiante eEstudiante;
        ECicloLectivo eCicloLectivo;
        EMateria eMateria;
        int notaNueva;
        int notaVieja;
        string observaciones;
        string estado;
        EUsuario eUsuario;
        public ESolicitud()
        {
        }

        public ESolicitud(int idSolicitud, EProfesor eProfesor, EEstudiante eEstudiante, ECicloLectivo eCicloLectivo, EMateria eMateria, int notaNueva, int notaVieja, string observaciones, string estado, EUsuario eUsuario)
        {
            this.idSolicitud = idSolicitud;
            this.eProfesor = eProfesor;
            this.eEstudiante = eEstudiante;
            this.eCicloLectivo = eCicloLectivo;
            this.eMateria = eMateria;
            this.notaNueva = notaNueva;
            this.notaVieja = notaVieja;
            this.observaciones = observaciones;
            this.estado = estado;
            this.eUsuario = eUsuario;
        }
    }
}
