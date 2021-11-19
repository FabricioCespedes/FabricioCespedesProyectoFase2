using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LogicaNegocio
{
    public class LNHorarios
    {
        string cadConexion;
        DataTable Horarios;
        DataSet setHorarios;
        ADHorarios aDHorarios;
        List<EGrupo> listaGrupos;
        List<EMateria> listaMaterias;
        List<EProfesor> listaProfesores;
        List<EAula> listaAulas;

        /// <summary>
        /// Constructor de la lógica de negocio de laclase Horarios. Recibe 
        /// </summary>
        /// <param name="cadConexion"></param>
        public LNHorarios(string cadConexion)
        {
            this.cadConexion = cadConexion;
            aDHorarios = new ADHorarios(cadConexion);
            listaGrupos = aDHorarios.listarGrupos();
            listaMaterias = aDHorarios.listarMaterias();
            listaProfesores = aDHorarios.listarProfesores();
            listaAulas = aDHorarios.listarAulas();
        }

        public void procesoCrearHorarios()
        {
            foreach (EGrupo grupo in listaGrupos)
            {
                recorrerMaterias(grupo);
            }
        }

        private void recorrerMaterias(EGrupo grupo)
        {
            foreach (EMateria materia in listaMaterias)
            {
                recorrerGrado(materia, grupo);
            }
        }

        private void recorrerGrado(EMateria materia, EGrupo grupo)
        {
            switch (grupo.Grado)
            {
                case 7:
                case 8:
                case 9:
                    switch (materia.NombreMateria)
                    {
                        case "Ingles":

                            break;
                        case "Español":
                        case "Estudios Sociales":
                        case "ciencias":
                        case "Matematicas":

                            break;
                        case "Educacion Financiera":

                        case "Contabilidad":
                            break;
                        default:
                            break;
                    }
                    break;
                case 10:
                case 11:
                case 12:
                    switch (materia.NombreMateria)
                    {
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void recorrerDias()
        {
            string[] dias = new string[] { "L", "K", "M", "J", "V" };

            foreach (string dia in dias)
            {
                recorrerLecciones(dia);
            }
        }

        private void recorrerLecciones(string dia)
        {
            string[,] lecciones = new string[10, 2]
            {
              { "07:20", "08:00" },
              { "08:00", "08:40" },
              { "09:00", "09:40" },
              { "09:40", "10:20" },
              { "10:40", "11:20" },
              { "11:20", "12:00" },
              { "13:00", "13:40" },
              { "13:40", "14:20" },                       
              { "14:40", "15:20" },
              { "15:20", "16:00" },
            };
            for (int i = 0; i < 10; i++)
            {
                validarAula(dia, lecciones[i,0], lecciones[i,1]);
            }
        }

        private void validarAula(string dia, string fechaInicial, string fechaFinal)
        {
            foreach (EMateria item in listaMaterias)
            {

            }
            string condicion = $" idMateria = '{}' AND horaInicio = '07:00' AND horaFin = '07:00' AND dia = 'L'";
            if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
            {

            }
        }

        public void ingresarLeccion(EHorario horario)
        {          
            try
            {
                if (Horarios == null)
                {
                    setHorarios = aDHorarios.obtenerTablaHorarios();
                    Horarios = setHorarios.Tables[0];
                    Horarios.Rows.Clear();
                }         
                DataRow row = Horarios.NewRow();
                row["idMateria"] = horario.EMateria.IdMateria;
                row["idProfesor"] = horario.EProfesor.Id;
                row["dia"] = horario.Dia;
                row["horaInicio"] = horario.HoraInicio;
                row["horaFin"] = horario.HoraFinal;
                row["idAula"] = horario.EAula.IdAula;
                row["idGrupo"] = horario.EGrupo.IdGrupo;
                Horarios.Rows.Add(row);
                aDHorarios.actualizarDataSet(setHorarios);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
