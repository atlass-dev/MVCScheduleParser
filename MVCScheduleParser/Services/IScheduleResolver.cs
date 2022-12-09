using MVCScheduleParser.Models.ScheduleModels;

namespace MVCScheduleParser.Services
{
    public interface IScheduleResolver
    {
        Task<Weekday[]> GetSchedule(string group, string startDate, string endDate);
    }
}
