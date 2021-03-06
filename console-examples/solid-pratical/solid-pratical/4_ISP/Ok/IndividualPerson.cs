using solid_pratical._4_ISP.Ok.Interfaces;
using System.Collections.Generic;

namespace solid_pratical._4_ISP.Ok
{
    public class IndividualPerson : IIndividualPerson
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Phones { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Cpf);
        }
    }
}
