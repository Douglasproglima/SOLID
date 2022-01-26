namespace solid_pratical._3_LSP.NotOk
{
    public abstract class Client
    {
        public double TotalValue { get; set; }

        public virtual double Discount()
        {
            return TotalValue;
        }
    }
}
