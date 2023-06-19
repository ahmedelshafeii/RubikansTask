using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository,IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        [HttpGet("customers")]
        public async Task<ActionResult<List<CustomerDTO>>> getCustomers()
        {

            List<defCustomer> customers = await _customerRepository.getAllCustomers();
            if (customers.Count <= 0)
            {
                return Ok("No Customers Available");
            }
            else
            {
                return Ok(_mapper.Map<List<CustomerDTO>>(customers));
            }
        }

        [HttpGet("Customer")]
        public  IActionResult getCustomer(int id)
        {
            return Ok(_customerRepository.getCustomer(id));
        }

        [HttpPost("CreateCustomer")]
        public async Task<ActionResult> createCustomer(CustomerDTO customerDTO)
        {
            defCustomer customer = _mapper.Map<defCustomer>(customerDTO);
            await _customerRepository.createCustomer(customer);
            return CreatedAtAction("getCustomer", new { id = customer.CustomerID }, customer);
        }

    }
}
