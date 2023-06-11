using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Common;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var result = _customerRepository.Get();
            return new JsonResult(new
            {
                result
            });
        }

        [HttpPost]
        public IActionResult PostCustomer(AddCustomerDto req)
        {
            var result = _customerRepository.Add(req);
            return new JsonResult(new
            {
                result
            });
        }

        [HttpPut]
        public IActionResult PutCustomer(EditCustomerDto req)
        {
            var result = _customerRepository.Edit(req);
            return new JsonResult(new
            {
                result
            });
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var result = _customerRepository.Delete(id);
            return new JsonResult(new
            {
                result
            });
        }

    }
}
