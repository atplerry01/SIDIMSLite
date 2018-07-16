namespace SIDIMSClient.Api.ViewModel
{
    public class CardRequestSaveResource
    {
        public int SidProductId { get; set; }
        public int? OrderNumber { get; set; }
        public int TotalBatchQty { get; set; }
        public int TotalDelivered { get; set; }
        public string CreatedById { get; set; }

    }
}