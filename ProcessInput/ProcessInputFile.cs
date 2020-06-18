using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace ProcessInputData
{
    public class ProcessInputFile
    {
        private readonly List<string> Names = new List<string>();
        private readonly List<string> Addresses = new List<string>();
        public Tuple<List<string>, List<string>> ProcessInputString(List<string> rows)
        {          
            foreach (string row in rows)
            {
                var column = row.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Names.Add(column[0]);
                Names.Add(column[1]);
                Addresses.Add(string.Join(" ", column[2], column[3], column[4]));
            }
            return Tuple.Create(SortAndOrderByCountDescThenByNameAsc(Names),SortAndOrderByStreetName(Addresses));
        }
        public List<string> SortAndOrderByCountDescThenByNameAsc(List<string> Names)
        {
            var namesCount = Names.GroupBy(n => n).OrderByDescending(key => key.Count()).ThenBy(key => key.Key);
            List<string> result = new List<string>();
            foreach (var grp in namesCount)
            {
                result.Add(string.Join(",", grp.Key, grp.Count()));
            }
            return result;
        }
        public List<string> SortAndOrderByStreetName(List<string> Addresses)
        {
            return Addresses.OrderBy(key => key.ElementAt(key.IndexOf(" ")+1)).ToList();           
        }
    }
}
