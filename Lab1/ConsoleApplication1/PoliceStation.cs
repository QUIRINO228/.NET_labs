using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class PoliceStation
    {
        public List<Crime> Crimes { get; set; }

        public PoliceStation()
        {
            Crimes = new List<Crime>();
        }
    }
}