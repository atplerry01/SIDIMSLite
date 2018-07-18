using System;
using SIDIMSClient.Api.Models.Common;

namespace SIDIMSClient.Api.ViewModel
{
    public class ClientVaultReportResource: BaseEntity
    {
        public int SidProductId { get; set; }
        public int OpeningStock { get; set; }
        public int ClosingStock { get; set; }
        public int CurrentStock { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ProductResource SidProduct { get; set; }
    }
}