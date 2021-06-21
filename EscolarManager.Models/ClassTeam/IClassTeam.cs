using EscolarManager.Models.Id;
using EscolarManager.Models.Leason;
using EscolarManager.Models.Student;
using System.Collections.Generic;

namespace EscolarManager.Models.ClassTeam
{
    interface IClassTeam : IId
    {
        string Name { get; }
        IList<ILeason> Leasons { get; }
        IList<IStudent> Students { get; }
    }
}
