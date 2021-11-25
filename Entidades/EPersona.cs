    using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EPersona
    {
        private int id; // 
        private string identificion; // 
        private string nombre;
        private string apellido1;
        private string apellido2;
        private DateTime fechaIngreso;
        private int borrado;
        private string telefono;
        private string telefono2;
        private string correo;
        private string direccion;// 
        private int idDistrito;//

        public int Id { get => id; set => id = value; }
        public string Identificion { get => identificion; set => identificion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido1; set => apellido1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public int Borrado { get => borrado; set => borrado = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Telefono2 { get => telefono2; set => telefono2 = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int IdDistrito { get => idDistrito; set => idDistrito = value; }

        /// <summary>
        /// Constructor normal de la super clase persona. Recibe por parámetro int id, string identificion, string nombre, string apellido1, string apellido2, DateTime fechaIngreso, int borrado, string telefono, string telefono2, string correo, string direccion, int idDistrito.
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
        public EPersona(int id, string identificion, string nombre, string apellido1, string apellido2, DateTime fechaIngreso, int borrado, string telefono, string telefono2, string correo, string direccion, int idDistrito)
        {
            this.id = id;
            this.identificion = identificion;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.fechaIngreso = fechaIngreso;
            this.borrado = borrado;
            this.telefono = telefono;
            this.telefono2 = telefono2;
            this.correo = correo;
            this.direccion = direccion;
            this.idDistrito = idDistrito;
        }

        /// <summary>
        /// Constructor vacio de la clase persona.
        /// </summary>
        public EPersona()
        {
        }
    }
}
