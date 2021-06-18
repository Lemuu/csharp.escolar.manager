using EscolarManager.Models.Phone;
using System.Collections.Generic;

namespace EscolarManager.Models.Person
{
    class Person : IPerson
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CPF { get;  }
        public IList<IPhone> Phones { get; }

        public Person(string name, string address, string CPF, IList<IPhone> phones)
        {
            Name = name;
            Address = address;
            this.CPF = CPF;
            Phones = phones;
        }
    }
}
