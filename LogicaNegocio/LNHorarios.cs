using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LogicaNegocio
{
    public class LNHorarios
    {
        string cadConexion;

        public LNHorarios(string cadConexion)
        {
            this.cadConexion = cadConexion;
        }

        public void obtenerTablaHorarios(string condicion = "")
        {          
            ADHorarios aDHorarios = new ADHorarios(cadConexion);
   

            try
            {
                DataSet setHorarios = aDHorarios.obtenerTablaHorarios();
                DataTable Horarios = setHorarios.Tables[0];
                Horarios.Rows.Clear();
                
                DataRow row = Horarios.NewRow();

                row["idMateria"] = 1;
                row["idProfesor"] = 1;
                row["dia"] = "L";
                row["horaInicio"] = "07:00";
                row["horaFin"] = "07:00";
                row["idAula"] = 1;
                row["idGrupo"] = 1;
                Horarios.Rows.Add(row);
                aDHorarios.actualizarDataSet(setHorarios);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
