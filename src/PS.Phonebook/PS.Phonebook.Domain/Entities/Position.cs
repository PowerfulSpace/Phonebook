using System;
using System.ComponentModel.DataAnnotations;

namespace PS.Phonebook.Domain.Entities
{
    public class Position
    {
        public int Id { get; set; }

        [Display(Name = "Должность")]
        public string Name { get; set; } = null!;
    }
}
