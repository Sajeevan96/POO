using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinalPOO
{
    class Ellipse : Element, ITranslatable, IRotable
    {
        //Attributs
        private Point centre;
        private Point rayon;

        //Constructeur
        public Ellipse(string idElement, string cx, string cy, string rx, string ry, string R, string G, string B, string ordre, string codeTransformation):
            base(idElement, R, G, B, ordre, codeTransformation)
        {
            centre = new Point(cx, cy);
            rayon = new Point(rx, ry);
        }

        //Propriétés
        public string Cx
        {
            get { return centre.X; }
        }

        public string Cy
        {
            get { return centre.Y; }
        }

        public string Rx
        {
            get { return rayon.X; }
        }
        
        public string Ry
        {

            get { return rayon.Y; }
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
            return "cx=" + centre.X + " cy=" + centre.Y + " rx=" + rayon.X + " ry=" + rayon.Y + base.ToString();
        }

    }
}
