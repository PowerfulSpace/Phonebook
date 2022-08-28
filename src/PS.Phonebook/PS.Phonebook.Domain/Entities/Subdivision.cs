using System;
using System.ComponentModel.DataAnnotations;

namespace PS.Phonebook.Domain.Entities
{
    public class Subdivision
    {
        public int Id { get; set; }

        [Display(Name = "Подразделение")]
        public string Name { get; set; } = null!;
    }
}
