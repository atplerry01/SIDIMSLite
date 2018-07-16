using System.Collections.Generic;

namespace SIDIMSClient.Api.ViewModel
{
    public class CardRequestResource
    {
        public int SidProductId { get; set; }
        public int? OrderNumber { get; set; }
        public int TotalBatchQty { get; set; }
        public int TotalDelivered { get; set; }
        public string CreatedById { get; set; }
        
        public virtual ProductResource SidProduct { get; set; }        
        public ICollection<CardReceiptResource> CardReceiptLogs { get; set; }

    }
}