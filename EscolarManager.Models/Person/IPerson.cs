using EscolarManager.Models.Id;
using EscolarManager.Models.Phone;
using System.Collections.Generic;

namespace EscolarManager.Models.Person
{
    interface IPerson : IId
    {
        string Name { get; set; }
        string Address { get; set; }
        string CPF { get; }
        IList<IPhone> Phones { get; }
    }
}
