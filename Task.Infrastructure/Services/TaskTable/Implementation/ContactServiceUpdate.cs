using Microsoft.EntityFrameworkCore;
using TaskProject.Infrastructure.DTO.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Infrastructure.Services.Contact
{
    public partial class ContactService
    {
        public async Task<int> Update(ContactVM ContactDto)
        {
          

            var Contact = await appliactionDbContext.Contacts.FindAsync(ContactDto.Id);
            if (Contact is null)
                throw new NullReferenceException("Not Found");
           
            MapToUpdate(Contact, ContactDto);
            await appliactionDbContext.UpdateAsync(Contact);
            return Contact.Id;
        }
    
        private void MapToUpdate(DataAccess.Domain.Contact.Contact Contact, ContactVM ContactDto)
        {
            Contact.Name = ContactDto.Name;
            Contact.Address = ContactDto.Address;
            Contact.Phone = ContactDto.Phone;
            Contact.Notes = ContactDto.Notes;
        }
    }
}
