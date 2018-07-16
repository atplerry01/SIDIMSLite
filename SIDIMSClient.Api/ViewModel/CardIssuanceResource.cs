using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SIDIMSClient.Api.ViewModel
{
    public class CardIssuanceResource
    {
        public int ProductId { get; set; }
        public int ClientStockReportId { get; set; }
        public int Quantity { get; set; }

    }
}