using System;

namespace SIDIMSClient.Api.ViewModel
{
    public class ClientVaultReportResource
    {
        public int SidProductId { get; set; }

        public int OpeningStock { get; set; }
        public int ClosingStock { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ProductResource SidProduct { get; set; }
    }
}