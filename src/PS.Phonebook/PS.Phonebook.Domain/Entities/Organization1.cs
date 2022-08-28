using System;
using System.ComponentModel.DataAnnotations;

namespace PS.Phonebook.Domain.Entities
{
    public class Organization1
    {
        public int Id { get; set; }

        [Display(Name = "Организация1")]
        public string Name { get; set; } = "РУП «БРЕСТАВТОДОР» ";
    }
}
