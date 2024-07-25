using AutoMapper;
using hf.Api.Requests;
using hf.Api.Responses;
using hf.Domain.Entities;
using hf.Domain.Entities.Extensions;

namespace hf.Api.MapperProfile
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<NewUserRequest, User>().ReverseMap();
            CreateMap<LoginRequest, Login>().ReverseMap();
            CreateMap<NewProductRequest, Product>().ReverseMap();
            CreateMap<InvoiceHeaderRequest, InvoiceHeader>().ReverseMap();
            CreateMap<InvoiceLineRequest, InvoiceLine>().ReverseMap();
            CreateMap<InvoiceUserExtension, ListInvoiceResponse>()
                .ForMember(x => x.Id, ent => ent.MapFrom(x => x.InternalInvoiceHeader.Id))
                .ForMember(x => x.Date, ent => ent.MapFrom(x => x.InternalInvoiceHeader.Date))
                .ForMember(x => x.Subtotal, ent => ent.MapFrom(x => x.InternalInvoiceHeader.Subtotal))
                .ForMember(x => x.ClientId, ent => ent.MapFrom(x => x.InternalInvoiceHeader.ClientId))
                .ForMember(x => x.FriendlyName, ent => ent.MapFrom(x => x.FriendlyName));
        }
    }
}
