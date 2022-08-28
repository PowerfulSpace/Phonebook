using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PS.Phonebook.Domain.Entities
{
    public class Organization
    {

        public int Id { get; set; }
        [Display(Name = "Организация")]
        public string Name { get; set; } = "МИНИСТЕРСТВО ТРАНСПОРТА И КОММУНИКАЦИЙ";
        public Organization1? Organization1 { get; set; } = null!;
        public Organization2? Organization2 { get; set; } = null!;
        public Organization3? Organization3 { get; set; } = null!;

        [Display(Name = "Адрес")]
        public string Address { get; set; } = null!;
        [Display(Name = "E-mail")]
        public string Email { get; set; } = null!;
        [Display(Name = "Сайт")]
        public string Site { get; set; } = null!;

        public Department Department { get; set; } = null!;
        public Subdivision? Subdivision { get; set; } = null!;

        [Display(Name = "факс 1")]
        public string Fax1 { get; set; } = null!;
        [Display(Name = "факс 2")]
        public string Fax2 { get; set; } = null!;
        [Display(Name = "Код АМТС")]
        public string CodeAMTC { get; set; } = null!;
        [Display(Name = "код тел.кор.")]
        public string FramePhoneCode { get; set; } = null!;
        [Display(Name = "тел.кор.")]
        public int FramePhone { get; set; }
        [Display(Name = "тел. 1")]
        public string Phone1 { get; set; } = null!;
        [Display(Name = "тел. 2")]
        public string Phone2 { get; set; } = null!;
        [Display(Name = "тел. 3")]
        public string Phone3 { get; set; } = null!;

        public List<Employee> Employee { get; set; } = null!;



    }
}
