using FluentValidation;
using Sipay_Cohort_MovieStore.Dtos.Customer;
using Sipay_Cohort_MovieStore.Dtos.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Dtos.Validations.DirectorValidations
{
    public class DirectorRequestValidation : AbstractValidator<DirectorRequest>
    {
        public DirectorRequestValidation()
        {
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Name field cannot be empty.").MaximumLength(75).WithMessage("The name is too long.").MinimumLength(3).WithMessage("The name is too short.");
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Lastname field cannot be empty.").MaximumLength(75).WithMessage("The lastname is too long.").MinimumLength(3).WithMessage("The lastname is too short.");
        }
    }
}
