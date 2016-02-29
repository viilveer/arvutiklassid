using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Arvutiklassid.src;

namespace Arvutiklassid
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xDocument = XmlLoader.SafeLoadXDocument("..\\..\\arvutid.xml", "..\\..\\arvutid.xsd");
            InputDecider inputDecider = new InputDecider();

            Console.WriteLine("Kirjuta KLASSID, kui soovid näha klassiruume, ARVUTID, et kuvada kõiki arvuteid või ARVUTIDKLASSIS, et otsida klassi järgi arvuteid.");
            inputDecider.Type = Console.ReadLine();
            inputDecider.Validate("type");

            if (inputDecider.AskKeyword())
            {
                Console.WriteLine("Kirjuta otsisõna.");
                inputDecider.Keyword = Console.ReadLine();
                inputDecider.Validate("keyword");
            }

            IEnumerable<XElement> result = src.QueryProvider.GetResult(xDocument, inputDecider.Type, inputDecider.Keyword);
            List<src.ClassRoom> classRooms = src.ClassRoomFactory.CreateFromXmlElementList(result);

            OutputDecider outputDecider = new OutputDecider();

            foreach (string line in outputDecider.GetOutput(inputDecider.Type, classRooms))
            {
                Console.WriteLine(line);
            }
          
        }
    }
}
