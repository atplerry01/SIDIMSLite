using System;
using System.ComponentModel.DataAnnotations.Schema;
using SIDIMSClient.Api.Models.Lookups;

namespace SIDIMSClient.Api.Models.Inventory
{
    public class ClientVaultReport
    {
        public int Id { get; set; }
        public int SidProductId { get; set; }

        public int OpeningStock { get; set; }
        public int ClosingStock { get; set; }
        public int CurrentStock { get; set; }

        public DateTime CreateOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        [ForeignKey("SidProductId")]
        public virtual SidProduct SidProduct { get; set; }
    }
}