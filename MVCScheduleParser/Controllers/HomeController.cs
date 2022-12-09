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

        public HomeController(ILogger<HomeController> logger, IScheduleResolver scheduleResolver)
        {
            _logger = logger;
            _scheduleResolver = scheduleResolver;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Schedule(string group)
        {
            var schedule = await _scheduleResolver.GetSchedule(group, "05.12.2022", "11.12.2022");
            return View(schedule);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}