using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio
{
    public class LNInicio
    {
        string cadConexion;

        ADInicio  aDInicio;

        /// <summary>
        /// Constructor de la lógica de negocio de login. Recibe la cadena de conexion.
        /// </summary>
        /// <param name="cadConexion"></param>
        public LNInicio(string cadConexion)
        {
            this.cadConexion = cadConexion;
            aDInicio = new ADInicio(cadConexion);
        }

        public EProfesor obtenerProfesor(string condicion = "")
        {
            EProfesor profesor;

            try
            {
                profesor = aDInicio.obtenerProfesor(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return profesor;
        }

        public int login(string clave, string usuario)
        {
            int retorno;

            try
            {
                retorno = aDInicio.login(clave,usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;

        }
    }
}
