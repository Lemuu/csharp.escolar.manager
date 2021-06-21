using EscolarManager.Models.ClassTeam;
using EscolarManager.Models.Phone;
using System;
using System.Collections.Generic;

namespace EscolarManager.Models.School
{
    class School : ISchool
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; }
        public string Address { get; set; }
        public string Email { get; set; }
        public IList<IPhone> Phones { get; }
        public IList<IClassTeam> ClassesTeam { get; }

        public School(long id, string name, string CNPJ, string address, string email, IList<IPhone> phones, IList<IClassTeam> classesTeam)
        {
            Id = id;
            Name = name;
            this.CNPJ = CNPJ;
            Address = address;
            Email = email;
            Phones = phones;
            ClassesTeam = classesTeam;
        }

        public School(string name, string CNPJ, string address, string email, IList<IPhone> phones, IList<IClassTeam> classesTeam)
        {
            Name = name;
            this.CNPJ = CNPJ;
            Address = address;
            Email = email;
            Phones = phones;
            ClassesTeam = classesTeam;
        }

        public School(string name, string CNPJ, string address, string email)
        {
            Name = name;
            this.CNPJ = CNPJ;
            Address = address;
            Email = email;
            Phones = new List<IPhone>();
            ClassesTeam = new List<IClassTeam>();
        }

        public void AddPhone(IPhone phone)
        {
            this.Phones.Add(phone);
        }

        public void AddClassTeam(IClassTeam classTeam)
        {
            this.ClassesTeam.Add(classTeam);
        }

        public override bool Equals(object obj)
        {
            return obj is School school &&
                   Id == school.Id &&
                   CNPJ == school.CNPJ;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CNPJ);
        }
    }
}
