using System;
using System.Collections.Generic;
using Baseball.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BaseballController : ControllerBase
    {
        private readonly IBatterDataReader _dataReader;

        private static readonly Dictionary<Guid, int> Pages = new();

        public BaseballController(IBatterDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        [HttpGet("batter/list")]
        public BattingStatResponse Get(Guid? page)
        {
            var skip = 0;
            if (page.HasValue && !Pages.TryGetValue(page.Value, out skip))
            {
                throw new Exception($"Unknown page '{page}'");
            }

            const int take = 100;
            var data = _dataReader.ReadData(skip, take);

            Guid? nextPage;
            if (data.Count == take)
            {
                nextPage = Guid.NewGuid();
                Pages[nextPage.Value] = skip + data.Count;
            }
            else
            {
                nextPage = null;
            }

            var response = new BattingStatResponse(data, nextPage);
            return response;
        }
    }
}
