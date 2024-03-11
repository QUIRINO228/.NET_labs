using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Crime
    {
        public int Id { get; set; } 
        public DateTime DateCommitted { get; set; }
        public DateTime DateSolved { get; set; }
        public string Type { get; set; }
        public string Severity { get; set; }
        public List<Suspect> Suspects { get; set; }
        public List<Weapon> WeaponsUsed { get; set; }
        public PoliceStation PoliceStation { get; set; }

        public Crime()
        {
            Suspects = new List<Suspect>();
            WeaponsUsed = new List<Weapon>();
        }
    }
}