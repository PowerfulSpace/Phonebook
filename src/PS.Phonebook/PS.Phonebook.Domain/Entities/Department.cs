﻿using System;

namespace PS.Phonebook.Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
