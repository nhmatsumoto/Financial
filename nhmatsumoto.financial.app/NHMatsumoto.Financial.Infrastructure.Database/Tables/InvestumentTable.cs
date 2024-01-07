using nhmatsumoto.financial.infrastructure.database.Tables;
using NHMatsumoto.Financial.Domain.Enums;

namespace NHMatsumoto.Financial.Infrastructure.Database.Tables
{
    public class InvestumentTable : EntityBase
    {
        // Tipo de Investimento (Investment Type)
        public InvestmentType Type { get; set; }

        // Montante Investido (Investment Amount)
        public decimal AmountInvested { get; set; }

        // Taxa de Retorno (Return Rate)
        public decimal ReturnRate { get; set; }

        // Prazo de Investimento (Investment Term)
        public int InvestmentTermMonths { get; set; }
    }
}
