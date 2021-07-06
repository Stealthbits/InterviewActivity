using System.Collections.Generic;
using Baseball.Common;

namespace Baseball.Data
{
    public interface IBatterDataReader
    {
        IList<BattingStat> ReadData(int skip, int take);
    }
}