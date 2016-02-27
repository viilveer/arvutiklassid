using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Arvutiklassid.src;

namespace Arvutiklassid
{
    class Program
    {
        static void Main(string[] args)
        {
            InputDecider inputDecider = new InputDecider();

            XElement xelement = XElement.Load("..\\..\\arvutid.xml");

            Console.WriteLine("Kirjuta KLASSID, kui soovid näha klassiruume, ARVUTID, et kuvada kõiki arvuteid või ARVUTIDKLASSIS, et otsida klassi järgi arvuteid.");
            inputDecider.Type = Console.ReadLine();
            inputDecider.Validate("type");

            if (inputDecider.AskKeyword())
            {
                Console.WriteLine("Kirjuta otsisõna.");
                inputDecider.Keyword = Console.ReadLine();
                inputDecider.Validate("keyword");
            }

            IEnumerable<XElement> result = src.QueryProvider.GetResult(xelement, inputDecider.Type, inputDecider.Keyword);
            List<src.ClassRoom> classRooms = src.ClassRoomFactory.CreateFromXmlElementList(result);

            OutputDecider outputDecider = new OutputDecider();

            foreach (string line in outputDecider.getOutput(inputDecider.Type, classRooms))
            {
                Console.WriteLine(line);
            }
          
        }
    }
}
