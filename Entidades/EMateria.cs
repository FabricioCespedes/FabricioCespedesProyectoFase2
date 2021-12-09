using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EMateria
    {
        private int idMateria;
        private string nombreMateria;
        private int borrado;
        private string tipoAula;

        public override string ToString()
        {
            return nombreMateria;
        }

        public int IdMateria { get => idMateria; set => idMateria = value; }
        public string NombreMateria { get => nombreMateria; set => nombreMateria = value; }
        public int Borrado { get => borrado; set => borrado = value; }
        public string TipoAula { get => tipoAula; set => tipoAula = value; }

        /// <summary>
        /// Constructor vacio de la clase materia. No recibe nada por parámetro.
        /// </summary>
        /// <remarks>Constructor vacio</remarks>
        public EMateria()
        {
        }

        /// <summary>
        /// Contructor normal de la clase materia. Recibe por parámetro int idMateria, string nombreMateria, int borrado.
        /// </summary>
        /// <param name="idMateria"></param>
        /// <param name="nombreMateria"></param>
        /// <param name="borrado"></param>
        /// <param name="tipoAula"></param>
        public EMateria(int idMateria, string nombreMateria, int borrado, string tipoAula)
        {
            this.idMateria = idMateria;
            this.nombreMateria = nombreMateria;
            this.borrado = borrado;
            this.tipoAula = tipoAula;
        }




    }
}
