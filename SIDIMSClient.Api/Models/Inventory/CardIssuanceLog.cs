using SIDIMSClient.Api.Models.Common;

namespace SIDIMSClient.Api.Models.Inventory
{
    public class CardIssuanceLog: BaseEntity
    {
        
        public int CardIssuanceId { get; set; }
        
        public int QuantityIssued { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CardIssuance CardIssuance { get; set; }

    }
}