namespace nhmatsumoto.financial.domain.Entities
{
    public abstract class Cost
    {
        public string Name { get; set; }
        public decimal Value { get; set; }

        public Cost(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public abstract void ShowDetails();
    }
}
