using System;
using System.Collections.Generic;

namespace PS.Phonebook.Domain.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; } = "МИНИСТЕРСТВО ТРАНСПОРТА И КОММУНИКАЦИЙ";
        public Organization1? Organization1 { get; set; } = null!;
        public Organization2? Organization2 { get; set; } = null!;
        public Organization3? Organization3 { get; set; } = null!;

        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Site { get; set; } = null!;

        public Department Department { get; set; } = null!;
        public Subdivision? Subdivision { get; set; } = null!;

        public string Fax1 { get; set; } = null!;
        public string Fax2 { get; set; } = null!;
        public string CodAMTC { get; set; } = null!;

        public string FramePhoneCode { get; set; } = null!;
        public int FramePhone { get; set; }

        public string Phone1 { get; set; } = null!;
        public string Phone2 { get; set; } = null!;
        public string Phone3 { get; set; } = null!;

        public List<Employee> Employee { get; set; } = null!;



    }
}
