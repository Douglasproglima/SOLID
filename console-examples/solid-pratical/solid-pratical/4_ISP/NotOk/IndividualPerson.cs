using System;
using System.Collections.Generic;

namespace solid_pratical._4_ISP.NotOk
{
    public class IndividualPerson : IPerson
    {
        public string Name { get ; set; }
        public string Cnpj { get; set; }
        public string Cpf { get ; set; }
        public IEnumerable<string> Phones { get; set; }

        public void ValidateCnpj()
        {
            Console.WriteLine("Não possui CNPJ");
        }

        public void ValidateCpf()
        {
            //Implements here, your rules for the CPF
        }
    }
}
