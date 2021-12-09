using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EUsuario:EPersona
    {
        string usuario;
        string clave;
        string tipoUsuario;
        public EUsuario()
        {
        }

        public EUsuario(int id, string identificion, string nombre, string apellido1, string apellido2, DateTime fechaIngreso, int borrado, string telefono, string telefono2, string correo, string direccion, int idDistrito, string usuario, string clave, string tipoUsuario) : base(id, identificion, nombre, apellido1, apellido2, fechaIngreso, borrado, telefono, telefono2, correo, direccion, idDistrito)
        {
            this.usuario = usuario;
            this.clave = clave;
            this.tipoUsuario = tipoUsuario;
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public string Clave { get => clave; set => clave = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
    }
}
