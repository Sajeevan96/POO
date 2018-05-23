using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinalPOO
{
    class Texte : Element, IRotable, ITranslatable
    {
        //Attributs
        private string x;
        private string y;
        private string contenu; 

        //Constructeur
        public Texte(string idElement, string x, string y, string contenu, string R, string G, string B, string ordre, string codeTransformation):
            base(idElement, R, G, B, ordre, codeTransformation)
        {
            this.x = x;
            this.y = y;
            this.contenu = contenu;
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

        public string Contenu
        {
            get { return contenu; }
        }

        //Méthodes
        public void Translation(string dx, string dy)
        {
            string code = "translate(" + dx + "," + dy + ")";
            CodeTransformation += code;
        }

        public void Rotation(string alpha, string cx, string cy)
        {
            string code = "rotate(" + alpha + "," + cx + "," + cy + ")";
            CodeTransformation += code;
        }

        public override string ToString()
        {
            return "x=" + x + " y=" + y + base.ToString();
        }
    }
}
