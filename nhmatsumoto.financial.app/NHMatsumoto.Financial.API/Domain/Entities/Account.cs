namespace nhmatsumoto.financial.api.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }
        public List<Revenue> Revenues { get; set; }
        public List<Cost> Costs { get; set; }

        public Account(string name)
        {
            Name = name;
            Balance = 0;
            Revenues = new List<Revenue>();
            Costs = new List<Cost>(); 
        }

        public void AddRevenue(Revenue revenue)
        {
            Revenues.Add(revenue);
            Balance += revenue.Amount;
        }

        public void AddCost(Cost cost)
        {
            Costs.Add(cost);
            Balance += cost.Value;
        }

        public void RemoveRevenue(Revenue revenue)
        {
            Revenues.Remove(revenue);
            Balance -= revenue.Amount;
        }

        public void RemoveCost(Cost cost)
        {
            Costs.Remove(cost);
            Balance -= cost.Value;
        }   
    }
}
