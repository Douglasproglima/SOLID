namespace solid_pratical._3_LSP.NotOk
{
    public class GodClient : Client
    {
        public override double Discount()
        {
            return TotalValue - 100;
        }
    }
}
