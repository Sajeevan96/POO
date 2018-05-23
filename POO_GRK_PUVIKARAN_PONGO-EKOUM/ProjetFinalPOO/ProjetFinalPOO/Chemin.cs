using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinalPOO
{
    class Chemin : Element, IRotable //Classe héritant d'Element et utilisant l'interface IRotable
    {
        //Attributs
        private string path;

        //Constructeur 
        public Chemin(string idElement, string path, string R, string G, string B, string ordre, string codeTransformation):
            base(idElement, R, G, B, ordre, codeTransformation)
        {
            this.path = path;
        }

        //Propriété: Accesseur
        public string Path
        {
            get { return path; }
        }

        //Méthodes
        public void Rotation(string alpha, string cx, string cy) 
            //Ajoute la fonction rotate dans le code svg indirectement par le biais de l'attribut codeTransformation
        {
            string code = "rotate(" + alpha + "," + cx + "," + cy + ")";
            CodeTransformation += code;
        }

        public override string ToString()
        {
            return "d=" + path + base.ToString();
        }
    }
}
