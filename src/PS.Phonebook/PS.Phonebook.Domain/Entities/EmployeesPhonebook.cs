using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Phonebook.Domain.Entities
{
    public class EmployeesPhonebook
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public Employee Employees { get; set; }
        public Organization Organizations { get; set; }
    }
}
