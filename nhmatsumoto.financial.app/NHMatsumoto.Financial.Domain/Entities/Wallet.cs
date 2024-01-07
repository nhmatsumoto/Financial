using NHMatsumoto.Financial.Domain.Entities;

namespace nhmatsumoto.financial.domain.Entities
{
    public class Wallet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }

        //Receitas
        public List<Revenue> Revenues { get; set; }

        //Despesas
        public List<Cost> Costs { get; set; }


        //Investimentos
        public List<Investment> Investments { get; set; }

        public Wallet(string name)
        {
            Name = name;
            Balance = 0;
            Revenues = new List<Revenue>();
            Costs = new List<Cost>();
            Investments = new List<Investment>();
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
