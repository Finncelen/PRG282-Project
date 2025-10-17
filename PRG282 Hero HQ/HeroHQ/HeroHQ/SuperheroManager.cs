using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HeroHQ
{
    internal class SuperheroManager
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


        //Read data from superheroes.txt
        public static List<SuperHero> ReadFromFile(string filePath)
        {
            List<SuperHero> heroes = new List<SuperHero>();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 6
                            && int.TryParse(parts[0], out var id)
                            && int.TryParse(parts[2], out var age)
                            && int.TryParse(parts[3], out var exam))
                        {
                            heroes.Add(new SuperHero(id, parts[1], age, exam, parts[4], parts[5]));
                        }
                    }

                }
            }

            return heroes;
        }

        //Write data to superheroes.txt
        public static void WriteToFile(string filePath, List<SuperHero> heroes)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var hero in heroes)
                {
                    writer.WriteLine($"{hero.HeroID},{hero.HeroName},{hero.Age},{hero.ExamScore},{hero.Rank},{hero.ThreatLevel}");
                }
            }
        }

        //Add a new hero (with validation)
        public static void AddHero(List<SuperHero> heroes, SuperHero newHero)
        {
            if (string.IsNullOrWhiteSpace(newHero.HeroName))
                throw new Exception("Hero name cannot be empty.");
            if (newHero.ExamScore < 0 || newHero.ExamScore > 100)
                throw new Exception("Exam score must be between 0 and 100.");

            newHero.HeroID = heroes.Count > 0 ? heroes.Max(h => h.HeroID) + 1 : 1;
            heroes.Add(newHero);

            //Immediately save the updated list to file
            SaveData();
        }

        //Update existing hero
        public static void UpdateHero(List<SuperHero> heroes, SuperHero updatedHero)
        {
            var hero = heroes.FirstOrDefault(h => h.HeroID == updatedHero.HeroID);
            if (hero != null)
            {
                hero.HeroName = updatedHero.HeroName;
                hero.Age = updatedHero.Age;
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

        //Write summary.txt (from Member 3’s summary)
        public static void WriteSummary(string filePath, string summaryReport)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(summaryReport);
            }
        }
    }
}

