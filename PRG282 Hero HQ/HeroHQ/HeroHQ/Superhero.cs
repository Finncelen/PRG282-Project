using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HeroHQ
{
    internal class SuperHero
    {
        public int HeroID { get; set; }
        public string HeroName { get; set; }
        public int Age { get; set; }
        public int ExamScore { get; set; }
        public string Rank { get; set; } 
        public string ThreatLevel { get; set; } 

        public SuperHero(int id, string name, int age, int examScore, string rank, string threatlevel)
        {
            HeroID = id; 
            HeroName = name;
            Age = age;
            ExamScore = examScore;
            Rank = rank;
            ThreatLevel = threatlevel;
        }

        // Convert to file format
        public string ToFileString()
        {
            return $"{HeroID}|{HeroName}|{Age}|{ExamScore}|{Rank}|{ThreatLevel}";
        }
    }
}
