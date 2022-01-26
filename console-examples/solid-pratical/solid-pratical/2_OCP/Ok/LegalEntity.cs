namespace solid_pratical._2_OCP.Ok
{
    public class LegalEntity : Pessoa
    {
        public LegalEntity(IEmailService emailService): base(emailService)
        {
        }

        ICnpj Cnpj { get; set; }

        public override bool IsValid()
        {
            return base.IsValid() && Cnpj.IsValid();
        }
    }
}
