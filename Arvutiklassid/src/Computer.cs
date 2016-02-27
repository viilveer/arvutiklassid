using System;

namespace Arvutiklassid.src
{
    class Computer
    {
        public string OperatingSystem;

        public string Comment;

        public string Brand;

        public override string ToString()
        {
            return Comment.Length > 0 ? string.Concat("Arvuti (", Brand, " - ", OperatingSystem, " (", Comment, "))") : string.Concat("Arvuti (", Brand, " - ", OperatingSystem, ")");
        }
    }
}
