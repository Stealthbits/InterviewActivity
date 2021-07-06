using System.Globalization;
using Baseball.Common;
using CsvHelper.Configuration;

namespace InterviewTest.Csv
{
    public class BattingStatMapping : ClassMap<BattingStat>
    {
        public BattingStatMapping()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.PlayerName).Name("Player");
            Map(m => m.B2).Name("2B");
            Map(m => m.B3).Name("3B");
        }
    }
}