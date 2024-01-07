namespace nhmatsumoto.financial.api.Domain.Entities
{
    public class VariableCost : Cost
    {
        public VariableCost(string name, decimal value) : base(name, value)
        {
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"Variable Cost - Name: {Name}, Value per unit: {Value:C}");
        }
    }
}
