using SIDIMSClient.Api.Models.Common;

namespace SIDIMSClient.Api.ViewModel
{
    public class ProductResource: BaseEntity
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }

        
        public virtual KeyValuePairResource SidClient { get; set; }

    }
}