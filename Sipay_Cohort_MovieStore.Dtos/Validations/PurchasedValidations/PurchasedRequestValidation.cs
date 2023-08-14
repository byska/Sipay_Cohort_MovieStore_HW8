using FluentValidation;
using Sipay_Cohort_MovieStore.Dtos.Movie;
using Sipay_Cohort_MovieStore.Dtos.Purchased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Dtos.Validations.PurchasedValidations
{
    public class PurchasedRequestValidation : AbstractValidator<PurchasedRequest>
    {
        public PurchasedRequestValidation()
        {
            RuleFor(x => x.MovieId).NotNull().WithMessage("Movie field cannot be empty.").GreaterThan(0);
            RuleFor(x => x.CustomerId).NotNull().WithMessage("Customer field cannot be empty.").GreaterThan(0);
            RuleFor(x => x.Price).NotNull().WithMessage("Price field cannot be empty.").GreaterThan(0);
            RuleFor(x => x.CreatedDate).NotNull().WithMessage("Created Date field cannot be empty.");

        }
    }
}
