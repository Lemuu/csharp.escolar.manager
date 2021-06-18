using EscolarManager.Models.Phone;
using System.Collections.Generic;

namespace EscolarManager.Models.Person
{
    interface IPerson
    {
        string Name { get; set; }
        string Address { get; set; }
        string CPF { get; }
        IList<IPhone> Phones { get; }
    }
}
