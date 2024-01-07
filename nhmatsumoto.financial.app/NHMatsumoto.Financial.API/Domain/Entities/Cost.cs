namespace nhmatsumoto.financial.api.Domain.Entities
{
    public abstract class Cost
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Definition { get; set; }
        public string Exemple { get; set; }
        public string Characteristics { get; set; }

        public Cost(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public abstract void ShowDetails();
    }
}
