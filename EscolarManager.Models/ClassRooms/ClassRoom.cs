using EscolarManager.Models.Leason;
using EscolarManager.Models.Student;
using System.Collections.Generic;

namespace EscolarManager.Models.ClassRooms
{
    class ClassRoom : IClassRoom
    {
        public long Id { get; private set; }
        public IList<ILeason> Leasons { get; private set; }
        public IList<IStudent> Students { get; private set; }

        public ClassRoom(long id, IList<ILeason> leasons, IList<IStudent> students)
        {
            Id = id;
            Leasons = leasons;
            Students = students;
        }
    }
}
