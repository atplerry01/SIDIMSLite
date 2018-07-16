using System.Collections.Generic;
using System.Collections.ObjectModel;
using SIDIMSClient.Api.Models.Common;

namespace SIDIMSClient.Api.Models.Lookups
{
    public class SidClient: BaseEntity
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
    }
}