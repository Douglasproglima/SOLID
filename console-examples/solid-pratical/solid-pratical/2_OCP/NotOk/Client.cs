using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_pratical._2_OCP.NotOk
{
    public class Client
    {
        public enum TypeClientEnum 
        { 
            IndividualEntity,
            LegalEntity
        }

        public TypeClientEnum TypeClient{ get; set; }
        public int IdClient{ get; set; }
        public string NameIndividualEntity{ get; set; }
        public int NameLegalEntity { get; set; }

        public string Cpf{ get; set; }
        public string Cnpj{ get; set; }
        public List<string> Phones { get; set; }
    }
}
