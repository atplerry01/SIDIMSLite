using System;
using System.Collections.Generic;

namespace SIDIMSClient.Api.ViewModel
{
    public class ClientStockReportResource
    {
        public int SidProductId { get; set; }
        public int ClientVaultReportId { get; set; }

        public string FileName { get; set; }

        public int QtyIssued { get; set; }

        public int TotalQtyIssued { get; set; }
        public int CurrentStock { get; set; }


        public int OpeningStock { get; set; }
        public int ClosingStock { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ProductResource SidProduct { get; set; }

        public virtual ClientVaultReportResource ClientVaultReport { get; set; }
        
        public ICollection<ClientStockLogResource> StockLogs { get; set; }

    }
}