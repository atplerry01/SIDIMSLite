using System;
using System.ComponentModel.DataAnnotations.Schema;
using SIDIMSClient.Api.Models.Account;
using SIDIMSClient.Api.Models.Common;
using SIDIMSClient.Api.Models.Lookups;

namespace SIDIMSClient.Api.Models.Inventory
{
    public class CardReceipt: BaseEntity
    {
        public int SidProductId { get; set; }
        public int ClientVaultReportId { get; set; }
        public int Quantity { get; set; }
        public string Remark { get; set; }


        [ForeignKey("SidProductId")]
        public virtual SidProduct SidProduct { get; set; }

        [ForeignKey("ClientVaultReportId")]
        public virtual ClientVaultReport ClientVaultReport { get; set; }

    }
}