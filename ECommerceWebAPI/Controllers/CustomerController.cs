using ECommerceWebAPI.Application.Services.Customers.Commands;
using ECommerceWebAPI.Application.Services.Customers.DTOs;
using ECommerceWebAPI.Application.Services.Customers.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMediator _mediator;

        public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id, [FromServices] IValidator<GetCustomerQuery> validator)
        {
            var query = new GetCustomerQuery { Id = id };

            var validationResult = await validator.ValidateAsync(query);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            var customer = await _mediator.Send(new GetCustomerQuery() { Id = id });
            if (customer == null)
            {
                return NotFound("No customer exists with this id");
            }
            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var customers = await _mediator.Send(new GetCustomerListQuery());
            if (customers == null || !customers.Any())
            {
                return NotFound("No customer exists");
            }
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] CreateCustomerDTO customerDTO)
        {
            try
            {
                var customer = await _mediator.Send(new CreateCustomerCommand() { customer = customerDTO });
                if (customer == null)
                {
                    return StatusCode(500, "An error occurred while saving the entity.");
                }
                return StatusCode(201, customer);
            }
            catch(ValidationException ex)
            {
                return BadRequest(new
                {
                    Message = "Validation failed.",
                    Errors = ex.Errors.Select(e => new { e.ErrorMessage })
                });
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
