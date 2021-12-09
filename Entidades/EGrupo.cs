using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EGrupo
    {
        private int idGrupo;
        private int grado;
        private int seccion;
        private int anio;
        private int borradoAula;

        /// <summary>
        /// Constructor vacio de la grupo. No recibe nada por parámetro. 
        /// </summary>
        /// <remarks>Constructor vacio</remarks>
        public EGrupo()
        {
        }

        /// <summary>
        /// Constructor normal de la clase grupo. Recibe por parámetro int idGrupo, int grado, int seccion, int anio, int borradoAula.
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <param name="grado"></param>
        /// <param name="seccion"></param>
        /// <param name="anio"></param>
        /// <param name="borradoAula"></param>
        /// <remarks>Constructor de la clase grupo</remarks>
        public EGrupo(int idGrupo, int grado, int seccion, int anio, int borradoAula)
        {
            this.idGrupo = idGrupo;
            this.grado = grado;
            this.seccion = seccion;
            this.anio = anio;
            this.borradoAula = borradoAula;
        }

        /// <summary>
        /// Constructor de la clase grupo para guardar en la base de datos, recibe por parámetro int grado, int seccion, int anio.
        /// </summary>
        /// <param name="grado"></param>
        /// <param name="seccion"></param>
        /// <param name="anio"></param>
        /// <remarks>Constructor de la clase grupo para guardar en la base de datos</remarks>
        public EGrupo( int grado, int seccion, int anio)
        {
            this.grado = grado;
            this.seccion = seccion;
            this.anio = anio;
        }

        public int IdGrupo { get => idGrupo; set => idGrupo = value; }
        public int Grado { get => grado; set => grado = value; }
        public int Seccion { get => seccion; set => seccion = value; }
        public int Anio { get => anio; set => anio = value; }
        public int BorradoAula { get => borradoAula; set => borradoAula = value; }
    }
}
