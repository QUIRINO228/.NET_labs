using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Suspect
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string InvolvementType { get; set; }
        public List<Crime> Crimes { get; set; } 

        public Suspect()
        {
            Crimes = new List<Crime>();
        }
    }
}