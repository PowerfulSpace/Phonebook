using PS.Phonebook.Domain.Entities;
using PS.Phonebook.Domain.Response;
using PS.Phonebook.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Phonebook.Service.Interfaces
{
    public interface IEmployeesPhonebookService
    {
        public Task<IBaseResponse<EmployeesPhonebook>> GetEmployeesPhonebookAsync(int id);
        public Task<IBaseResponse<EmployeesPhonebook>> GetAllEmployeesPhonebooksAsync();

        public Task<IBaseResponse<EmployeesPhonebook>> CreateEmployeesPhonebookAsync(EmployeesPhonebookViewModel model);
        public Task<IBaseResponse<EmployeesPhonebook>> UpdateEmployeesPhonebookAsync(EmployeesPhonebookViewModel model);
        public Task<IBaseResponse<EmployeesPhonebook>> DeleteEmployeesPhonebookAsync(EmployeesPhonebookViewModel model);
    }
}
