using System.Collections.Generic;
using System.IO;

namespace SOLID.Models
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        // just a counter for total # of entries
        private static int count = 0;

        public void AddEntry(string text) => entries.Add($"{++count}: {text}");

        public void RemoveEntry(int index) => entries.RemoveAt(index);

        public void Save(string filename, bool overwrite = false) => File.WriteAllText(filename, ToString());
    }

    public class PersistenceManager
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }
}