using System.ComponentModel.DataAnnotations.Schema;
using SIDIMSClient.Api.Models.Common;

namespace SIDIMSClient.Api.Models.Lookups
{
    public class SidProduct: BaseEntity
    {
      
        public int SidClientId { get; set; }
      
        public string Name { get; set; }
        public string ShortCode { get; set; }
        

        [ForeignKey("SidClientId")]
        public virtual SidClient SidClient { get; set; }

    }
}