using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public class Abonent
    {
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{this.PhoneNumber}:{this.Name}";
        }
    }
}
