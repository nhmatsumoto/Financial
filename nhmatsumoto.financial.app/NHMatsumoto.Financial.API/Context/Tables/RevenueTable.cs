using Microsoft.EntityFrameworkCore;
using nhmatsumoto.financial.api.Context.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nhmatsumoto.financial.api.Context.Tables
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
