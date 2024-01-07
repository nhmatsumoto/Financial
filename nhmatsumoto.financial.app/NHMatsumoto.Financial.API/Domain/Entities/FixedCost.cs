using nhmatsumoto.financial.api.Domain.Entities;

namespace nhmatsumoto.financial.api.Domain.Tables
{
    public class FixedCostTable : Cost
    {
        public FixedCostTable(string name, decimal value) : base(name, value)
        {
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"Fixed Cost - Name: {Name}, Value: {Value:C}");
        }
    }
}
