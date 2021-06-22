using EscolarManager.Models.Id;
using EscolarManager.Models.Leason;
using EscolarManager.Models.Student;
using System.Collections.Generic;

namespace EscolarManager.Models.ClassRooms
{
    public interface IClassRoom : IId
    {
        IList<ILeason> Leasons { get; }
        IList<IStudent> Students { get; }
    }
}
