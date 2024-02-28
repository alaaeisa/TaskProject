using AutoMapper;
using TaskProject.Infrastructure.DTO.Contact;

namespace TaskProject.Infrastructure.Mapping
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
             CreateMap<ContactVM, DataAccess.Domain.Contact.Contact>();
            //CreateMap<DataAccess.Domain.Contact.Contact, ContactVM>();
            //CreateMap<DataAccess.Domain.Contact.Contact, ContactDTO>() ;
        }
    }
}
