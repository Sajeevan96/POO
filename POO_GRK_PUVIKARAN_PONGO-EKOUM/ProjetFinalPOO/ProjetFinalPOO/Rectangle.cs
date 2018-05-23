using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinalPOO
{
    class Rectangle : Element, ITranslatable, IRotable
    {
        //Attributs
        private Point point;
        private string largeur;
        private string hauteur;

        //Constructeur
        public Rectangle(string idElement, string x, string y, string largeur, string hauteur, string R, string G, string B, string ordre, string codeTransformation):
            base(idElement, R, G, B, ordre, codeTransformation)
        {
            point = new Point(x, y);
            this.largeur = largeur;
            this.hauteur = hauteur;
        }

        //Propriétés
        public string X
        {
            get { return point.X; }
        }
        public string Y
        {
            get { return point.Y; }
        }
        public string Largeur
        {
            get { return largeur; }
        }
        public string Hauteur
        {
            get { return hauteur; }
        }

        //Méthodes 
        public void Translation(string dx, string dy)
        {
            string code = " translate(" + dx + "," + dy + ")";
            CodeTransformation += code;
        }

        public void Rotation(string alpha, string cx, string cy)
        {
            string code = " rotate(" + alpha + " " + cx + "," + cy + ")";
            CodeTransformation += code;
        }

        public override string ToString()
        {
            return "x=" + point.X + " y=" + point.Y + " width="+ largeur + " height=" + hauteur + base.ToString();
        }
    }
}
