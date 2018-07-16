using System;

namespace SIDIMSClient.Api.ViewModel
{
    public class CardReceiptSaveResource
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Remark { get; set; }
    }
}