using Microsoft.EntityFrameworkCore;
using nhmatsumoto.financial.infrastructure.database.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nhmatsumoto.financial.infrastructure.database.Tables
{
    public class CostTable : EntityBase
    {
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Precision(18, 2)]
        public decimal Value { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        public CostTypeEnum CostType { get; set; }
        public CostStatusEnum Status { get; set; }
        [ForeignKey("AccountTableId")]
        public int WalletId { get; set; }

    }
}
