using CheckList.Core.Contracts;
using CheckList.Core.Models;
using CheckList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;
using System.Diagnostics;

namespace CheckList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICheckListService checkListService;
        public HomeController(ILogger<HomeController> logger, ICheckListService service)
        {
            _logger = logger;
            checkListService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Schedule(Guid id)
        {
            var scheduleItems = await checkListService.GetScheduleItems(id);
            var goalItems = await checkListService.GetGoalItems(id);
            var motivation = await checkListService.GetMotivation(id);

            DateAndItemsViewModel model = new DateAndItemsViewModel()
            {
                GoalItems = goalItems,
                ScheduleItems = scheduleItems,
                Motivaton = motivation
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dates = await checkListService.GetDates();

            return View(dates
                .Select(d => new DateViewModel()
                {
                    Id = d.Id,
                    DateTime = d.DateTime
                }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DateViewModel model)
        {
            var date = new Date()
            {
                DateTime = model.DateTime
            };

            await checkListService.AddDate(date);

            var dateModel = await checkListService.GetDate(date.DateTime);

            var goalItems = model.GoalItems
                .Select(x => new GoalItem()
                {
                    Content = x,
                    DateId = dateModel.Id,
                    IsFinished = false
                })
                .ToList();

            var scheduleItems = model.ScheduleItems
                .Select(x => new ScheduleItem()
                {
                    Content = x,
                    DateId = dateModel.Id,
                    IsFinished = false
                })
                .ToList();

            var motivation = new Motivation()
            {
                Content = model.Motivaton,
                DateId = dateModel.Id,
            };

            await checkListService.CreateCheckList(goalItems, motivation, scheduleItems);

            return RedirectToAction(nameof(Get));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}