using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Phonebook.Domain.Entities
{
    public class Subdivision
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
