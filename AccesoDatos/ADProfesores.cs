using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
namespace AccesoDatos
{
    public class ADProfesores
    {
        string cadConexion;

        /// <summary>
        /// Constructor vacio de la capa de acceso a datos de profesores, recibe la conexion.
        /// </summary>
        /// <param name="cadConexion"></param>
        public ADProfesores(string cadConexion)
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
            string sentecia = "SELECT * FROM Materias";
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
        /// Método que obtiene la lista de provincias desde la base de datos. Recibe un condicion opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista de materias</returns>
        public List<EProvincia> listarProvincias(string condicion = "")
        {
            List<EProvincia> listaProvincia = new List<EProvincia>();
            string sentecia = "SELECT * FROM Provincias";
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
                        EProvincia provincia = new EProvincia();
                        provincia.Id = Convert.ToInt32(registro[0]);
                        provincia.Nombre = registro.GetString(1);

                        listaProvincia.Add(provincia);
                    }
                }
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un error en la selección de las provincias");
            }
            finally
            {
                connection.Dispose();
            }

            return listaProvincia;
        }

        /// <summary>
        /// Método que obtiene la lista de distritos desde la base de datos. Recibe un condicion opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista de materias</returns>
        public List<EDistrito> listarDistritos(string condicion = "")
        {
            List<EDistrito> listaDistrito = new List<EDistrito>();
            string sentecia = "SELECT * FROM Distritos";
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
                        EDistrito distrito = new EDistrito();
                        distrito.Id = Convert.ToInt32(registro[0]);
                        distrito.Name = registro.GetString(1);

                        listaDistrito.Add(distrito);
                    }
                }
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un error en la selección de los distritos");
            }
            finally
            {
                connection.Dispose();
            }

            return listaDistrito;
        }

        /// <summary>
        /// Método que obtiene la lista de distritos desde la base de datos. Recibe un condicion opcional.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista de materias</returns>
        public List<ECanton> listarCanton(string condicion = "")
        {
            List<ECanton> listaCantones = new List<ECanton>();
            string sentecia = "SELECT * FROM Cantones";
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
                        ECanton canton = new ECanton();
                        canton.Id = Convert.ToInt32(registro[0]);
                        canton.Name = registro.GetString(1);

                        listaCantones.Add(canton);
                    }
                }
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Ha ocurrido un error en la selección de los cantones");
            }
            finally
            {
                connection.Dispose();
            }

            return listaCantones;
        }

        /// <summary>
        /// Método que actualiza una asistencia en la base de datos, recibe una asistencia.
        /// </summary>
        /// <param name="asistencia"></param>
        /// <returns>Un entero</returns>
        public int modificar(EProfesor profesor)
        {
            int resultado = -1;
            string sentencia;
            SqlConnection sqlConnection = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand();

            sentencia = $"UPDATE Profesores set profesorID = '{profesor.Identificion}', nombreProfe = '{profesor.Nombre}', apellido1Profe = '{profesor.Apellido1}', apellido2Profe= '{profesor.Apellido2}',telefonoProfe= '{profesor.Telefono}',correoProfe = '{profesor.Correo}',direccionProfe= '{profesor.Direccion}',idDistritoProfe = {profesor.IdDistrito},idMateria = {profesor.EMateria.IdMateria}, nombreUsuario = '{profesor.Usuario}', contrasenia = '{profesor.Usuario}' ";
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
        public int insertar(EProfesor profesor)
        {
            int resultado = -1;
            string sentencia = "INSERT INTO Profesores(profesorID,nombreProfe,apellido1Profe,telefonoProfe,correoProfe,direccionProfe,idDistritoProfe,idMateria,nombreUsuario,contrasenia) VALUES" +
                $" ('{profesor.Identificion}','{profesor.Nombre}','{profesor.Apellido1}','{profesor.Apellido2}, '{profesor.Telefono}', '{profesor.Correo}', '{profesor.IdDistrito}', '{profesor.EMateria.IdMateria}', '{profesor.Usuario}', '{profesor.Contrasena}') ";
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

        public int eliminar(string condicion)
        {
            int result = -1;
            string sentecia = $"Delete from Profesores Where {condicion}";

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

        /// <summary>
        /// Método que retorna una lista de profesores desde la base de datos, recibe un string opcional que seria la condicion del select.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns></returns>
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

        public DataSet listarProfesores(string condicion = "", bool bandera = true)
        {
            DataSet tablaSolicitudes = new DataSet();

            string sentecia = "SELECT p.idProfesor AS id, p.idProfesor AS iden , p.nombreProfe + ' ' + p.apellido1Profe As nombre,p.telefonoProfe as tel, p.correoProfe correo,p.fechaIngresoProfe as fecha, p.direccionProfe as direccion,p.nombreProfe as usuario, p.contrasenia as contrasena,m.nombreMateria as materia ,d.nombreDistrito as distrito,c.nombreCanton as canton, prov.nombreProvincia as provincia FROM Profesores p JOIN Materias m on m.idMateria = p.idMateria JOIN Distritos d on d.idDistrito = p.idDistritoProfe JOIN Cantones c on c.idCanton = d.idCanton JOIN Provincias prov on prov.idProvincia = c.idProvincia ";
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
    }
}
