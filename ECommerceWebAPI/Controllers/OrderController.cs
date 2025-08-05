using ECommerceWebAPI.Application.Services.Customers.Commands;
using ECommerceWebAPI.Application.Services.Customers.DTOs;
using ECommerceWebAPI.Application.Services.Customers.Queries;
using ECommerceWebAPI.Application.Services.Orders.Commands;
using ECommerceWebAPI.Application.Services.Orders.DTOs;
using ECommerceWebAPI.Application.Services.Orders.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id, [FromServices] IValidator<GetOrderQuery> validator)
        {
            var query = new GetOrderQuery { Id = id };

            var validationResult = await validator.ValidateAsync(query);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            var order = await _mediator.Send(new GetOrderQuery() { Id = id });
            if (order == null)
            {
                return NotFound("No order exists with this id");
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] CreateOrderDTO orderDTO)
        {
            try
            {
                var order = await _mediator.Send(new CreateOrderCommand() { Order = orderDTO });
                if (order == null)
                {
                    return StatusCode(500, "An error occurred while saving the entity.");
                }
                return StatusCode(201, order);
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

        [HttpPost("update-order-status/{id}")]
        public async Task<ActionResult> UpdateOrderStatus([FromRoute] int id)
        {
            try
            {
                var order = await _mediator.Send(new UpdateOrderCommand() { Id = id });

                return StatusCode(201, order);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new
                {
                    Message = "Validation failed.",
                    Errors = ex.Errors.Select(e => new { e.ErrorMessage })
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
