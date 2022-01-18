using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AccesoDatos
{
    public class ADInicio
    {
        string cadConexion;

        /// <summary>
        /// Constructor vacio de la capa de acceso a datos de inicio, recibe la conexion.
        /// </summary>
        /// <param name="cadConexion"></param>
        public ADInicio(string cadConexion)
        {
            this.cadConexion = cadConexion;
        }


        public int login(string clave, string usuario)
        {
            object obEscalar;
            int resul = -1;
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection(cadConexion);
            comando.CommandText = $"Select idUsuario from Usuarios Where usuario = '{usuario}' and clave = '{clave}'";
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                obEscalar = comando.ExecuteScalar();

                if (obEscalar != null)
                resul = (Int32)comando.ExecuteScalar();

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw new Exception("Error buscando usuario");
            }
            //4
            finally
            {
                comando.Dispose();
                conexion.Dispose();
            }

            return resul;
        }

        public EProfesor obtenerProfesor(string condicion = "")
        {
            EProfesor eProfesor = new EProfesor();
            EMateria materia = new EMateria();
            string sentecia = "SELECT idProfesor, idMateria, nombreProfe, apellido1Profe FROM Profesores";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentecia = string.Format("{0} where {1}", sentecia, condicion);
            }
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand(sentecia, connection);
            SqlDataReader sqlDataReader;
            try
            {
                connection.Open();
                sqlDataReader = comando.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();//
                    eProfesor.Id = Convert.ToInt32(sqlDataReader[0]);
                    materia.IdMateria = Convert.ToInt32(sqlDataReader[1]);
                    eProfesor.EMateria = materia;
                    eProfesor.Nombre = sqlDataReader.GetString(2);
                    eProfesor.Apellido1 = sqlDataReader.GetString(3);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un error en la selección de profesores");
            }
            finally
            {
                connection.Dispose();
            }

            return eProfesor;
        }
    }
}
