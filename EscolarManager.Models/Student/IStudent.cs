using EscolarManager.Models.ClassTeam;
using EscolarManager.Models.Person;

namespace EscolarManager.Models.Student
{
    interface IStudent
    {
        long Id { get; }
        IClassTeam classTeam { get; }
        IPerson Person { get; }
        IPerson Responsible { get; }
    }
}
