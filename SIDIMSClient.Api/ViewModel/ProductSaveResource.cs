namespace SIDIMSClient.Api.ViewModel
{
    public class ProductSaveResource
    {
        public int SidClientId { get; set; }
        public int SidCardTypeId { get; set; }

        public string Name { get; set; }
        public string ShortCode { get; set; }

        public bool IsDeleted { get; set; }
        public bool HasImage { get; set; }
    }
}