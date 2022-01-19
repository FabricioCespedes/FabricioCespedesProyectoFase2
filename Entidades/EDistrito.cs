using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EDistrito
    {
        private int id;
        private string name;
        private ECanton canton;
        public EDistrito()
        {
        }

        public EDistrito(int id, string name, ECanton canton)
        {
            this.id = id;
            this.name = name;
            this.canton = canton;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public ECanton Canton { get => canton; set => canton = value; }
    }
}
