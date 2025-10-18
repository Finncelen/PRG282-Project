using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HeroHQ
{
    internal class SuperHeroManager
    {

        //Main memory data store
        private static List<SuperHero> heroes = new List<SuperHero>();

        //Constant file paths 
        private const string SuperHeroFile = "superheroes.txt";
        private const string SummaryFile = "summary.txt";

        //Loads data from the file into the list
        public static void LoadData()
        {
            heroes = ReadFromFile(SuperHeroFile);
        }

        //Saves current data back into the file
        public static void SaveData()
        {
            WriteToFile(SuperHeroFile, heroes);
        }

        //Set Rank and Threat
        private static void SetRankAndThreat(SuperHero hero)
        {
            // clamp just in case
            int score = Math.Max(0, Math.Min(100, hero.ExamScore));

            if (score >= 81) { hero.Rank = "S"; hero.ThreatLevel = "Finals Week"; }
            else if (score >= 61) { hero.Rank = "A"; hero.ThreatLevel = "Midterm Madness"; }
            else if (score >= 41) { hero.Rank = "B"; hero.ThreatLevel = "Group Project Gone Wrong"; }
            else { hero.Rank = "C"; hero.ThreatLevel = "Pop Quiz"; }
        }

        //Read data from superheroes.txt
        public static List<SuperHero> ReadFromFile(string filePath)
        {
            List<SuperHero> hero = new List<SuperHero>();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 7
                            && int.TryParse(parts[0], out var id)
                            && int.TryParse(parts[2], out var age)
                            && int.TryParse(parts[4], out var exam))
                        {
                            hero.Add(new SuperHero(id, parts[1], age, parts[3] ,exam, parts[5], parts[6]));
                        }
                    }

                }
            }

            return hero;
        }

        //Write data to superheroes.txt
        public static void WriteToFile(string filePath, List<SuperHero> heroes)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var hero in heroes)
                {
                    writer.WriteLine($"{hero.HeroID},{hero.HeroName},{hero.Age},{hero.Superpower},{hero.ExamScore},{hero.Rank},{hero.ThreatLevel}");
                }
            }
        }

        //Add a new hero (with validation)
        public static void AddHero(List<SuperHero> heroes, SuperHero newHero)
        {
            if (string.IsNullOrWhiteSpace(newHero.HeroName))
                throw new Exception("Hero name cannot be empty.");
            if (newHero.Age < 0)
                throw new Exception("Age must be 0 or greater.");
            if (newHero.ExamScore < 0 || newHero.ExamScore > 100)
                throw new Exception("Exam score must be between 0 and 100.");

            newHero.HeroID = heroes.Count > 0 ? heroes.Max(h => h.HeroID) + 1 : 1;
            SetRankAndThreat(newHero);

            heroes.Add(newHero);

            //Immediately save the updated list to file
            SaveData();
        }

        //Update existing hero
        public static void UpdateHero(List<SuperHero> heroes, SuperHero updatedHero)
        {
            var hero = heroes.FirstOrDefault(h => h.HeroID == updatedHero.HeroID);
            SetRankAndThreat(updatedHero);

            if (hero != null)
            {
                hero.HeroName = updatedHero.HeroName;
                hero.Age = updatedHero.Age;
                hero.Superpower = updatedHero.Superpower;
                hero.ExamScore = updatedHero.ExamScore;
                hero.Rank = updatedHero.Rank;
                hero.ThreatLevel = updatedHero.ThreatLevel;

                //Save updated data
                SaveData();
            }
        }

        //Delete hero by ID
        public static void DeleteHero(List<SuperHero> heroes, int id)
        {
            var hero = heroes.FirstOrDefault(h => h.HeroID == id);
            if (hero != null)
            {
                heroes.Remove(hero);
                SaveData();
            }
        }

        //Get all heroes (for displaying data)
        public static List<SuperHero> GetAllHeroes()
        {
            return heroes;
        }

        //Summary Generation
        public static void GenerateSummaryReport()
        {
            // Make sure any missing/old ranks are refreshed from score
            foreach (var hero in heroes) 
                if (string.IsNullOrWhiteSpace(hero.Rank) || string.IsNullOrWhiteSpace(hero.ThreatLevel))
                    SetRankAndThreat(hero);

            int total = heroes.Count;
            double avgAge = heroes.Count == 0 ? 0 : heroes.Average(h => (double)h.Age);
            double avgScore = heroes.Count == 0 ? 0 : heroes.Average(h => (double)h.ExamScore);

            int countS = heroes.Count(hero=> hero.Rank == "S");
            int countA = heroes.Count(hero => hero.Rank == "A");
            int countB = heroes.Count(hero => hero.Rank == "B");
            int countC = heroes.Count(hero => hero.Rank == "C");

            string report =
                $@"HERO HQ - Summary Report
-------------------------
Total heroes: {total}
Average age: {avgAge:0.00}
Average exam score: {avgScore:0.00}

Heroes per rank:
    S: {countS}
    A: {countA}
    B: {countB}
    C: {countC}";

            // Use method persist
            WriteSummary(SummaryFile, report);
        }

        //Write summary.txt
        public static void WriteSummary(string filePath, string summaryReport)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(summaryReport);
            }
        }
    }
}

