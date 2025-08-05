using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Orders.Commands
{
    public class CreateOrderValidator:AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.Order.Customer_ID)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage("Customer Id cannot be null or empty or 0 !!");
        }
    }
}
