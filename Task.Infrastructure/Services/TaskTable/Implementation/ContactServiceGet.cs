using Microsoft.EntityFrameworkCore;
using TaskProject.Infrastructure.DTO;
using TaskProject.Infrastructure.DTO.Contact;

namespace TaskProject.Infrastructure.Services.Contact
{
    public partial class ContactService
    {
        public async Task<ContactVM> GetById(int ContactId)
        {
            var Contact = await appliactionDbContext.Contacts.FindAsync(ContactId);
            if (Contact is null)
                throw new NullReferenceException("Not Found");

            var  Obj = new  ContactVM();
            Obj.Id = Contact.Id;
            Obj.Name = Contact.Name;
            Obj.Phone = Contact.Phone;
            Obj.Address = Contact.Address;
            Obj.Notes = Contact.Notes;
            return Obj;
        }
    }
}
