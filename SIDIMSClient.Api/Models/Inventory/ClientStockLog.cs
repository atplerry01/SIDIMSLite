using System.ComponentModel.DataAnnotations.Schema;
using SIDIMSClient.Api.Models.Common;

namespace SIDIMSClient.Api.Models.Inventory
{
    public class ClientStockLog: BaseEntity
    {
        public int CardIssuanceId { get; set; }

        public int IssuanceQty { get; set; }
        public int OpeningStock { get; set; }
        public int ClosingStock { get; set; }


        [ForeignKey("ClientStockReportId")]
        public virtual ClientStockReport ClientStockReport { get; set; }

        [ForeignKey("CardIssuanceId")]
        public virtual CardIssuance CardIssuance { get; set; }
    }
}