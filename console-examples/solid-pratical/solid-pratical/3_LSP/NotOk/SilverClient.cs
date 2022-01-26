namespace solid_pratical._3_LSP.NotOk
{
    public class SilverClient : Client
    {
        public override double Discount()
        {
            return TotalValue - 50;
        }
    }
}
