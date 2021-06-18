using EscolarManager.Models.Leason;
using EscolarManager.Models.Student;
using System.Collections.Generic;

namespace EscolarManager.Models.ClassRooms
{
    interface IClassRoom
    {
        long Id { get; }
        IList<ILeason> Leasons { get; }
        IList<IStudent> Students { get; }
    }
}
