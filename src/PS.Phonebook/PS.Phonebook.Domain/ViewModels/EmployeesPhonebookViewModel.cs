using System.ComponentModel.DataAnnotations;

namespace PS.Phonebook.Domain.ViewModels
{
    public class EmployeesPhonebookViewModel
    {
        public int Id { get; set; }

        #region Organization
        [Required]
        [Display(Name = "Организация")]
        public string OrganizationName { get; set; } = "МИНИСТЕРСТВО ТРАНСПОРТА И КОММУНИКАЦИЙ";
        [Display(Name = "Организация1")]
        public string? Organization1 { get; set; }
        [Display(Name = "Организация2")]
        public string? Organization2 { get; set; }       
        [Display(Name = "Организация3")]
        public string? Organization3 { get; set; }

        [Required]
        [Range(100000, 999999)]
        [Display(Name = "Индекс")]
        public int Index { get; set; }
        [StringLength(50,ErrorMessage = "Недопустимый лемит символов")]
        [Display(Name = "Адрес")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Address { get; set; } = null!;
        [Display(Name = "факс 1")]
        public string Fax1 { get; set; } = null!;
        [Display(Name = "факс 2")]
        public string Fax2 { get; set; } = null!;
        [Display(Name = "Код АМТС")]
        public string CodeAMTC { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = null!;
        [Display(Name = "Сайт")]
        public string Site { get; set; } = null!;
        [Display(Name = "Отдел")]
        public string Department { get; set; } = null!;
        [Display(Name = "Подразделение")]
        public string? Subdivision { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; } = null!;



        #region Employee
        [Required]
        [Display(Name = "Фамилия")]
        [StringLength(50, ErrorMessage = "Недопустимый лемит символов")]
        public string Surname { get; set; } = null!;
        [Required]
        [Display(Name = "Имя")]
        [StringLength(50, ErrorMessage = "Недопустимый лемит символов")]
        public string FirstName { get; set; } = null!;
        [Required]
        [Display(Name = "Отчество")]
        [StringLength(50, ErrorMessage = "Недопустимый лемит символов")]
        public string Patronymic { get; set; } = null!;
        [Display(Name = "тел.сот.1")]
        [DataType(DataType.PhoneNumber)]
        public string SellularPhone1 { get; set; } = null!;
        [Display(Name = "тел.сот.2")]
        [DataType(DataType.PhoneNumber)]
        public string SellularPhone2 { get; set; } = null!;
        #endregion


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

        #endregion

     



    }
}
