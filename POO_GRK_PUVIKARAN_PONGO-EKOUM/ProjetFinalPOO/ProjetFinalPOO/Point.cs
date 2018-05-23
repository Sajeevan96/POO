using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinalPOO
{
    class Point
    {
        //Attributs
        private string x;
        private string y;

        //Constructeur 
        public Point(string x, string y)
        {
            this.x = x;
            this.y = y;
        }

        //Propriétés
        public string X
        {
            get { return x; }
        }
        public string Y
        {
            get { return y; }
        }
    }
}
