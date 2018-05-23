using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace ProjetFinalPOO
{
    class Dessin : IFormatable
    {
        //Attributs
        private List<Element> liste;
        private string lien; //Le lien du document .csv

        //Constructeur 
        public Dessin(string lien)
        {
            this.lien = lien;
            this.liste = new List<Element>(); //Instanciation d'une nouvelle liste de type Elements
        }

        //Méthodes
        public bool Test(string[] tableau, int valeur)
        {
            bool resultat = true;
            if(tableau.Length != valeur)
            {
                resultat = false;
            }
            for(int i = 0; i < tableau.Length; i++)
            {
                if(tableau[i] == "")
                {
                    resultat = false;
                }
            }
            return resultat;
        }

        public List<Element> LireCsv()  //Lecture du fichier csv 
        {
            StreamReader monStreamReader = null;
            try
            {
                monStreamReader = new StreamReader(@lien);
            
                // Lire la première ligne
                string ligne = monStreamReader.ReadLine();
            
                // Tant que la ligne lue n'est pas null
                while (ligne != null)
                {
                
                    //Découper selon le séparateur ';', résultat: un tableau.
                    string[] temp = ligne.Split(';');

                    //Cas du cercle
                    if (temp[0] == "Cercle" && Test(temp, 9))
                    {
                        liste.Add(new Cercle(temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], temp[7], temp[8], ""));
                    }
                    //Cas de l'ellipse
                    else if (temp[0] == "Ellipse" && Test(temp, 10))
                    {
                        liste.Add(new Ellipse(temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], temp[7], temp[8], temp[9], ""));
                    }
                    //Cas du rectangle
                    else if (temp[0] == "Rectangle" && Test(temp, 10))
                    {
                        liste.Add(new Rectangle(temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], temp[7], temp[8], temp[9], ""));
                    }
                    //Cas du Polygone plein
                    else if (temp[0] == "Polygone" && Test(temp, 7))
                    {
                        liste.Add(new PolygonePlein(temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], ""));
                    }
                    //Cas du chemin
                    else if (temp[0] == "Chemin" && Test(temp, 7))
                    {
                        liste.Add(new Chemin(temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], ""));
                    }
                    //Cas du texte
                    else if (temp[0] == "Texte" && Test(temp, 9))
                    {
                        liste.Add(new Texte(temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], temp[7], temp[8], ""));
                    }
                    //Cas d'une translation
                    else if (temp[0] == "Translation" && Test(temp, 4))
                    {
                        foreach (Element element in liste)
                        {
                            if (temp[1] == element.IdElement && element is ITranslatable)
                            {
                                (element as ITranslatable).Translation(temp[2], temp[3]);
                                break;
                            }
                        }
                    }
                    //Cas d'une rotation
                    else if (temp[0] == "Rotation" && Test(temp, 5))
                    {
                        foreach (Element element in liste)
                        {
                            if (temp[1] == element.IdElement && element is IRotable)
                            {
                                (element as IRotable).Rotation(temp[2], temp[3], temp[4]);
                                break;
                            }
                        }
                    }
                    ligne = monStreamReader.ReadLine();
                }
                monStreamReader.Close();
                liste.Sort();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Le fichier " + lien + " que vous avez tenté d'ouvrir n'existe pas");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur est survenue lors de l'ouverture du fichier" + lien + ":" + ex.Message);
            }
            finally
            {
                if (monStreamReader != null)
                {
                    monStreamReader.Close();
                }
            }
            return liste;
        }

        public void Svg() //Création du fichier svg 
        {
            XmlDocument docXml = new XmlDocument();
            docXml.CreateXmlDeclaration("1.0", "UTF-8", "no");

            XmlElement racine = docXml.CreateElement("svg");
            docXml.AppendChild(racine);
            XmlAttribute attribut1 = docXml.CreateAttribute("xmlns");
            attribut1.InnerText = @"http://www.w3.org/2000/svg";
            racine.SetAttributeNode(attribut1);
            XmlAttribute attribut2 = docXml.CreateAttribute("version");
            attribut2.InnerText = "1.1";
            racine.SetAttributeNode(attribut2);
           
                foreach (Element element in liste)
                {
                    if (element is Chemin)
                    {
                        XmlElement Balise = docXml.CreateElement("path");
                        XmlAttribute d = docXml.CreateAttribute("d");
                        d.InnerText = (element as Chemin).Path;
                        Balise.SetAttributeNode(d);

                        XmlAttribute style = docXml.CreateAttribute("style");
                        style.InnerText = "fill:rgb(" + element._R + "," + element._G + "," + element._B + ")";
                        Balise.SetAttributeNode(style);

                        if (element.CodeTransformation != "")
                        {
                            XmlAttribute transform = docXml.CreateAttribute("transform");
                            transform.InnerText = element.CodeTransformation;
                            Balise.SetAttributeNode(transform);
                        }
                        racine.AppendChild(Balise);
                    }
                    else if (element is Cercle)
                    {
                        XmlElement Balise = docXml.CreateElement("circle");
                        XmlAttribute cx = docXml.CreateAttribute("cx");
                        cx.InnerText = (element as Cercle).Cx;
                        Balise.SetAttributeNode(cx);

                        XmlAttribute cy = docXml.CreateAttribute("cy");
                        cy.InnerText = (element as Cercle).Cy;
                        Balise.SetAttributeNode(cy);

                        XmlAttribute r = docXml.CreateAttribute("r");
                        r.InnerText = (element as Cercle).R;
                        Balise.SetAttributeNode(r);

                        XmlAttribute style = docXml.CreateAttribute("style");
                        style.InnerText = "fill:rgb(" + element._R + "," + element._G + "," + element._B + ")";
                        Balise.SetAttributeNode(style);

                        if (element.CodeTransformation != "")
                        {
                            XmlAttribute transform = docXml.CreateAttribute("transform");
                            transform.InnerText = element.CodeTransformation;
                            Balise.SetAttributeNode(transform);
                        }

                        racine.AppendChild(Balise);
                    }
                    else if (element is Rectangle)
                    {
                        XmlElement Balise = docXml.CreateElement("rect");

                        XmlAttribute x = docXml.CreateAttribute("x");
                        x.InnerText = (element as Rectangle).X;
                        Balise.SetAttributeNode(x);

                        XmlAttribute y = docXml.CreateAttribute("y");
                        y.InnerText = (element as Rectangle).Y;
                        Balise.SetAttributeNode(y);

                        XmlAttribute width = docXml.CreateAttribute("width");
                        width.InnerText = (element as Rectangle).Largeur;
                        Balise.SetAttributeNode(width);

                        XmlAttribute height = docXml.CreateAttribute("height");
                        height.InnerText = (element as Rectangle).Hauteur;
                        Balise.SetAttributeNode(height);

                        XmlAttribute style = docXml.CreateAttribute("style");
                        style.InnerText = "fill:rgb(" + element._R + "," + element._G + "," + element._B + ")";
                        Balise.SetAttributeNode(style);

                        if (element.CodeTransformation != "")
                        {
                            XmlAttribute transform = docXml.CreateAttribute("transform");
                            transform.InnerText = element.CodeTransformation;
                            Balise.SetAttributeNode(transform);
                        }

                        racine.AppendChild(Balise);
                    }
                    else if (element is PolygonePlein)
                    {
                        XmlElement Balise = docXml.CreateElement("polygon");

                        XmlAttribute points = docXml.CreateAttribute("points");
                        points.InnerText = (element as PolygonePlein).Points;
                        Balise.SetAttributeNode(points);

                        XmlAttribute style = docXml.CreateAttribute("style");
                        style.InnerText = "fill:rgb(" + element._R + "," + element._G + "," + element._B + ")";
                        Balise.SetAttributeNode(style);

                        if (element.CodeTransformation != "")
                        {
                            XmlAttribute transform = docXml.CreateAttribute("transform");
                            transform.InnerText = element.CodeTransformation;
                            Balise.SetAttributeNode(transform);
                        }

                        racine.AppendChild(Balise);
                    }
                    else if (element is Texte)
                    {
                        XmlElement Balise = docXml.CreateElement("text");
                        Balise.InnerText = (element as Texte).Contenu;

                        XmlAttribute x = docXml.CreateAttribute("x");
                        x.InnerText = (element as Texte).X;
                        Balise.SetAttributeNode(x);

                        XmlAttribute y = docXml.CreateAttribute("y");
                        y.InnerText = (element as Texte).Y;
                        Balise.SetAttributeNode(y);

                        XmlAttribute style = docXml.CreateAttribute("style");
                        style.InnerText = "fill:rgb(" + element._R + "," + element._G + "," + element._B + ")";
                        Balise.SetAttributeNode(style);

                        if (element.CodeTransformation != "")
                        {
                            XmlAttribute transform = docXml.CreateAttribute("transform");
                            transform.InnerText = element.CodeTransformation;
                            Balise.SetAttributeNode(transform);
                        }

                        racine.AppendChild(Balise);
                    }

                    else//(element is Ellipse)
                    {
                        XmlElement Balise = docXml.CreateElement("ellipse");

                        XmlAttribute cx = docXml.CreateAttribute("cx");
                        cx.InnerText = (element as Ellipse).Cx;
                        Balise.SetAttributeNode(cx);

                        XmlAttribute cy = docXml.CreateAttribute("cy");
                        cy.InnerText = (element as Ellipse).Cy;
                        Balise.SetAttributeNode(cy);

                        XmlAttribute rx = docXml.CreateAttribute("rx");
                        rx.InnerText = (element as Ellipse).Rx;
                        Balise.SetAttributeNode(rx);

                        XmlAttribute ry = docXml.CreateAttribute("ry");
                        ry.InnerText = (element as Ellipse).Ry;
                        Balise.SetAttributeNode(ry);

                        XmlAttribute style = docXml.CreateAttribute("style");
                        style.InnerText = "fill:rgb(" + element._R + "," + element._G + "," + element._B + ")";
                        Balise.SetAttributeNode(style);

                        if (element.CodeTransformation != "")
                        {
                            XmlAttribute transform = docXml.CreateAttribute("transform");
                            transform.InnerText = element.CodeTransformation;
                            Balise.SetAttributeNode(transform);
                        }
                        racine.AppendChild(Balise);
                    }
                }
            // enregistrement du document SVG   ==> à retrouver dans le dossier bin\Debug de Visual Studio
            docXml.Save(lien + ".svg");
        }
    }
}
