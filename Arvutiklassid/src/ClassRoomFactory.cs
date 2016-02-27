using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Arvutiklassid.src
{
    class ClassRoomFactory
    {
        public static List<ClassRoom> CreateFromXmlElementList(IEnumerable<XElement> document)
        {
            List<ClassRoom> classRooms = new List<ClassRoom> { };

           // IEnumerable<XElement> retseptid = document;
            foreach (XElement classRoomElement in document)
            {
                ClassRoom classRoom = new ClassRoom();
                classRoom.SetName(classRoomElement.Attribute("ruuminumber").Value);
                classRoom.Floor = classRoomElement.Attribute("korrus").Value;
                foreach (XElement arvuti in classRoomElement.Elements())
                {
                    Computer computer = new Computer
                    {
                        OperatingSystem = arvuti.Attribute("os").Value,
                        Comment = arvuti.Attribute("kommentaar").Value,
                        Brand = arvuti.Attribute("bränd").Value
                    };
                    classRoom.AddComputer(computer);
                }
                classRooms.Add(classRoom);
            }

            return classRooms;
        }
    }
}
