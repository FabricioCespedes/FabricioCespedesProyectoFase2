using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AccesoDatos
{
    public class ADCalificaciones
    {
        string cadConexion;

        public ADCalificaciones(string cadConexion)
        {
            this.cadConexion = cadConexion;
        }

        public List<EMateria> listarMaterias(string condicion = "")
        {
            List<EMateria> listaMaterias = new List<EMateria>();
            string sentecia = "SELECT DISTINCT  m.idMateria, m.nombreMateria FROM Horarios H JOIN Materias M ON H.idMateria = M.idMateria JOIN Grupos G ON g.idGrupo = H.idGrupo ";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentecia = string.Format("{0} where {1}", sentecia, condicion);

            }
            SqlConnection connection = new SqlConnection(cadConexion);

            try
            {
                connection.Open();
                SqlCommand comando = new SqlCommand(sentecia, connection);
                SqlDataReader registro = comando.ExecuteReader();

                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        EMateria materia = new EMateria();
                        materia.IdMateria = Convert.ToInt32(registro[0]);
                        materia.NombreMateria = registro.GetString(1);

                        listaMaterias.Add(materia);
                    }
                }
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un error en la selección de las materias");
            }
            finally
            {
                connection.Dispose();
            }

            return listaMaterias;
        }

        public List<EEstudiante> listarEstudiantes(string condicion = "")
        {
            List<EEstudiante> listaEstudiantes = new List<EEstudiante>();
            string sentecia = " SELECT  e.estudianteID, e.nombreEstu, e.apellido1Estu, e.apellido2Estu, e.idEstudiante  FROM GruposEstudiantes ge JOIN grupos g on g.idGrupo = ge.idGrupo JOIN Estudiantes e on e.idEstudiante = ge.idEstudiante WHERE e.borradoEstu = 0 AND e.estadoEstu = 'ACT' ";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentecia = string.Format("{0}  {1}", sentecia, condicion);

            }
            SqlConnection connection = new SqlConnection(cadConexion);

            try
            {
                connection.Open();
                SqlCommand comando = new SqlCommand(sentecia, connection);
                SqlDataReader registro = comando.ExecuteReader();

                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        EEstudiante eEstudiante = new EEstudiante();

                        eEstudiante.Identificion = registro.GetString(0);

                        eEstudiante.Nombre = registro.GetString(1);

                        eEstudiante.Apellido1 = registro.GetString(2);

                        eEstudiante.Id = Convert.ToInt32(registro[4]);

                        listaEstudiantes.Add(eEstudiante);
                    }
                }
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un error en la selección de estudiantes");
            }
            finally
            {
                connection.Dispose();
            }

            return listaEstudiantes;
        }

        public List<EGrupo> listarGrupos(string condicion = "")
        {
            List<EGrupo> listaGrupos = new List<EGrupo>();
            string sentecia = " SElect * from grupos "; //
            string sentecia2 = "  order by idGrupo desc "; //
            if (!string.IsNullOrEmpty(condicion))
                sentecia = string.Format("{0} where {1} {2}", sentecia, condicion, sentecia2);
            else
            {
                sentecia = string.Format("{0}  {1} ", sentecia, sentecia2);
            }
            SqlConnection connection = new SqlConnection(cadConexion);
            try
            {
                connection.Open();
                SqlCommand comando = new SqlCommand(sentecia, connection);
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        EGrupo grupo = new EGrupo();
                        grupo.IdGrupo = Convert.ToInt32(registro[0]);
                        grupo.Grado = Convert.ToInt32(registro[1]);
                        grupo.Seccion = Convert.ToInt32(registro[2]);
                        listaGrupos.Add(grupo);
                    }
                }
                connection.Close();
                registro.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un error en la selección de grupos");
            }
            finally
            {
                connection.Dispose();
            }
            return listaGrupos;
        }

        public List<EProfesor> listarProfesores(string condicion = "")
        {
            List<EProfesor> listaProfesores = new List<EProfesor>();
            string sentecia = "SELECt idProfesor,profesorId, nombreProfe, apellido1Profe from profesores ";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentecia = string.Format("{0} WHERE {1}", sentecia, condicion);

            }
            SqlConnection connection = new SqlConnection(cadConexion);

            try
            {
                connection.Open();
                SqlCommand comando = new SqlCommand(sentecia, connection);
                SqlDataReader registro = comando.ExecuteReader();

                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        EProfesor eProfesor = new EProfesor();

                        eProfesor.Identificion = registro.GetString(1);

                        eProfesor.Nombre = registro.GetString(2);

                        eProfesor.Apellido1 = registro.GetString(3);

                        eProfesor.Id = Convert.ToInt32(registro[0]);

                        listaProfesores.Add(eProfesor);
                    }
                }
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

            return listaProfesores;
        }

        public int modificar(ECalificacion eCalificacion)
        {
            int resultado = -1;
            string sentencia;
            SqlConnection sqlConnection = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand();

            sentencia = $"UPDATE Calificaciones set notaFinal = '{eCalificacion.NotaFinal}' Where idEstudiante = {eCalificacion.EEstudiante.Id} and idMateria = {eCalificacion.EMateria.IdMateria}" +
                $" and  idCicloLectivo = '{eCalificacion.ECicloLectivo.IdCicloLectivo}'";
            comando.Connection = sqlConnection;
            comando.CommandText = sentencia;

            try
            {
                sqlConnection.Open();
                resultado = comando.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                sqlConnection.Close();
                throw new Exception("Error al actualizar");
            }
            finally
            {
                sqlConnection.Dispose();
                comando.Dispose();
            }

            return resultado;
        }

        public int insertarCalificacion(ECalificacion calificacion)
        {
            int resultado = -1;
            string sentencia = "INSERT INTO Calificaciones(idEstudiante, idMateria, idCicloLectivo, notaFinal, idProfesor) " +
                $"VALUES ({calificacion.EEstudiante.Id}, {calificacion.EMateria.IdMateria},{calificacion.ECicloLectivo.IdCicloLectivo},{calificacion.NotaFinal}, {calificacion.EProfesor.Id})";
            SqlConnection conexion = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand(sentencia, conexion);
            try
            {
                conexion.Open();
                resultado = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw new Exception("Error al insertar");
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return resultado;
        }

        public ECicloLectivo devolverCiclo(string condicion)
        {
            ECicloLectivo eCicloLectivo = new ECicloLectivo();
            string sentencia = $"select idCicloLectivo, estado, trimestre , anio from CiclosLectivos " + $" WHERE {condicion}";
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand(sentencia, connection);
            SqlDataReader sqlDataReader;
            try
            {
                connection.Open();
                sqlDataReader = comando.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    eCicloLectivo.IdCicloLectivo = Convert.ToInt32(sqlDataReader[0]);
                    eCicloLectivo.Estado = Convert.ToInt32(sqlDataReader[1]);
                    eCicloLectivo.Trimestre = Convert.ToInt32(sqlDataReader[2]);
                    eCicloLectivo.Anio = Convert.ToInt32(sqlDataReader[3]);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un problema en la seleccion del ciclo lectivo");
            }
            finally { connection.Dispose(); comando.Dispose(); }

            return eCicloLectivo;
        }

        public ECalificacion devolverCalificacion(string condicion)
        {
            ECalificacion eCalificacion = new ECalificacion();
            string sentencia = $"select notaFinal from Calificaciones"  + $" WHERE {condicion}";
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand(sentencia, connection);
            SqlDataReader sqlDataReader;
            eCalificacion.NotaFinal = -1;
            try
            {
                connection.Open();
                sqlDataReader = comando.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    eCalificacion.NotaFinal = Convert.ToInt32(sqlDataReader[0]);

                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un problema en la seleccion de una calificacion");
            }
            finally { connection.Dispose(); comando.Dispose(); }

            return eCalificacion;
        }

    }

}
