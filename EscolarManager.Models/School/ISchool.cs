using EscolarManager.Models.ClassTeam;
using EscolarManager.Models.Phone;
using System.Collections.Generic;

namespace EscolarManager.Models.School
{
    interface ISchool
    {
        long Id { get; }
        string Name { get; set; }
        string CNPJ { get; }
        string Address { get; set; }
        string Email { get; set; }
        IList<IPhone> Phones { get; }
        IList<IClassTeam> ClassesTeam { get; }
    }
}
