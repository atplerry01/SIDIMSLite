namespace SIDIMSClient.Api.ViewModel
{
    public class ClientStockLogResource
    {
        public int CardIssuanceId { get; set; }

        public int IssuanceQty { get; set; }
        public int OpeningStock { get; set; }
        public int ClosingStock { get; set; }

        public virtual ClientStockReportResource ClientStockReport { get; set; }
        public virtual CardIssuanceResource CardIssuance { get; set; }
    }
}