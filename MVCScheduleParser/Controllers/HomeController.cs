using Microsoft.AspNetCore.Mvc;
using MVCScheduleParser.Models;
using MVCScheduleParser.Models.ScheduleModels;
using MVCScheduleParser.Services;
using System.Diagnostics;

namespace MVCScheduleParser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScheduleResolver _scheduleResolver;
        private readonly IWeekdayDeterminant _weekdayDeterminant;

        public HomeController(ILogger<HomeController> logger, 
            IScheduleResolver scheduleResolver, 
            IWeekdayDeterminant weekdayDeterminant)
        {
            _logger = logger;
            _scheduleResolver = scheduleResolver;
            _weekdayDeterminant = weekdayDeterminant;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Schedule(string group)
        {
            var schedule = await _scheduleResolver.GetSchedule(group,
                _weekdayDeterminant.GetFirstDayOfWeek().ToShortDateString(), 
                _weekdayDeterminant.GetLastDayOfWeek().ToShortDateString());
            return View(schedule);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}