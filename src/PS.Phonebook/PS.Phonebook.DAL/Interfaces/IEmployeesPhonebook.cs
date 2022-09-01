using PS.Phonebook.DAL.Interfaces.Base;
using PS.Phonebook.Domain.Entities;
using PS.Phonebook.Domain.Enums;
using System.Linq;

namespace PS.Phonebook.DAL.Interfaces
{
    public interface IEmployeesPhonebook : IBaseRepository<EmployeesPhonebook>
    {
        public IQueryable<EmployeesPhonebook> GetAll(string propertyName, SortOrder sortOrder);
        public IQueryable<EmployeesPhonebook> GetAll(string propertyName, SortOrder sortOrder, string searchText);
    }
}
