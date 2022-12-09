using Microsoft.Extensions.Options;
using System.Text.Json;
using MVCScheduleParser.Config;
using MVCScheduleParser.Models.ScheduleModels;

namespace MVCScheduleParser.Services
{
    public class ScheduleResolver : IScheduleResolver
    {
        private readonly APIConfiguration _config;
        private readonly ILogger _logger;
        public ScheduleResolver(ILogger<ScheduleResolver> logger, IOptions<APIConfiguration> options)
        {
            _config = options.Value;
            _logger = logger;
        }

        public async Task<Weekday[]> GetSchedule(string group, string startDate, string endDate)
        {
            _logger.LogInformation(_config.ScheduleAPI);

            string serverResponse = await GetServerResponse(group, startDate, endDate);

            Weekday[] schedule = DeserializeSchedule(serverResponse);

            return  schedule;
        }

        private async Task<string> GetServerResponse(string group, string start, string end)
        {
            var client = new HttpClient();

            var responseMessage = await client.GetAsync(new Uri(string.Format(_config.ScheduleAPI, group, start, end)));

            var response = await responseMessage.Content.ReadAsStringAsync();

            return response;
        }

        private static Weekday[] DeserializeSchedule(string serverResponse)
        {
            return JsonSerializer.Deserialize<Weekday[]>(serverResponse);
        }
    }
}
