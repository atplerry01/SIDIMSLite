using System;

namespace SIDIMSClient.Api.ViewModel
{
    public class CardReceiptResource
    {
        public int SidProductId { get; set; }
        public int ClientVaultReportId { get; set; }     
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remark { get; set; }

        public virtual ProductResource SidProduct { get; set; }
        public virtual ClientVaultReportResource ClientVaultReport { get; set; }

    }
}