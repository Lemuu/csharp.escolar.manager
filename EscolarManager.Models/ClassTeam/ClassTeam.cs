using EscolarManager.Models.Leason;
using EscolarManager.Models.Student;
using System.Collections.Generic;

namespace EscolarManager.Models.ClassTeam
{
    public class ClassTeam : IClassTeam
    {
        public int Id { get; set; }

        public string Name { get; }

        public IList<ILeason> Leasons { get; }

        public IList<IStudent> Students { get; }

        public ClassTeam(int id, string name, IList<ILeason> leasons, IList<IStudent> students)
        {
            Id = id;
            Name = name;
            Leasons = leasons;
            Students = students;
        }

        public ClassTeam(int id, string name)
        {
            Id = id;
            Name = name;
            Leasons = new List<ILeason>();
            Students = new List<IStudent>();
        }

        public void AddLeason(Leason.Leason leason)
        {
            this.Leasons.Add(leason);
        }
    }
}
