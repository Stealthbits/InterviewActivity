using System;
using System.Collections.Generic;
using Baseball.Common;

namespace WebApi.Models
{
    public class BattingStatResponse
    {
        public BattingStatResponse(IEnumerable<BattingStat> stats, Guid? nextPage = null)
        {
            Stats = stats;
            NextPage = nextPage;
        }

        public IEnumerable<BattingStat> Stats { get; }

        public Guid? NextPage { get; }
    }
}