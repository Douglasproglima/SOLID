namespace solid_pratical._2_OCP.Ok
{
    public class IndividualEntity : Pessoa
    {
        public IndividualEntity(IEmailService emailService) : base(emailService)
        {
        }

        ICpf Cpf { get; set; }

        public override bool IsValid()
        {
            return base.IsValid() && Cpf.IsValid();
        }
    }
}
