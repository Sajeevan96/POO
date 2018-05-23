using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinalPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            string lien = "exemple1.csv";
            
            Dessin dessin1 = new Dessin(lien);
            List<Element> liste1 = dessin1.LireCsv();
            /*for (int i = 0; i < liste1.Count(); i++)
            {
                Console.WriteLine(liste1[i]);
            }*/
            dessin1.Svg();

            lien = "exemple2.csv";
            Dessin dessin2 = new Dessin(lien);
            List<Element> liste2 = dessin2.LireCsv();
            dessin2.Svg();

            lien = "exemple3.csv";
            Dessin dessin3 = new Dessin(lien);
            List<Element> liste3 = dessin3.LireCsv();
            dessin3.Svg();

            lien = "exemple4.csv";
            Dessin dessin4 = new Dessin(lien);
            List<Element> liste4 = dessin4.LireCsv();
            dessin4.Svg();

            lien = "ExempleTout.csv";
            Dessin dessin5 = new Dessin(lien);
            List<Element> liste5 = dessin5.LireCsv();
            dessin5.Svg();

            lien = "MM.csv";
            Dessin dessin6 = new Dessin(lien);
            List<Element> liste6 = dessin6.LireCsv();
            dessin6.Svg();

            Console.WriteLine("Projet Final POO");
            Console.Write("Sajeevan PUVIKARAN et Jacques Olivier PONGO EKOUM");
            Console.Write(" Groupe K");
            Console.ReadLine();
        }
    }
}
