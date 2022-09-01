using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PS.Phonebook.Domain.ViewModels;
using PS.Phonebook.Service.Infrastructure;
using PS.Phonebook.Service.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Phonebook.Web.Controllers
{
    public class PhonebookController : Controller
    {
        private readonly IEmployeesPhonebookService _dbContext;
        public PhonebookController(IEmployeesPhonebookService dbContext) => _dbContext = dbContext;


        
        public async Task<IActionResult> Index(string sortExpression = "", string searchText = "")
        {
            var sortModel = new SortModel();
            sortModel.AddColumn("employeName");
            sortModel.AddColumn("companyName");
            sortModel.ApplySort(sortExpression);
            ViewData["SortModel"] = sortModel;
            ViewData["SearchText"] = searchText;


            var response = await _dbContext.GetAllEmployeesPhonebooksAsync(sortModel.SortProperty, sortModel.SortOrder, searchText);
            if(response.StatusCode != Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("Error");
            }

            return View(response.Data.ToList());
        }



        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            var model = new EmployeesPhonebookViewModel();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(EmployeesPhonebookViewModel model)
        {
            if (ModelState.IsValid) { return View(model); }

            await _dbContext.CreateEmployeesPhonebookAsync(model);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _dbContext.GetEmployeePhonebookAsync(id);
            if(response.StatusCode != Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("Error");
            }

            return View(response.Data);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(EmployeesPhonebookViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            await _dbContext.UpdateEmployeesPhonebookAsync(model);

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _dbContext.GetEmployeePhonebookAsync(id);

            if(response.StatusCode != Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("Error");
            }

            return View(response.Data);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(EmployeesPhonebookViewModel model)
        {
            if (ModelState.IsValid) { return View(model); }

            await _dbContext.DeleteEmployeesPhonebookAsync(model);

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _dbContext.GetEmployeePhonebookAsync(id);

            if(response.StatusCode != Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("Error");
            }

            return View(response.Data);
        }
    }
}
