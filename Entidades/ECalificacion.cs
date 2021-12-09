using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ECalificacion
    {
        EEstudiante eEstudiante;
        EMateria eMateria;
        ECicloLectivo eCicloLectivo;
        int notaFinal;
        EProfesor eProfesor;
        int borrado;

        public ECalificacion()
        {
        }

        public ECalificacion(EEstudiante eEstudiante, EMateria eMateria, ECicloLectivo eCicloLectivo, int notaFinal, EProfesor eProfesor, int borrado)
        {
            this.eEstudiante = eEstudiante;
            this.eMateria = eMateria;
            this.eCicloLectivo = eCicloLectivo;
            this.notaFinal = notaFinal;
            this.eProfesor = eProfesor;
            this.borrado = borrado;
        }

        public EEstudiante EEstudiante { get => eEstudiante; set => eEstudiante = value; }
        public EMateria EMateria { get => eMateria; set => eMateria = value; }
        public ECicloLectivo ECicloLectivo { get => eCicloLectivo; set => eCicloLectivo = value; }
        public int NotaFinal { get => notaFinal; set => notaFinal = value; }
        public EProfesor EProfesor { get => eProfesor; set => eProfesor = value; }
        public int Borrado { get => borrado; set => borrado = value; }
    }
}
