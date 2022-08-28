using System;
using System.ComponentModel.DataAnnotations;

namespace PS.Phonebook.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; } = null!;
        [Display(Name = "Имя")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; } = null!;
       

        [Display(Name = "тел.сот.1")]
        public string SellularPhone1 { get; set; } = null!;
        [Display(Name = "тел.сот.2")]
        public string SellularPhone2 { get; set; } = null!;


        public Position Position { get; set; } = null!;

        public Organization Organization { get; set; } = null!;

    }
}
