using System.Collections.Generic;

namespace solid_pratical._4_ISP.NotOk
{
    public interface IPerson
    {
        string Name { get; set; }
        string Cnpj { get; set; }
        string Cpf { get; set; }
        IEnumerable<string> Phones { get; set; }
        void ValidateCpf();
        void ValidateCnpj();
    }
}
