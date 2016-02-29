using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvutiklassid.src
{
    internal class OutputDecider
    {
        public string[] GetOutput(string type, List<ClassRoom> classRooms)
        {
            var output = new List<string>();
            switch (type)
            {
                case "ARVUTIDKLASSIS":
                case "ARVUTID":
                    foreach (src.ClassRoom classRoom in classRooms)
                    {
                        output.Add(String.Concat("Klass: ", classRoom.GetName()));
                        foreach (Computer computer in classRoom.GetComputers())
                        {
                            output.Add(computer.ToString());
                        }

                        output.Add("----------------------------------------");
                    }
                    break;
                case "KLASSID":
                    foreach (src.ClassRoom classRoom in classRooms)
                    {
                        output.Add(String.Concat("Klass: ", classRoom.GetName()));

                        output.Add("----------------------------------------");
                    }
                    break;
                default:
                    throw new Exception("Unknown type");
                
            }
            return output.ToArray();
        }
    }
}
