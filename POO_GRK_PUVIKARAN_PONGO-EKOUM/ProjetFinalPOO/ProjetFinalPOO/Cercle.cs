using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinalPOO
{
    class Cercle : Element, ITranslatable //Classe héritant d'Element et utilisant l'interface ITranslatable 
    {
        //Attributs
        private Point centre;
        private string r;

        //Constructeur
        public Cercle(string idElement, string cx, string cy, string r, string R, string G, string B, string ordre, string codeTransformation):
            base(idElement, R, G, B, ordre, codeTransformation)
        {
            centre = new Point(cx, cy);

            this.r = r; 
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

        public string R
        {
            get { return r; }
        }

        //Méthodes
        public void Translation(string dx, string dy)
            //Ajoute la fonction translate dans le code svg par le biais de l'attribut codeTransformation
        {
            string code = "translate(" + dx + "," + dy + ")";
            CodeTransformation += code;
        }

        public override string ToString() //Redéfinition de la méthode ToString()
        {
            return "cx=" + centre.X + " cy=" + centre.Y + " r=" + r + base.ToString();
        }

    }
}
