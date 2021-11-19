using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AccesoDatos
{
    public class ADHorarios
    {
        string mensaje;

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


            SqlConnection connection = new SqlConnection(cadConexion);
            connection.Open();
            SqlBulkCopy sqlBulkCopy = default(SqlBulkCopy);
            sqlBulkCopy = new SqlBulkCopy(connection);

            sqlBulkCopy.DestinationTableName = "Horarios";
            sqlBulkCopy.WriteToServer(dataSet.Tables[0]);
            connection.Close();


        }

        
    }
}
