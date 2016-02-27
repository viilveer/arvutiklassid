using System.Collections.Generic;

namespace Arvutiklassid.src
{
    class ClassRoom
    {
        private string _name;

        public string Floor { get; set; }


        private List<Computer> _computers = new List<Computer> { };

        public void SetName(string name)
        {
            _name = name;
        }

        public void AddComputer(Computer computer)
        {
            this._computers.Add(computer);
        }

        public string GetName()
        {
            return _name;
        }

        public List<Computer> GetComputers()
        {
            return _computers;
        }
    }
}
