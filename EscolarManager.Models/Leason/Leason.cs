using EscolarManager.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolarManager.Models.Leason
{
    public class Leason : ILeason
    {
        public int Id { get; set; }
        public string Name { get; }
        public IPerson Teacher { get; }

        public Leason(int id, string name, IPerson teacher)
        {
            Id = id;
            Name = name;
            Teacher = teacher;
        }
    }
}
