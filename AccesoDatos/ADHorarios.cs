using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
namespace AccesoDatos
{
    public class ADHorarios
    {
       // string mensaje;

        string cadConexion;

        public ADHorarios(string cadConexion)
        {
            this.cadConexion = cadConexion;
        }

        public List<EAula> listarAulas(string condicion = "")
        {
            List<EAula> listaAulas = new List<EAula>();
            string sentecia = " SELECT idAula, codigoAula, tipoAula FROM Aulas WHERE borradoAula =0";
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
                        EAula eAula = new EAula();

                        eAula.IdAula = Convert.ToInt32(registro[0]);

                        eAula.CodigoAula = registro.GetString(1);

                        eAula.TipoAula = registro.GetString(2);

                        listaAulas.Add(eAula);
                    }
                }
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un error en la selección de aulas");
            }
            finally
            {
                connection.Dispose();
            }

            return listaAulas;
        }
        public List<EAula> listarAulasOrdenada(string condicion = "")
        {
            List<EAula> listaAulas = new List<EAula>();
            string sentecia = " SELECT idAula, codigoAula, tipoAula FROM Aulas WHERE borradoAula =0";
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
                        EAula eAula = new EAula();

                        eAula.IdAula = Convert.ToInt32(registro[0]);

                        eAula.CodigoAula = registro.GetString(1);

                        eAula.TipoAula = registro.GetString(2);

                        listaAulas.Add(eAula);
                    }
                }
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un error en la selección de aulas");
            }
            finally
            {
                connection.Dispose();
            }

            return listaAulas;
        }
        public List<EMateria> listarMaterias(string condicion = "")
        {
            List<EMateria> listaMaterias = new List<EMateria>();
            string sentecia = " SELECT idMateria, nombreMateria FROM materias ";
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
                throw new Exception("Ha ocurrido un error en la selección de aulas");
            }
            finally
            {
                connection.Dispose();
            }

            return listaMaterias;
        }

        public List<EMateria> listarMateriasOrdenada(string condicion = "")
        {
            List<EMateria> listaMaterias = new List<EMateria>();
            string sentecia = " SELECT idMateria, nombreMateria FROM materias";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentecia = string.Format("{0} {1}", sentecia, condicion);

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
                throw new Exception("Ha ocurrido un error en la selección de aulas");
            }
            finally
            {
                connection.Dispose();
            }

            return listaMaterias;
        }
       
        public EHorario devolverHorario(string condicion)
        {
            EHorario horario = new EHorario();
            EMateria materia = new EMateria();
            EProfesor eProfesor = new EProfesor();
            EAula eAula = new EAula();
            string sentencia = $"SELECT M.nombreMateria, P.nombreProfe, P.apellido1Profe, h.dia, " +
                              $" h.horaInicio, h.horaFin, a.codigoAula FROM Horarios H JOIN Materias " +
                              $"M ON H.idMateria = M.idMateria JOIN Profesores P ON H.idProfesor = " +
                              $"P.idProfesor JOIN Aulas A ON A.idAula = H.idAula JOIN Grupos G ON G.idGrupo =" +
                              $" H.idGrupo " + $" WHERE {condicion}";

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

                    materia.NombreMateria = sqlDataReader.GetString(0);

                    eProfesor.Nombre = sqlDataReader.GetString(1);

                    eProfesor.Apellido1 = sqlDataReader.GetString(2);

                    eAula.CodigoAula = sqlDataReader.GetString(6);
                    horario.EAula = eAula;
                    horario.EMateria = materia;
                    horario.EProfesor = eProfesor;
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
            DataTable tabla = new DataTable();
            string sentecia = "SELECT idProfesor, idMateria, nombreProfe, apellido1Profe FROM Profesores";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentecia = string.Format("{0} where {1}", sentecia, condicion);
            }
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(sentecia, connection);
                dataAdapter.Fill(tabla);

                listaProfesores = (from DataRow registro in tabla.Rows
                             select new EProfesor()
                             {
                                 Id = Convert.ToInt32(registro[0]),
                                 Nombre = registro[2].ToString(),
                                 Apellido1 = registro[3].ToString(),
                                 EMateria = new EMateria()
                                 {
                                     IdMateria = Convert.ToInt32(registro[1])
                                 }
                             }).ToList();
                connection.Close();
                dataAdapter.Dispose();
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

        public int insertarHorario(EHorario horario)
        {
            int resultado = -1;
            string sentencia = " INSERT INTO Horarios(idMateria,idProfesor,dia,horaInicio,horaFin,idAula,idGrupo)" +
                " VALUES(@idMateria, @idProfesor, @dia, @horaInicio, @horaFin, @idAula, @idGrupo) ";
            SqlConnection conexion = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@idMateria", horario.EMateria.IdMateria);
            comando.Parameters.AddWithValue("@idProfesor", horario.EProfesor.Id);
            comando.Parameters.AddWithValue("@dia", horario.Dia);
            comando.Parameters.AddWithValue("@horaInicio", horario.HoraInicio);
            comando.Parameters.AddWithValue("@horaFin", horario.HoraFinal);
            comando.Parameters.AddWithValue("@idAula", horario.EAula.IdAula);
            comando.Parameters.AddWithValue("@idGrupo", horario.EGrupo.IdGrupo);

            try
            {
                conexion.Open();
                resultado = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw new Exception("Error al insertar una lección");
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return resultado;

        }

        public int obtenerLeccionesProfesor(EProfesor profesor)
        {
            int resultado = 0;
            SqlCommand comandoSQL = new SqlCommand();
            SqlConnection conexionSQL = new SqlConnection(cadConexion);

            comandoSQL.CommandText = "SELECT COUNT(DATEDIFF(minute, h.horaInicio, h.horaFin)/40) FROM Profesores p INNER JOIN dbo.Horarios h ON p.idProfesor = h.idProfesor WHERE P.idProfesor= @idProfesor HAVING COUNT(DATEDIFF(minute, h.horaInicio, h.horaFin)/40) <  40;";
            comandoSQL.Parameters.AddWithValue("@idProfesor", profesor.Id);
            comandoSQL.Connection = conexionSQL;
            try
            {
                conexionSQL.Open();
                resultado = (int)comandoSQL.ExecuteScalar();

                conexionSQL.Close();
            }
            catch (Exception)
            {
                conexionSQL.Close();
                throw new Exception("Se ha presentado un error en el conteo de la materias del profesor");
            }
            finally
            {
                comandoSQL.Dispose();
                conexionSQL.Dispose();
            }
            return resultado;
        }
        

    }
}
