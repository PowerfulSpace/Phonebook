namespace PS.Phonebook.Domain.ViewModels
{
    public class EmployeesPhonebookViewModel
    {
        public int Id { get; set; }

        #region Organization
        
        public string OrganizationName { get; set; } = "МИНИСТЕРСТВО ТРАНСПОРТА И КОММУНИКАЦИЙ";
        public string? Organization1 { get; set; }
        public string? Organization2 { get; set; }
        public string? Organization3 { get; set; }
        public int Index { get; set; }
        public string Address { get; set; } = null!;
        public string Fax1 { get; set; } = null!;
        public string Fax2 { get; set; } = null!;
        public string CodeAMTC { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Site { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string? Subdivision { get; set; }
        public string Position { get; set; } = null!;


        public string FramePhoneCode { get; set; } = null!;
        public int FramePhone { get; set; }
        public string Phone1 { get; set; } = null!;
        public string Phone2 { get; set; } = null!;
        public string Phone3 { get; set; } = null!;

        #endregion

        #region Employee
        public string Surname { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Patronymic { get; set; } = null!;

        public string SellularPhone1 { get; set; } = null!;
        public string SellularPhone2 { get; set; } = null!;
        #endregion



    }
}
