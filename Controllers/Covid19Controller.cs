using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Covid19DataProject.Models.Covid19;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Covid19DataProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Covid19Controller : ControllerBase
    {
        private readonly ILogger<Covid19Controller> _logger;
        private readonly HttpClient _client;


        public Covid19Controller(ILogger<Covid19Controller> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _client = clientFactory.CreateClient();
            _client.BaseAddress = new Uri("http://covidtracking.com");
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<USCurrent> GetUsCurrent()
        {
            var response = await _client.GetAsync("/api/v1/us/current.json");
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            var objs = JsonSerializer.Deserialize<List<USCurrent>>(resp);

            //to convert the date that is passed over as an int in yyyyMMdd to a DateTime. I could implement a custom JSON converter if were a bigger issue.
            foreach (var obj in objs)
                obj.Date = DateTime.ParseExact(obj.DateInt.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);

            return objs[0];
        }
    }
}