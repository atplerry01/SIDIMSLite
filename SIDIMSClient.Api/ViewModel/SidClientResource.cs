using SIDIMSClient.Api.Models.Common;

namespace SIDIMSClient.Api.ViewModel
{
    public class SidClientResource: BaseEntity
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
    }
}