using MVCScheduleParser.Models.ScheduleModels;

namespace MVCScheduleParser.Services
{
    public interface IScheduleResolver
    {
        Task<List<Weekday>> GetSchedule(string group, string startDate, string endDate);
    }
}
