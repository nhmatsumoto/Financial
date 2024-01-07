using NHMatsumoto.Financial.Domain.Enums;

namespace NHMatsumoto.Financial.Domain.Entities
{
    public class Investment
    {
        // Tipo de Investimento (Investment Type)
        public InvestmentType Type { get; set; }

        // Montante Investido (Investment Amount)
        public decimal AmountInvested { get; set; }

        // Taxa de Retorno (Return Rate)
        public decimal ReturnRate { get; set; }

        // Prazo de Investimento (Investment Term)
        public int InvestmentTermMonths { get; set; }

        public Investment()
        {

        }

        // Construtor com parâmetros (Parameterized Constructor)
        public Investment(InvestmentType type, decimal amountInvested, decimal returnRate, int investmentTermMonths)
        {
            Type = type;
            AmountInvested = amountInvested;
            ReturnRate = returnRate;
            InvestmentTermMonths = investmentTermMonths;
        }
    }

}
