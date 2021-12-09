using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AccesoDatos
{
    public class ADAsistencia
    {
        string cadConexion;

        /// <summary>
        /// Constructor vacio de la capa de acceso a datos de asistencia, recibe la conexion.
        /// </summary>
        /// <param name="cadConexion"></param>
        public ADAsistencia(string cadConexion)
        {
            this.cadConexion = cadConexion;
        }

        /// <summary>
        /// Método que obtiene la lista de materias desde la base de datos. Recibe un condicion opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista de materias</returns>
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

        /// <summary>
        /// Método que retorna una lista de horarios desde la base de dadtos. Recibe un string opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns></returns>
        public List<string> listarHorario(string condicion = "")
        {
            List<string> listaHorario = new List<string>();
            string sentecia = "SELECT DISTINCT CONVERT(varchar(5), h.horaInicio) , CONVERT(varchar(5), h.horaFin)  FROM Horarios H JOIN Materias M ON H.idMateria = M.idMateria JOIN Grupos G ON g.idGrupo = H.idGrupo ";
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
                        EHorario horario = new EHorario();
                        horario.HoraInicio = registro[0].ToString();
                        horario.HoraFinal = registro[1].ToString();
                        listaHorario.Add(horario.HoraInicio + " a " + horario.HoraFinal);
                    }
                }
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un error en la selección de las horarios");
            }
            finally
            {
                connection.Dispose();
            }

            return listaHorario;
        }

        /// <summary>
        /// Método que retorna una lista de estudiantes desde la base de datos. Recibe un string opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista estudiantes</returns>
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

        /// <summary>
        /// Método que retorna una lista de grupo desde la base de datos. Recibe un string opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista de grupos</returns>
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

        /// <summary>
        /// Método que retorna un dataset con la tabla horarios desde la base de datos, recibe un string opcional
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>dataset de tabla horarios</returns>
        public DataSet obtenerTablaHorarios(string condicion = "")
        {
            DataSet tablaHorarios = new DataSet();
            string sentecia = " SELECT * FROM Horarios ";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentecia = string.Format("{0} where {1}", sentecia, condicion);

            }
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(sentecia, connection);
                dataAdapter.Fill(tablaHorarios);
                connection.Close();
                dataAdapter.Dispose();
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un error en la selección de horarios");
            }
            finally
            {
                connection.Dispose();
            }

            return tablaHorarios;
        }

        /// <summary>
        /// Método que retorna una lección desde la base de datos, recibe un string opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Una lección</returns>
        public EHorario devolverHorario(string condicion)
        {
            EHorario horario = new EHorario();
            string sentencia = $"SELECT idHorario From horarios" + $" WHERE {condicion}";

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

                    horario.IdHorario = Convert.ToInt32(sqlDataReader[0]);
                }

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un problema en la seleccion de una leccion");
            }
            finally { connection.Dispose(); comando.Dispose(); }

            return horario;
        }

        /// <summary>
        /// Método que retorna una asistencia desde la base de datos, recibe un string opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Una asistencia</returns>
        public EAsistencia devolverAsistencia(string condicion)
        {
            EAsistencia eAsistencia = new EAsistencia();

            string sentencia = $"SELECT estado from asistencias " + $" WHERE {condicion}";

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

                    eAsistencia.Estado = Convert.ToString(sqlDataReader[0]);
                }

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un problema en la seleccion de una asistencia");
            }
            finally { connection.Dispose(); comando.Dispose(); }

            return eAsistencia;
        }

        /// <summary>
        /// Método que actualiza una asistencia en la base de datos, recibe una asistencia.
        /// </summary>
        /// <param name="asistencia"></param>
        /// <returns>Un entero</returns>
        public int modificar(EAsistencia asistencia)
        {
            int resultado = -1;
            string sentencia;
            SqlConnection sqlConnection = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand();

            sentencia = $"UPDATE Asistencias set estado = '{asistencia.Estado}' Where idEstudiante = {asistencia.EEstudiante.Id} and idHorario = {asistencia.EHorario.IdHorario} and fecha = '{asistencia.Fecha}'";
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

        /// <summary>
        /// Métedo que inserta una asistencia en la base de datos, recibe una asistencia.
        /// </summary>
        /// <param name="asistencia"></param>
        /// <returns>Un entero</returns>
        public int insertarAsistencia(EAsistencia asistencia)
        {
            int resultado = -1;
            string sentencia = "INSERT INTO Asistencias (idHorario,idEstudiante,estado, fecha) VALUES" +
                $" ({asistencia.EHorario.IdHorario},{asistencia.EEstudiante.Id},'{asistencia.Estado}', '{asistencia.Fecha}') ";
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
    }
}
