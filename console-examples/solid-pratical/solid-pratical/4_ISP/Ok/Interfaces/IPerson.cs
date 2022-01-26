using System.Collections.Generic;

namespace solid_pratical._4_ISP.Ok.Interfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        IEnumerable<string> Phones { get; set; }

        bool IsValid();
    }
}
