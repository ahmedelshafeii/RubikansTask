using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class MapHelper : Profile
    {
        public MapHelper() {
            CreateMap<defCustomer, CustomerDTO>();
            CreateMap<CustomerDTO,defCustomer>();
            
            CreateMap<ItemDTO,DefItem>();
            CreateMap<DefItem,ItemDTO>();

            CreateMap<StoreDTO,DefStore>();
            CreateMap<DefStore,StoreDTO>();

            

            CreateMap<InvoiceDetailsDTO, TrxInvoiceDetails>();
            CreateMap<TrxInvoiceDetails, InvoiceDetailsDTO>();
           
            CreateMap<TrxInvoiceHead, nvoiceHeadDTO>();
            CreateMap<nvoiceHeadDTO, TrxInvoiceHead>();


        }

    }
}
