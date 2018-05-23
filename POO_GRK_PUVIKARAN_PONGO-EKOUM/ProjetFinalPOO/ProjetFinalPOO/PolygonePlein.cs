using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinalPOO
{
    class PolygonePlein : Element, IRotable
    {
        //Attributs
        private string points;

        //Constructeur
        public PolygonePlein(string idElement, string points, string R, string G, string B, string ordre, string codeTransformation):
            base(idElement, R, G, B, ordre, codeTransformation)
        {
            this.points = points;
        }

        //Propriétés
        public string Points
        {
            get { return points; }
        }

        //Méthodes
        public void Rotation(string alpha, string cx, string cy)
        {
            string code = "rotate(" + alpha + " " + cx + "," + cy + ")";
            CodeTransformation += code;
        }

        public override string ToString()
        {
            return "points=" + points + base.ToString();
        }
    }
}
