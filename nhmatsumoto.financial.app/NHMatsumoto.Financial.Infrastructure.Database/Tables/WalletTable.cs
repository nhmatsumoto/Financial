using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace nhmatsumoto.financial.infrastructure.database.Tables
{
    public class WalletTable : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Currency)]
        [Precision(18, 2)]
        public decimal Balance { get; set; } = 0;

        //Custos
        public virtual ICollection<CostTable> Costs { get; set; }

        //Receitas
        public virtual ICollection<RevenueTable> Revenues { get; set; }
    }
}
