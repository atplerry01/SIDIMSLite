using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using SIDIMSClient.Api.Models.Common;
using SIDIMSClient.Api.Models.Lookups;

namespace SIDIMSClient.Api.Models.Inventory
{
    public class ClientStockReport: BaseEntity
    {
        public int SidProductId { get; set; }
        public int ClientVaultReportId { get; set; }

        public string FileName { get; set; }

        public int? QtyIssued { get; set; }
        public int? TotalQtyIssued { get; set; }

        public int OpeningStock { get; set; }
        public int CurrentStock { get; set; }
        public int ClosingStock { get; set; }


        [ForeignKey("SidProductId")]
        public virtual SidProduct SidProduct { get; set; }

        [ForeignKey("ClientVaultReportId")]
        public virtual ClientVaultReport ClientVaultReport { get; set; }

        
        public ICollection<ClientStockLog> StockLogs { get; set; }

        public ClientStockReport()
        {
            StockLogs = new Collection<ClientStockLog>();
        }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}