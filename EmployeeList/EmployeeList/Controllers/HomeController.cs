using EmployeeList.Domain.Interfaces;
using EmployeeList.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmployeeList.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestModelService _testModelService;

        public HomeController(ITestModelService _testModelService)
        {
            this._testModelService = _testModelService;
        }

        public ActionResult Index()
        {
            return View("~/Views/Shared/_LoadingPage.cshtml");
        }

        public async Task<ActionResult> TestMongo()
        {
            await _testModelService.Test();

            return View("~/Views/Shared/_LoadingPage.cshtml");
        }
    }
}