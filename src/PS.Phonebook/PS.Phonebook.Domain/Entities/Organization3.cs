using System;
using System.ComponentModel.DataAnnotations;

namespace PS.Phonebook.Domain.Entities
{
    public class Organization3
    {
        public int Id { get; set; }

        [Display(Name = "Организация3")]
        public string? Name { get; set; } = null!;
    }
}
