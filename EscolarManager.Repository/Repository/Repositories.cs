using EscolarManager.Repository.Persons;
using EscolarManager.Repository.Repository.ClassTeams;
using EscolarManager.Repository.Repository.Leasons;
using EscolarManager.Repository.Schools;
using EscolarManager.Repository.Users;

namespace EscolarManager.Repository
{
    public static class Repositories
    {
        public static readonly PersonRepository PersonRepository = new();
        public static readonly PersonPhonesRepository PersonPhonesRepository = new();

        public static readonly UserRepository UserRepository = new();

        public static readonly SchoolRepository SchoolRepository = new();
        public static readonly SchoolPhonesRepository SchoolPhonesRepository = new();

        public static readonly ClassTeamsRepository ClassTeamsRepository = new();
        public static readonly ClassTeamsStudentsRepository ClassTeamsPhonesRepository = new();
        public static readonly ClassTeamsLeasonsRepository ClassTeamsLeasonsRepository = new();

        public static readonly LeasonRepository LeasonRepository = new();
    }
}
