using Microsoft.AspNetCore.Mvc;
using PS.Phonebook.Service.Interfaces;

namespace PS.Phonebook.Web.Controllers
{
    public class PhonebookController : Controller
    {
        private readonly IEmployeesPhonebookService _dbContext;


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
