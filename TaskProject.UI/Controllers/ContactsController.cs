using Microsoft.AspNetCore.Mvc;
using TaskProject.Infrastructure.DTO.Contact;
using TaskProject.Infrastructure.DTO;
using TaskProject.Infrastructure.Interfaces.Contact;
using TaskProject.UI.Areas.CP.Helper;

namespace TaskProject.UI.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService _contactUsService;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger, IContactService contactUsService)
        {
            _contactUsService = contactUsService;
            _logger = logger;

        }


        [HttpPost]
        public async Task<IActionResult> GetDataTable(ContactIndexSearchDTO SearchObj)
        {
            _logger.LogInformation("GetDataTable");
            var returnedDataTableParamter = HandleDataTableHttpRequest.HandleRequet(Request);
            var returnData = await _contactUsService.ListAllCurrenciesByPage(returnedDataTableParamter, SearchObj);
            var jsonData = new { recordsFiltered = returnData.recordsFiltered, recordsTotal = returnData.recordsTotal, data = returnData.data };
            return Ok(jsonData);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index1()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new ContactVM();
            return PartialView("_Form", model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContactVM contact)
        {
            _logger.LogInformation("Create");
            if (!ModelState.IsValid)
                return BadRequest(new BaseResponseDTO { IsSuccess = false, Errors = ModelState.Values.SelectMany(c => c.Errors.Select(c => c.ErrorMessage)).ToList() });
            contact.IsActive = true;
            var response = await _contactUsService.Create(contact);
            return Ok(new BaseResponseDTO { IsSuccess = true, Data = response });
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _contactUsService.GetById(id);
            return PartialView("_Form", model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ContactVM contact)
        {
            _logger.LogInformation("Update");
            if (!ModelState.IsValid)
                return BadRequest(new BaseResponseDTO { IsSuccess = false, Errors = ModelState.Values.SelectMany(c => c.Errors.Select(c => c.ErrorMessage)).ToList() });

            var response = await _contactUsService.Update(contact);
            return Ok(new BaseResponseDTO { IsSuccess = true, Data = response });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Delete");
            var response = await _contactUsService.Delete(id);
            return Ok(new BaseResponseDTO { IsSuccess = true, Data = response });
        }
        [HttpPost]
        public async Task<IActionResult> Active(int id)
        {
            _logger.LogInformation("Active");
            var response = await _contactUsService.Active(id);
            return Ok(new BaseResponseDTO { IsSuccess = true, Data = response });
        }
        [HttpPost]
        public async Task<IActionResult> DisActive(int id)
        {
            _logger.LogInformation("DisActive");
            var response = await _contactUsService.DisActive(id);
            return Ok(new BaseResponseDTO { IsSuccess = true, Data = response });
        }
    }
}
