using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LogicaNegocio
{
    public class LNAsistencia
    {
        string cadConexion;

        ADAsistencia aDAsistencia;
        List<EMateria> listaMaterias;

        /// <summary>
        /// Constructor de la lógica de negocio de laclase Horarios. Recibe 
        /// </summary>
        /// <param name="cadConexion"></param>
        public LNAsistencia(string cadConexion)
        {
            this.cadConexion = cadConexion;
            aDAsistencia = new ADAsistencia(cadConexion);
        }

        /// <summary>
        /// Metodo que retorna las lista de los materias. Recibe un condicion alternativa.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista clase materia</returns>
        public List<EMateria> listarMaterias(string condicion = "")
        {
            List<EMateria> listaM;

            try
            {
                listaM = aDAsistencia.listarMaterias(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaM;
        }

        /// <summary>
        /// Metodo que retorna las lista de los materias. Recibe un condicion alternativa.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista clase materia</returns>
        public List<string> listarHorario(string condicion = "")
        {
            List<string> listaH;

            try
            {
                listaH = aDAsistencia.listarHorario(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaH;
        }

        public List<EEstudiante> listarEstudiantes(string condicion = "")
        {
            List<EEstudiante> listaH;

            try
            {
                listaH = aDAsistencia.listarEstudiantes(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaH;
        }

        /// <summary>
        /// Metodo que retorna las lista de los grupo. Recibe un condicion alternativa.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista string</returns>
        public List<EGrupo> listarGrupos(string condicion = "")
        {
            List<EGrupo> listaGrupos;

            try
            {
                listaGrupos = aDAsistencia.listarGrupos(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaGrupos;
        }

        /// <summary>
        /// Metodo que retorna un data set con los horarios. Recibe un condicion alternativa.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Data set</returns>
        public DataSet obtenerTablaHorarios(string condicion = "")
        {
            DataSet setHorario;
            try
            {
                setHorario = aDAsistencia.obtenerTablaHorarios(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return setHorario;
        }

        public EHorario devolverHorario(string condicion = "")
        {
            EHorario horario;

            try
            {
                horario = aDAsistencia.devolverHorario(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return horario;
        }

        public EAsistencia devolverAsistencia(string condicion = "")
        {
            EAsistencia asistencia;

            try
            {
                asistencia = aDAsistencia.devolverAsistencia(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return asistencia;
        }

        public int modificar(EAsistencia asistencia)
        {
            int resultado;

            try
            {
                resultado = aDAsistencia.modificar(asistencia);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public int insertarAsistencia(EAsistencia asistencia)
        {
            int resultado;

            try
            {
                resultado = aDAsistencia.insertarAsistencia(asistencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public int eliminar(string condicion)
        {
            int result;
            try
            {
                result = aDAsistencia.eliminar(condicion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
