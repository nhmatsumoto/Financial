namespace nhmatsumoto.financial.domain.Entities
{
    public class VariableCost : Cost
    {
        public VariableCost(string name, decimal value) : base(name, value)
        {
        }

        public override void ShowDetails()
        {
            //Name,
            //Value
            
        }
    }
}
