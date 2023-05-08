using CustomersPortal.DataContracts_DTO;
using CustomersPortal.Entities;
using CustomersPortal.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
//using System.Web.Http.ModelBinding;
//using System.Web.Http;

namespace CustomersPortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository repository;
        private readonly ILogger<CustomersController> _logger;
        

        public CustomersController(ICustomerRepository repository, ILogger<CustomersController> logger)
        { 
            this.repository = repository;
            _logger = logger;
             
        }

        //GET/Customers
        [HttpGet]
        public IEnumerable<CustomersDTO> GetCustomers()
        {
            return repository.GetCustomers().Select(c => c.AsDto());
        }

        //GET/Customers/{id}
        [HttpGet("{Id}")]
        public ActionResult<CustomersDTO> GetCustomer(Guid Id)
        {
            var customer =  repository.GetCustomer(Id);

            if (customer is null)
            {
               return NotFound();
            }

            return customer.AsDto(); 
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<CustomersDTO> CreateCustomer(CreateCustomerDTO customerDTO)
        {
            Customer customer = new()
            {
                Id = Guid.NewGuid(),
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName,
                Email = customerDTO.Email,
                Mobile = customerDTO.Mobile,
                Gender = customerDTO.Gender,
                DateOfBirth = customerDTO.DateOfBirth,
                CreatedDate = DateTime.Now,
                Address = customerDTO.Address
            };

            repository.CreateCustomer(customer);

            return CreatedAtAction(nameof(GetCustomer), new { Id = customer.Id }, customer.AsDto());
        }

        //PUT/Customers/{Id}
        [HttpPut("{Id}")]
        public ActionResult UpdateCustomer(Guid Id, UpdateCustomerDTO customerDTO)
        {
            var customer = repository.GetCustomer(Id);

            if(customer is null)
            {
                return NotFound();
            }

            Customer updatedCustomer = customer with
            {
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName,
                Address = customerDTO.Address,
                DateOfBirth = customerDTO.DateOfBirth,
                Email = customerDTO.Email,
                Gender = customerDTO.Gender,
                Mobile = customerDTO.Mobile
            };

            repository.UpdateCustomer(updatedCustomer);
            return NoContent();
        }

        //DELETE/Customers/{id}
        [HttpDelete("{Id}")]
        public ActionResult DeleteCustomer(Guid Id)
        {
            var customer = repository.GetCustomer(Id);

            if (customer is null)
            {
                return NotFound();
            }

            repository.DeleteCustomer(Id);
            return NoContent();
        }


    }
}