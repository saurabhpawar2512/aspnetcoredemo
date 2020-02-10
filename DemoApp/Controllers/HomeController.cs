using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        private IPersonRepo _personRepo;
        private ILogger<HomeController> _logger;

        public HomeController(IPersonRepo personRepo, ILogger<HomeController> logger)
        {
            _personRepo = personRepo;
            _logger = logger;
        }

        public string Index()
        {
            return _personRepo.GetPerson().Name;
        }

        public string Log()
        {
            _logger.LogTrace("logging");
            return "Logged";
        }
    }
}
