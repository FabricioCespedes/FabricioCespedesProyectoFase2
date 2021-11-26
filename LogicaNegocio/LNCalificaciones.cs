using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio
{
    public class LNCalificaciones
    {
        string cadConexion;

        ADCalificaciones aDCalificaciones;
        List<EMateria> listaMaterias;

        public LNCalificaciones(string cadConexion)
        {
            this.cadConexion = cadConexion;
            aDCalificaciones = new ADCalificaciones(cadConexion);
        }

        public List<EEstudiante> listarEstudiantes(string condicion = "")
        {
            List<EEstudiante> listaH;

            try
            {
                listaH = aDCalificaciones.listarEstudiantes(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaH;
        }

        public List<EProfesor> listarProfesores(string condicion = "")
        {
            List<EProfesor> listaP;

            try
            {
                listaP = aDCalificaciones.listarProfesores(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaP;
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
                listaGrupos = aDCalificaciones.listarGrupos(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaGrupos;
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
                listaM = aDCalificaciones.listarMaterias(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaM;
        }

        public ECicloLectivo devolverCiclo(string condicion)
        {
            ECicloLectivo eCicloLectivo = new ECicloLectivo();

            try
            {
                eCicloLectivo = aDCalificaciones.devolverCiclo(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return eCicloLectivo;
        }

        public ECalificacion devolverCalificacion(string condicion)
        {
            ECalificacion eCicloLectivo = new ECalificacion();

            try
            {
                eCicloLectivo = aDCalificaciones.devolverCalificacion(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return eCicloLectivo;
        }

        public int modificar(ECalificacion eCalificacion)
        {
            int resultado;

            try
            {
                resultado = aDCalificaciones.modificar(eCalificacion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public int insertarCalificacion(ECalificacion eCalificacion)
        {
            int resultado;

            try
            {
                resultado = aDCalificaciones.insertarCalificacion(eCalificacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
    }
}
