
using AutoMapper;
using TaskProject.DataAccess;
using TaskProject.Infrastructure.Interfaces.Contact;

namespace TaskProject.Infrastructure.Services.Contact
{
    public partial class ContactService : IContactService
    {
        private readonly AppDBContext appliactionDbContext;
        public ContactService(AppDBContext appliactionDbContext)
        {
            this.appliactionDbContext = appliactionDbContext;
        }
        public async Task<bool> Active(int currencyId)
        {
            var currency = await appliactionDbContext.Contacts.FindAsync(currencyId);
            if (currency is null)
                throw new NullReferenceException("Not Found");
            currency.IsActive = true;
            await appliactionDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int currencyId)
        {
            var currency = await appliactionDbContext.Contacts.FindAsync(currencyId);
            if (currency is null)
                throw new NullReferenceException("Not Found");
            currency.IsDeleted = true;
            await appliactionDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DisActive(int currencyId)
        {
            var currency = await appliactionDbContext.Contacts.FindAsync(currencyId);
            if (currency is null)
                throw new NullReferenceException("Not Found");
            currency.IsActive = false;
            await appliactionDbContext.SaveChangesAsync();
            return true;
        }
       
    }
}
