using System;

namespace PS.Phonebook.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;

        public Position Position { get; set; } = null!;

        public string SellularPhone1 { get; set; } = null!;
        public string SellularPhone2 { get; set; } = null!;

        public Organization Organization { get; set; } = null!;

    }
}
