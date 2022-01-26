using System;
using System.Collections.Generic;

namespace solid_pratical._4_ISP.NotOk
{
    public class LegalPerson : IPerson
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public IEnumerable<string> Phones { get; set; }

        public void ValidateCnpj()
        {
            //Implements here, your rules for the CNPJ
        }

        public void ValidateCpf()
        {
            Console.WriteLine("Não possui CPF");
        }
    }
}
