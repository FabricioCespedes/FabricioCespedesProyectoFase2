using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EAula
    {
        private int idAula;
        private string codigoAula;
        private string tipoAula;
        private string borradoAula;
        
        public int IdAula { get => idAula; set => idAula = value; }
        public string CodigoAula { get => codigoAula; set => codigoAula = value; }
        public string TipoAula { get => tipoAula; set => tipoAula = value; }
        public string BorradoAula { get => borradoAula; set => borradoAula = value; }

        /// <summary>
        /// Constructor vacio de la aula. No recibe nada por parámetro. 
        /// </summary>
        /// <remarks>Constructor vacio</remarks>
        public EAula()
        {
        }

        /// <summary>
        /// Constructor normal de la clase aula. Recibe por parámetro un int idAula, string codigoAula, string tipoAula, string borradoAula.
        /// </summary>
        /// <param name="idAula"></param>
        /// <param name="codigoAula"></param>
        /// <param name="tipoAula"></param>
        /// <param name="borradoAula"></param>
        /// <remarks>Constructor de la clase aula</remarks>
        public EAula(int idAula, string codigoAula, string tipoAula, string borradoAula)
        {
            this.idAula = idAula;
            this.codigoAula = codigoAula;
            this.tipoAula = tipoAula;
            this.borradoAula = borradoAula;
        }

        /// <summary>
        /// Constructor de la clase aula, no lleva id ni borrado, sirve para crear clase aula que va a la base de datos. Recibe por parámetro string codigoAula, string tipoAula.
        /// </summary>
        /// <param name="codigoAula"></param>
        /// <param name="tipoAula"></param>
        /// <remarks>Constructor de la clase aula para guardar en la base de datos</remarks>
        public EAula(string codigoAula, string tipoAula)
        {
            this.codigoAula = codigoAula;
            this.tipoAula = tipoAula;

        }

    }
}
