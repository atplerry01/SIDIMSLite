using AutoMapper;
using SIDIMSClient.Api.Models;
using SIDIMSClient.Api.Models.Inventory;
using SIDIMSClient.Api.Models.Lookups;
using SIDIMSClient.Api.ViewModel;

namespace SIDIMSClient.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Api Resources
            CreateMap<Vendor, KeyValuePairResource>();

            CreateMap<SidClient, SidClientResource>();
            CreateMap<CardReceipt, CardReceiptResource>();
            CreateMap<SidProduct, ProductResource>();
            CreateMap<CardIssuance, CardIssuanceResource>();
            CreateMap<CardIssuanceLog, CardIssuanceLogResource>();
            CreateMap<ClientVaultReport, ClientVaultReportResource>();
            
            // // Api Resources to Domain
            CreateMap<CardReceiptSaveResource, CardReceipt>();
            CreateMap<ProductSaveResource, SidProduct>();
            CreateMap<CardIssuanceSaveResource, CardIssuance>();
    
        }
    }
}