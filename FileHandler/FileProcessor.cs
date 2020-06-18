using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileHandler
{
    public class FileReader
    {
        public List<string> ReadCsvFile(string filename)
        {
            using (StreamReader file = new StreamReader(filename, Encoding.UTF8))
            {
                string row;
                List<string> CsvContents = new List<string>();
                while ((row = file.ReadLine()) != null)
                {
                    CsvContents.Add(row);
                }
                return CsvContents;
            }
        }
        public void WriteTextFile(string filename, List<string> dataFile)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {

                foreach (var s in dataFile)
                {
                    sw.WriteLine(s);
                }
            }
        }

    }
}
