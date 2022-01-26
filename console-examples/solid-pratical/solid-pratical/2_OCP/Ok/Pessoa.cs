using System.Collections.Generic;
using System.Linq;
namespace solid_pratical._2_OCP.Ok
{
    public abstract class Pessoa
    {
        private IEmailService _emailService;

        public Pessoa(IEmailService emailService)
        { 
            _emailService = emailService;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Phones { get; set; }

        public virtual bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && _emailService.IsValid() && Phones.Any();
        }
    }
}
