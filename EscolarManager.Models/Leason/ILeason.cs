using EscolarManager.Models.Id;
using EscolarManager.Models.Person;

namespace EscolarManager.Models.Leason
{
    public interface ILeason : IId
    {
        string Name { get; }
        IPerson Teacher { get; }
    }
}
