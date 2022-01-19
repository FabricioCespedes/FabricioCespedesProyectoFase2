using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LogicaNegocio
{
    public class LNProfesores
    {
        string cadConexion;

        ADProfesores aDProfesores;
        List<EMateria> listaMaterias;

        /// <summary>
        /// Constructor de la lógica de negocio de laclase Horarios. Recibe 
        /// </summary>
        /// <param name="cadConexion"></param>
        public LNProfesores(string cadConexion)
        {
            this.cadConexion = cadConexion;
            aDProfesores = new ADProfesores(cadConexion);
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
                listaM = aDProfesores.listarMaterias(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaM;
        }

        /// <summary>
        /// Método que obtiene la lista de provincias desde la base de datos. Recibe un condicion opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista de materias</returns>
        public List<EProvincia> listarProvincias(string condicion = "")
        {
            List<EProvincia> listaP;

            try
            {
                listaP = aDProfesores.listarProvincias(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaP;
        }

        /// <summary>
        /// Método que obtiene la lista de cantones desde la base de datos. Recibe un condicion opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista de materias</returns>
        public List<ECanton> listarCanton(string condicion = "")
        {
            List<ECanton> listaP;

            try
            {
                listaP = aDProfesores.listarCanton(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaP;
        }

        /// <summary>
        /// Método que obtiene la lista de distritos desde la base de datos. Recibe un condicion opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista de materias</returns>
        public List<EDistrito> listarDistritos(string condicion = "")
        {
            List<EDistrito> listaP;

            try
            {
                listaP = aDProfesores.listarDistritos(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaP;
        }

        public int modificar(EProfesor profesor)
        {
            int resultado;

            try
            {
                resultado = aDProfesores.modificar(profesor);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public int insertar(EProfesor profesor)
        {
            int resultado;

            try
            {
                resultado = aDProfesores.insertar(profesor);
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
                result = aDProfesores.eliminar(condicion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataSet listarProfesores(string condicion = "")
        {
            DataSet tablaSolicitudes = new DataSet();

            try
            {
                tablaSolicitudes = aDProfesores.listarProfesores(condicion,true);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return tablaSolicitudes;
        }
    }
}
