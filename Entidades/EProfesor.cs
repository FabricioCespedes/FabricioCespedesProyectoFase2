using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EProfesor:EPersona
    {
        private EMateria eMateria;
        private string usuario;
        private string contrasena;

        /// <summary>
        /// Constructor vacio de la clase profesor. No recibe nada por parámetro.
        /// </summary>
        public EProfesor()
        {
        }

        /// <summary>
        /// Constructor de la clase profesor. Recibe por parámetro int id, string identificion, string nombre, string apellido1, string apellido2, DateTime fechaIngreso, int borrado, string telefono, string telefono2, string correo, string direccion, int idDistrito, EMateria eMateria) : base(id, identificion, nombre, apellido1, apellido2, fechaIngreso, borrado, telefono, telefono2, correo, direccion, idDistrito.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="identificion"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido1"></param>
        /// <param name="apellido2"></param>
        /// <param name="fechaIngreso"></param>
        /// <param name="borrado"></param>
        /// <param name="telefono"></param>
        /// <param name="telefono2"></param>
        /// <param name="correo"></param>
        /// <param name="direccion"></param>
        /// <param name="idDistrito"></param>
        /// <param name="eMateria"></param>
        public EProfesor(int id, string identificion, string nombre, string apellido1, string apellido2, DateTime fechaIngreso, int borrado, string telefono, string telefono2, string correo, string direccion, int idDistrito, EMateria eMateria, string usuario, string contrasena) : base(id, identificion, nombre, apellido1, apellido2, fechaIngreso, borrado, telefono, telefono2, correo, direccion, idDistrito)
        {
            this.eMateria = eMateria;
            this.usuario = usuario;
            this.contrasena = contrasena;
        }

        public override string ToString()
        {
            return "Id:" + Identificion + "- Nombre:" + Nombre + " " + Apellido1 ;
        }

        public EMateria EMateria { get => eMateria; set => eMateria = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
    }
}
