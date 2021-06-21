using EscolarManager.Models.ClassTeam;
using EscolarManager.Models.Person;

namespace EscolarManager.Models.Student
{
    class Student : IStudent
    {
        public long Id { get; set; }

        public IPerson Person { get; }
        public IPerson Responsible { get; }

        public IClassTeam classTeam { get; }

        public Student(long id, IPerson person, IClassTeam classTeam)
        {
            Id = id;
            Person = person;
            this.classTeam = classTeam;
        }
    }
}
