using TaskProject.Infrastructure.DTO;
using TaskProject.Infrastructure.DTO.Contact;

namespace TaskProject.Infrastructure.Interfaces.Contact
{
    public interface IContactService
    {
        public Task<int> Create(ContactVM Contact);
        public Task<int> Update(ContactVM Contact);
        public Task<bool> Delete(int ContactId);
        public Task<ContactVM> GetById(int ContactId);
        public Task<bool> Active(int ContactId);
        public Task<bool> DisActive(int ContactId);
        Task<(List<ContactDTO> data, int recordsFiltered, int recordsTotal)> ListAllCurrenciesByPage(DataTableParamterDTO tableParamter, ContactIndexSearchDTO searchObj);
    
    
    }
}
