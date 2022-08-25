using System;

namespace PS.Phonebook.Domain.Entities
{
    public class Organization3
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; } = null!;
    }
}
