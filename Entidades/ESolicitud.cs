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
        string justificacion;
        string estado;
        EUsuario eUsuario;
        public ESolicitud()
        {
        }

        public ESolicitud(int idSolicitud, EProfesor eProfesor, EEstudiante eEstudiante, ECicloLectivo eCicloLectivo, EMateria eMateria, int notaNueva, int notaVieja, string observaciones, string estado, EUsuario eUsuario, string justificacion)
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
            this.justificacion = justificacion;
        }

        public int IdSolicitud { get => idSolicitud; set => idSolicitud = value; }
        public EProfesor EProfesor { get => eProfesor; set => eProfesor = value; }
        public EEstudiante EEstudiante { get => eEstudiante; set => eEstudiante = value; }
        public ECicloLectivo ECicloLectivo { get => eCicloLectivo; set => eCicloLectivo = value; }
        public EMateria EMateria { get => eMateria; set => eMateria = value; }
        public int NotaNueva { get => notaNueva; set => notaNueva = value; }
        public int NotaVieja { get => notaVieja; set => notaVieja = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public string Justificacion { get => justificacion; set => justificacion = value; }
        public string Estado { get => estado; set => estado = value; }
        public EUsuario EUsuario { get => eUsuario; set => eUsuario = value; }
    }
}
