using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EEstudiante:EPersona
    {
        private string carnet;
        private int ultimoAnioAprobado;
        private string seccion;
        private string estadoEstu;

        public override string ToString()
        {
            if (Apellido2 != "null")
            {
                return Identificion + "  " + Nombre + " " + Apellido1 + " " + Apellido2;
            }
            else
            {
                return Identificion + "  " + Nombre + " " + Apellido1;

            }
        }

        public string Carnet { get => carnet; set => carnet = value; }
        public int UltimoAnioAprobado { get => ultimoAnioAprobado; set => ultimoAnioAprobado = value; }
        public string Seccion { get => seccion; set => seccion = value; }
        public string EstadoEstu { get => estadoEstu; set => estadoEstu = value; }

        public EEstudiante()
        {
        }

        public EEstudiante(int id, string identificion, string nombre, string apellido1, string apellido2, DateTime fechaIngreso, int borrado, string telefono, string telefono2, string correo, string direccion, int idDistrito, string carnet, int ultimoAnioAprobado, string seccion, string estadoEstu) : base(id, identificion, nombre, apellido1, apellido2, fechaIngreso, borrado, telefono, telefono2, correo, direccion, idDistrito)
        {
            this.carnet = carnet;
            this.ultimoAnioAprobado = ultimoAnioAprobado;
            this.seccion = seccion;
            this.estadoEstu = estadoEstu;
        }
    }
}
