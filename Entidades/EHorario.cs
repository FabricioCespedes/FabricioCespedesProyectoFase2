using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EHorario
	{
		int idHorario;
		EMateria eMateria;
		EProfesor eProfesor;
		string dia;
        string horaInicio;
        string horaFinal;
		EAula eAula;
		EGrupo eGrupo;

		/// <summary>
		/// Constructor vacio de la clase horario. No recibe nada por parámetro.
		/// </summary>
		public EHorario()
        {
        }

        /// <summary>
        /// Constructor normal de clase horario. Recibe por parámetro un id horario, una materia un profesor, hora de inicio y hora final, una aula y unu grupo.
        /// </summary>
        /// <param name="idHorario"></param>
        /// <param name="eMateria"></param>
        /// <param name="eProfesor"></param>
        /// <param name="dia"></param>
        /// <param name="horaInicio"></param>
        /// <param name="horaFinal"></param>
        /// <param name="eAula"></param>
        /// <param name="eGrupo"></param>
        public EHorario(int idHorario, EMateria eMateria, EProfesor eProfesor, string dia, string horaInicio, string horaFinal, EAula eAula, EGrupo eGrupo)
        {
            this.idHorario = idHorario;
            this.eMateria = eMateria;
            this.eProfesor = eProfesor;
            this.dia = dia;
            this.horaInicio = horaInicio;
            this.horaFinal = horaFinal;
            this.eAula = eAula;
            this.eGrupo = eGrupo;
        }

        public override string ToString()
        {
            if (eMateria != null )
            {
                return "Aula = " + eAula.CodigoAula + " / " +
                        "Profesor = " + eProfesor.Nombre + " " + eProfesor.Apellido1 + " / " +
                        "Materia = " + eMateria.NombreMateria;
            }
            else
            {
                return "Lección libre";
            }
        }

        public int IdHorario { get => idHorario; set => idHorario = value; }
        public EMateria EMateria { get => eMateria; set => eMateria = value; }
        public EProfesor EProfesor { get => eProfesor; set => eProfesor = value; }
        public string Dia { get => dia; set => dia = value; }
        public string HoraInicio { get => horaInicio; set => horaInicio = value; }
        public string HoraFinal { get => horaFinal; set => horaFinal = value; }
        public EAula EAula { get => eAula; set => eAula = value; }
        public EGrupo EGrupo { get => eGrupo; set => eGrupo = value; }
    }
}
