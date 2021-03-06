using EscolarManager.Models.ClassTeam;
using EscolarManager.Models.Id;
using EscolarManager.Models.Phone;
using System.Collections.Generic;

namespace EscolarManager.Models.School
{
    public interface ISchool : IId
    {
        string Name { get; set; }
        string CNPJ { get; }
        string Address { get; set; }
        string Email { get; set; }
        IList<IPhone> Phones { get; }
        IList<IClassTeam> ClassesTeam { get; }
    }
}
