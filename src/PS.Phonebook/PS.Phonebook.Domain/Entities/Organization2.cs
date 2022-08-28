using System;
using System.ComponentModel.DataAnnotations;

namespace PS.Phonebook.Domain.Entities
{
    public class Organization2
    {
        public int Id { get; set; }
        [Display(Name = "Организация2")]
        public string? Name { get; set; } = null;
    }
}
