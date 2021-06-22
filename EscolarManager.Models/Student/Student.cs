using EscolarManager.Models.ClassTeam;
using EscolarManager.Models.Person;

namespace EscolarManager.Models.Student
{
    public class Student : IStudent
    {
        public int Id { get; set; }

        public IPerson Person { get; }
        public IPerson Responsible { get; }

        public IClassTeam classTeam { get; }

        public Student(int id, IPerson person, IPerson responsible, IClassTeam classTeam)
        {
            Id = id;
            Person = person;
            Responsible = responsible;
            this.classTeam = classTeam;
        }
    }
}
