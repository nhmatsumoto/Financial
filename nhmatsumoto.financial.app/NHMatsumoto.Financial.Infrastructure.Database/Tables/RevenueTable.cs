using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nhmatsumoto.financial.infrastructure.database.Tables
{
    //Receita (exemplo: Nota Fiscal)
    public class RevenueTable : EntityBase
    {
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Precision(18, 2)]
        public decimal Amount { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
    }
}
