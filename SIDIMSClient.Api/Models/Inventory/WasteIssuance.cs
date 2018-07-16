using System;
using SIDIMSClient.Api.Models.Common;

namespace SIDIMSClient.Api.Models.Inventory
{
    public class WasteIssuance: BaseEntity
    {
        public int WasteQuantity { get; set; }

        public int InventoryId { get; set; }
        //public Inventory Inventory { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}