using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Baseball.Common;
using CsvHelper;
using InterviewTest.Csv;

namespace Baseball.Data
{
    public class BatterDataReader : IBatterDataReader
    {
        private static readonly Assembly Assembly = typeof(BatterDataReader).Assembly;

        public IList<BattingStat> ReadData(int skip, int take)
        {
            using var stream = Assembly.GetManifestResourceStream("Baseball.Data.Resources.mlb-player-stats-Batters.csv");
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);

            csv.Context.RegisterClassMap<BattingStatMapping>();
            return csv.GetRecords<BattingStat>().Skip(skip).Take(take).ToList();
        }
    }
}