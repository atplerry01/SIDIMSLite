using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SIDIMSClient.Api.Models.Common;
using SIDIMSClient.Api.Models.Lookups;

namespace SIDIMSClient.Api.Models.Inventory
{
    public class CardIssuance: BaseEntity
    {   
        public int ProductId { get; set; }
        public int ClientStockReportId { get; set; }

        public int Quantity { get; set; }

        public virtual SidProduct Product { get; set; }
        public ClientStockReport ClientStockReport { get; set; }

    }
}