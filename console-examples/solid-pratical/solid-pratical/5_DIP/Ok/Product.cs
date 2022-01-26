namespace solid_pratical._5_DIP.Ok
{
    public class Product
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }

        public Product(int id, string code, string description)
        {
            Id = id;
            Code = code;
            Description = description;
        }

        public bool isValid => !(string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Description));
    }
}
