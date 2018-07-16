using System.Collections.Generic;

namespace SIDIMSClient.Api.ViewModel
{
    public class JobResource
    {
        
        public int SidClientId { get; set; }
        public int SidCardTypeId { get; set; }
        public string JobName { get; set; }
        public int Quantity { get; set; }
        public bool IsCompleted { get; set; }

        
        public virtual SidClientResource SidClient { get; set; }
        public virtual KeyValuePairResource SidCardType { get; set; }

        public ICollection<CardIssuanceResource> Issuances { get; set; }
    }
}