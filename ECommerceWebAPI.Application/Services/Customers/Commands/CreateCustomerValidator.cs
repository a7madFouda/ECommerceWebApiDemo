using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Customers.Commands
{
    public class CreateCustomerValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.customer.Name)
                .NotEmpty().WithMessage("Customer name cannot be empty!!");
            RuleFor(x => x.customer.Email)
                .NotNull().WithMessage("Customer Email cannot be empty!!");
            RuleFor(x => x.customer.Email)
                .EmailAddress().WithMessage("Customer Email should in valid format!!");
        }
    }
}
