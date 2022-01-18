using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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
            string sentecia = "SELECT idMateria, nombreMateria FROM Materias ";
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
        /// Método que retorna una lista de estudiantes desde la base de datos. Recibe un string opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista estudiantes</returns>
        public List<EEstudiante> listarEstudiantes(string condicion = "")
        {
            List<EEstudiante> listaEstudiantes = new List<EEstudiante>();
            string sentecia = " SELECT  e.estudianteID, (e.nombreEstu + ' ' + e.apellido1Estu) AS Nombre, e.idEstudiante AS id FROM GruposEstudiantes ge JOIN grupos g on g.idGrupo = ge.idGrupo JOIN Estudiantes e on e.idEstudiante = ge.idEstudiante WHERE e.borradoEstu = 0 AND e.estadoEstu = 'ACT' ";
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

                        eEstudiante.Id = Convert.ToInt32(registro[2]);

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
            string sentecia = " SELECT DISTINCT g.idGrupo , g.grado , g.seccion FROM Horarios h join Grupos g ON h.idGrupo = g.idGrupo "; //
            if (!string.IsNullOrEmpty(condicion))
                sentecia = string.Format("{0} where {1}", sentecia, condicion);
            else
            {
                sentecia = string.Format("{0}  {1} ", sentecia);
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

        public int eliminar(string condicion)
        {
            int result = -1;
            string sentecia = $"Delete from Calificaciones Where {condicion}";

            SqlConnection conexion = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand(sentecia, conexion);
            try
            {
                conexion.Open();
                result = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                result = -1;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

            return result;
        }

        public int insertar(ESolicitud solicitud)
        {
            int resultado = -1;
            string sentencia = " INSERT INTO Solicitudes(idProfesor,idEstudiante,idCicloLectivo,idMateria,notaNueva,notaVieja,justificacion) " +
                $"VALUES ({solicitud.EProfesor.Id}, {solicitud.EEstudiante.Id},{solicitud.ECicloLectivo.IdCicloLectivo},{solicitud.EMateria.IdMateria},{solicitud.NotaNueva},{solicitud.NotaVieja}, '{solicitud.Justificacion}')";
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
                throw new Exception("Error al insertar solicitud");
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return resultado;
        }

        public DataSet listarSolicitudes(string condicion = "")
        {            
            DataSet tablaSolicitudes = new DataSet();

            string sentecia = "SELECT s.idSolicitud AS idSolicitud, p.nombreProfe + ' ' + p.apellido1Profe AS profe," +
                " e.nombreEstu + ' ' + e.apellido1Estu AS estudiante, cl.trimestre as trimestre," +
                " cl.anio as anio, m.nombreMateria as materia, s.notaNueva as notaNueva, s.notaVieja " +
                "as notaVieja, s.justificacion as justi  FROM Solicitudes s INNER JOIN Profesores p  ON " +
                "s.idProfesor = p.idProfesor INNER JOIN Estudiantes e  ON e.idEstudiante = s.idEstudiante " +
                "INNER JOIN CiclosLectivos cl on cl.idCicloLectivo = s.idCicloLectivo INNER JOIN Materias " +
                "m ON  m.idMateria = s.idMateria  ";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentecia = string.Format("{0} where {1}", sentecia, condicion);

            }
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(sentecia, connection);
                dataAdapter.Fill(tablaSolicitudes);
                connection.Close();
                dataAdapter.Dispose();

            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un error en la selección de las solicitudes");
            }
            finally
            {
                connection.Dispose();
            }

            return tablaSolicitudes;
        }

        public int modificar(string observacion, string idUsuario, string idSolicitud)
        {
            int resultado = -1;
            string sentencia;
            SqlConnection sqlConnection = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand();

            sentencia = $"UPDATE Solicitudes SET observacion = '{observacion}', estado = 'INA' , idUsuario = {idUsuario} WHERE idSolicitud = {idSolicitud}";
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

        public ESolicitud devolverSolicitud(string condicion)
        {
            ESolicitud solicitud = new ESolicitud();
            string sentencia = $"select idProfesor,idEstudiante,idCicloLectivo,idMateria,notaNueva, notaVieja,justificacion from Solicitudes" + $" WHERE {condicion}";
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
                    EProfesor eProfesor = new EProfesor();
                    eProfesor.Id = sqlDataReader.GetInt32(0);
                    EEstudiante eEstudiante = new EEstudiante();
                    eEstudiante.Id = sqlDataReader.GetInt32(1);
                    ECicloLectivo eCicloLectivo = new ECicloLectivo();
                    eCicloLectivo.IdCicloLectivo= sqlDataReader.GetInt32(2);
                    EMateria eMateria = new EMateria();
                    eMateria.IdMateria = sqlDataReader.GetInt32(3);
                    solicitud.NotaNueva = sqlDataReader.GetInt32(4);
                    solicitud.NotaVieja = sqlDataReader.GetInt32(5);    
                    solicitud.Justificacion = sqlDataReader.GetString(6);
                    solicitud.EProfesor = eProfesor;
                    solicitud.EMateria = eMateria;
                    solicitud.ECicloLectivo = eCicloLectivo;
                    solicitud.EEstudiante = eEstudiante;

                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un problema en la seleccion de una solicitud");
            }
            finally { connection.Dispose(); comando.Dispose(); }

            return solicitud;
        }

    }

}
