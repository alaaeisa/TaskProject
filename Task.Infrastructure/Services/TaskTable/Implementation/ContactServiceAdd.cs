
using TaskProject.Infrastructure.DTO.Contact;

namespace TaskProject.Infrastructure.Services.Contact
{
    public partial class ContactService
    {
        public async Task<int> Create(ContactVM Contact)
        {
      

            var _Contact = new DataAccess.Domain.Contact.Contact();
            _Contact.Name  = Contact.Name;
            _Contact.Phone = Contact.Phone;
            _Contact.Address = Contact.Address;
            _Contact.Notes = Contact.Notes;
            await appliactionDbContext.Contacts.AddAsync(_Contact);
            await appliactionDbContext.SaveChangesAsync();
            return Contact.Id;
        }

     

       
    }
}
