using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace linq3
{
    class Program
    {
        class Room
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public List<int> Navigable { get; set; }
            public List<int> Pickable { get; set; }
        }


        static void Main(string[] args)
        {
            // read the file from disk
            string path = @"C:\Users\jbrugger\repo\linq\linq3\house.json";
            string jsonSrc = System.IO.File.ReadAllText(path);

            // create a JObject
            JObject db = JObject.Parse(jsonSrc);

            // query with LINQ!!!
            var roomQuery =
                from set in db["cave"]["rooms"]
                select new Room
                {
                    Id = (int)set["id"],
                    Name = (string)set["name"],
                    Description = (string)set["description"],
                    Navigable = set["navigable"].Select(c => (int)c).ToList(),
                    Pickable = set["pickable"].Select(c => (int)c).ToList()
                };

            foreach(Room room in roomQuery)
            {
                Console.WriteLine(room.Name);
            }

            Console.ReadKey(true);

        }
    }
}
