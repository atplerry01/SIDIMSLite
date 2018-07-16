using System;
using System.Collections.Generic;

namespace SIDIMSClient.Api.ViewModel
{
    public class CardIssuanceSaveResource
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string Remark { get; set; }
    }
}