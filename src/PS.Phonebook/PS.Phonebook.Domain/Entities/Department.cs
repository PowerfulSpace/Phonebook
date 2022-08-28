using System;
using System.ComponentModel.DataAnnotations;

namespace PS.Phonebook.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }

        [Display(Name = "Отдел")]
        public string Name { get; set; } = null!;
    }
}
