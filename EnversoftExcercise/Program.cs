using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using FileHandler;
using ProcessInputData;

namespace EnverSoftExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputfile = @"C:\Files\Input\InputFile.csv";
            string outputNames = @"C:\Files\Output\namesList.txt";
            string outputAdresses = @"C:\Files\Output\addressList.txt";

            FileReader processFile = new FileReader();
            ProcessInputFile process = new ProcessInputFile();
            var fileContents = processFile.ReadCsvFile(inputfile);
            
            var lists = process.ProcessInputString(fileContents);
            var nameList = lists.Item1;
            var addressList = lists.Item2;

            processFile.WriteTextFile(outputNames, nameList);
            processFile.WriteTextFile(outputAdresses, addressList);

            Console.Read();
        }
        
    }
}
