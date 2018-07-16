using System.Collections.Generic;

namespace SIDIMSClient.Api.ViewModel
{
    public class JobSaveResource
    {
        
        public int SidClientId { get; set; }
        public int SidCardTypeId { get; set; }
        public string JobName { get; set; }
        public int Quantity { get; set; }

    }
}