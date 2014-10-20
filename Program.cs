using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLinClass
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xDoc = XDocument.Load("family.xml");
            #region blah 
            Console.WriteLine(
                xDoc.Descendants("family")
                .ElementAt(1)
                .Element("mother")
                .Value);
            Console.WriteLine(
                xDoc.Descendants("family")
                .FirstOrDefault()
                .Attribute("name").Value);

            //print all daughters
            IEnumerable<XElement> daughters = xDoc.Descendants("family")
                .ElementAt(1)
                .Descendants("daughter");
            
            foreach (XElement daughter in daughters)
            {
                Console.WriteLine(daughter.Value);
            }
            #endregion

            XElement family = new XElement("family");
            family.Add(new XAttribute("name", "Nielsen"));
            family.Add(new XElement("father", "Niels"));
            Console.WriteLine(family);

            xDoc.Descendants("family").LastOrDefault().AddAfterSelf(family);
            Console.WriteLine("new xdoc:");
            Console.WriteLine(xDoc);

            xDoc.Save("family.xml");
        }
    }
}
