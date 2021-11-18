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

        public int IdMateria { get => idMateria; set => idMateria = value; }
        public string NombreMateria { get => nombreMateria; set => nombreMateria = value; }
        public int Borrado { get => borrado; set => borrado = value; }

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
        public EMateria(int idMateria, string nombreMateria, int borrado)
        {
            this.idMateria = idMateria;
            this.nombreMateria = nombreMateria;
            this.borrado = borrado;
        }

        /// <summary>
        /// Constructor de la clase materia para guardar en la base de datos. Recibe por parámetro solo el nombre materia string, el resto son valores por defecto en la base de datos. 
        /// </summary>
        /// <param name="nombreMateria"></param>
        public EMateria(string nombreMateria)
        {
            this.nombreMateria = nombreMateria;
        }


    }
}
