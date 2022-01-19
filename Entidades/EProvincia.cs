using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EProvincia
    {
        public EProvincia()
        {
        }

        private int id;
        private string nombre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public EProvincia(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
