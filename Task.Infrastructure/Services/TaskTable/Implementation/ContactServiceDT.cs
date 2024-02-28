using Microsoft.EntityFrameworkCore;
using TaskProject.Infrastructure.DTO;
using TaskProject.Infrastructure.DTO.Contact;

namespace TaskProject.Infrastructure.Services.Contact
{
    public partial class ContactService
    {
        public async Task<(List<ContactDTO> data, int recordsFiltered, int recordsTotal)> ListAllCurrenciesByPage(DataTableParamterDTO tableParamter, ContactIndexSearchDTO searchObj)
        {
            var currencies = await appliactionDbContext.Contacts
                .Where(y => !y.IsDeleted
                    && (y.Name.Contains(tableParamter.Search)
                    || y.Phone.Contains(tableParamter.Search)
                    || y.Address.Contains(tableParamter.Search))
                    && (searchObj.IsActive == null || y.IsActive== searchObj.IsActive))
                .Select(c => new ContactDTO
                { Id = c.Id, Name = c.Name, Phone = c.Phone, IsActive = c.IsActive })
                .AsNoTracking().ToListAsync();
            var returnedCurrencies = OrderTable(currencies.AsQueryable(), tableParamter.Order, tableParamter.OrderDir);


            int CountUnSkipped = returnedCurrencies.Count();
            var selectedCurrencies = tableParamter.PageSize != -1 ? returnedCurrencies.Skip(tableParamter.StartRec).Take(tableParamter.PageSize) : returnedCurrencies.Skip(0);
            return (selectedCurrencies.ToList(), CountUnSkipped, currencies.Count);
        }

        public IQueryable<ContactDTO> OrderTable(IQueryable<ContactDTO> currencies, string orderColumn, string orderDir)
        {
            if (!(string.IsNullOrEmpty(orderColumn) && string.IsNullOrEmpty(orderDir)))
            {
                if (orderColumn == "Id" && orderDir == "asc")
                {
                    currencies = currencies.OrderBy(p => p.Id);
                }
                else if (orderColumn == "Id" && orderDir != "asc")
                {
                    currencies = currencies.OrderByDescending(p => p.Id);
                }

                if (orderColumn == "Name" && orderDir == "asc")
                {
                    currencies = currencies.OrderBy(p => p.Name);
                }
                else if (orderColumn == "Name" && orderDir != "asc")
                {
                    currencies = currencies.OrderByDescending(p => p.Name);
                }

             
            }
            return currencies;
        }
    }
}
