using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Phonebook.Domain.Entities
{
    public class Organization1
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; } = "РУП «БРЕСТАВТОДОР» ";
    }
}
