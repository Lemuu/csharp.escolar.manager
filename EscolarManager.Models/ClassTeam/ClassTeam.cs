using EscolarManager.Models.Leason;
using EscolarManager.Models.Student;
using System.Collections.Generic;

namespace EscolarManager.Models.ClassTeam
{
    class ClassTeam : IClassTeam
    {
        public long Id { get; set; }

        public string Name { get; }

        public IList<ILeason> Leasons { get; }

        public IList<IStudent> Students { get; }

        public ClassTeam(long id, string name, IList<ILeason> leasons, IList<IStudent> students)
        {
            Id = id;
            Name = name;
            Leasons = leasons;
            Students = students;
        }
    }
}
