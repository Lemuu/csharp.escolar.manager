using EscolarManager.Models.ClassTeam;
using EscolarManager.Models.Id;
using EscolarManager.Models.Person;

namespace EscolarManager.Models.Student
{
    public interface IStudent : IId
    {
        IClassTeam ClassTeam { get; }
        IPerson Person { get; }
        IPerson Responsible { get; }
    }
}
