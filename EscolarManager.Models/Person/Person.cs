using EscolarManager.Models.Phone;
using System.Collections.Generic;

namespace EscolarManager.Models.Person
{
    public class Person : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CPF { get;  }
        public IList<IPhone> Phones { get; }

        public Person(int id, string name, string address, string CPF)
        {
            Id = id;
            Name = name;
            Address = address;
            this.CPF = CPF;
            Phones = new List<IPhone>();
        }

        public Person(string name, string address, string CPF, IList<IPhone> phones)
        {
            Name = name;
            Address = address;
            this.CPF = CPF;
            Phones = phones;
        }
    }
}
