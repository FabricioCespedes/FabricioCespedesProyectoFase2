using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ECanton
    {
        private int id;
        private string name;
        private EProvincia provincia;

        public ECanton()
        {
        }

        public ECanton(int id, string name, EProvincia provincia)
        {
            this.id = id;
            this.name = name;
            this.provincia = provincia;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public EProvincia Provincia { get => provincia; set => provincia = value; }
    }
}
