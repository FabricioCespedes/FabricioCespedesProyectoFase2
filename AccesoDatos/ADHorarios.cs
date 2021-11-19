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
            string sentecia = " SELECT idAula, codigoAula, tipoAula, borradoAula FROM Aulas";
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
                        EAula eAula = new EAula();

                        eAula.IdAula = Convert.ToInt32(registro.GetString(0));

                        eAula.CodigoAula = registro.GetString(1);

                        eAula.TipoAula = registro.GetString(2);

                        eAula.BorradoAula = registro.GetString(3);

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

                        materia.IdMateria = Convert.ToInt32(registro.GetString(0));

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

        public List<EGrupo> listarGrupos(string condicion = "")
        {
            List<EGrupo> listaGrupos = new List<EGrupo>();
            string sentecia = " SELECT idGrupo,grado,seccion FROM Grupos ";
            if (!string.IsNullOrEmpty(condicion))     
                sentecia = string.Format("{0} where {1}", sentecia, condicion);       
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
                        grupo.IdGrupo = Convert.ToInt32(registro.GetString(0));
                        grupo.Grado = Convert.ToInt32(registro.GetString(1));
                        grupo.Seccion = Convert.ToInt32(registro.GetString(2));
                        listaGrupos.Add(grupo);
                    }
                }
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

        public void actualizarDataSet(DataSet dataSet)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadConexion);
                connection.Open();
                SqlBulkCopy sqlBulkCopy = default(SqlBulkCopy);
                sqlBulkCopy = new SqlBulkCopy(connection);
                sqlBulkCopy.DestinationTableName = "Horarios";
                sqlBulkCopy.WriteToServer(dataSet.Tables[0]);
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo crear horario");
            }
        }

        
    }
}
