namespace MVCScheduleParser.Services
{
    public interface IWeekdayDeterminant
    {
        public DateTime GetFirstDayOfWeek();
        public DateTime GetLastDayOfWeek();
    }
}
