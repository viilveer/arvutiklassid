using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Arvutiklassid.src
{
    class QueryProvider
    {
        public static IEnumerable<XElement> GetResult(XElement element, string type, string keyword)
        {
            IEnumerable<XElement> result;
            switch (type)
            {
                case "ARVUTIDKLASSIS":
                    result = from arvutiklass in element.Elements("arvutiklass")
                        where arvutiklass.Attribute("ruuminumber").Value.Contains(keyword)
                        select arvutiklass;
                    break;
                case "ARVUTID":
                case "KLASSID":
                    result = from arvutiklass in element.Elements("arvutiklass")
                        select arvutiklass;
                    break;
                default:
                    throw new Exception("Unknown type!");
            }
            return result;
        }

    }
}
