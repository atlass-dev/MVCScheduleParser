namespace MVCScheduleParser.Services
{
    public class WeekdayDeterminant : IWeekdayDeterminant
    {
        public DateTime GetFirstDayOfWeek()
        {
            return DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek+1);
        }

        public DateTime GetLastDayOfWeek()
        {
            return DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek);
        }
    }
}
