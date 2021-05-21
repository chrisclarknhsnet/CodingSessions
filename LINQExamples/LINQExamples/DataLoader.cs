using CsvHelper;
using LINQExamples.POCOs;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace LINQExamples
{
    public static class DataLoader
    {
        public static IList<UserTakeup> LoadData(string filename)
        {
            using (TextReader reader = new StreamReader(filename))
            {
                var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture);
                return csvReader.GetRecords<UserTakeup>().ToList();
            }
        }
    }
}
