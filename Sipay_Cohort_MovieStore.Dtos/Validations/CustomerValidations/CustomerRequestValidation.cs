using FluentValidation;
using Sipay_Cohort_MovieStore.Dtos.Actor;
using Sipay_Cohort_MovieStore.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Dtos.Validations.CustomerValidations
{
    public class CustomerRequestValidation : AbstractValidator<CustomerRequest>
    {
        public CustomerRequestValidation()
        {
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Name field cannot be empty.").MaximumLength(75).WithMessage("The name is too long.").MinimumLength(3).WithMessage("The name is too short.");
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Lastname field cannot be empty.").MaximumLength(75).WithMessage("The lastname is too long.").MinimumLength(3).WithMessage("The lastname is too short.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email field cannot be empty.").MaximumLength(75).WithMessage("The email is too long.").MinimumLength(3).WithMessage("The email is too short.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field cannot be empty.").MaximumLength(50).WithMessage("The password is too long.").MinimumLength(8).WithMessage("The password is too short.");
        }
    }
}
