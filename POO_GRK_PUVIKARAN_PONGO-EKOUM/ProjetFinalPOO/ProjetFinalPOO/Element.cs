using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetFinalPOO
{
    abstract class Element : IComparable<Element>
    {
        //Attributs
        private string idElement;
        private string R;
        private string G;
        private string B;
        private string ordre;
        private string codeTransformation;

        //Constructeur
        public Element(string idElement, string R, string G, string B, string ordre, string codeTransformation)
        {
            this.idElement = idElement;
            this.R = R;
            this.G = G;
            this.B = B;
            this.ordre = ordre;
            this.codeTransformation = codeTransformation;
        }

        //Propriétés
        public string IdElement
        {
            get { return idElement; }
        }
        public string _R
        {
            get { return R; }
        }

        public string _G
        {
            get { return G; }
        }
        public string _B
        {
            get { return B; }
        }

        public string CodeTransformation
        {
            get { return codeTransformation; }
            set { codeTransformation = value; }
        }

        //Méthodes
        public override string ToString()
        {
            return " style=fill:rgb(" + R + "," + G + "," + B + ")";
        }
        public int CompareTo(Element other)
        {      
            return ((Convert.ToInt32(this.ordre)).CompareTo(Convert.ToInt32(other.ordre)));  
        }
    }
}
