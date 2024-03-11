using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Owner { get; set; }
        public List<Crime> Crimes { get; set; }  
        public Weapon()
        {
            Crimes = new List<Crime>();
        }
    }
}