using FluentValidation;
using Sipay_Cohort_MovieStore.Dtos.Director;
using Sipay_Cohort_MovieStore.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Dtos.Validations.MovieValidations
{
    public class MovieRequestValidation : AbstractValidator<MovieRequest>
    {
        public MovieRequestValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field cannot be empty.").MaximumLength(75).WithMessage("The name is too long.").MinimumLength(3).WithMessage("The name is too short.");
            RuleFor(x => x.Year).NotEqual(0).WithMessage("Year field cannot be empty.").LessThan(2023).WithMessage("You cannot give a future date.");
            RuleFor(x => x.Genre).NotNull().WithMessage("Genre field cannot be empty.");
            RuleFor(x => x.Price).NotNull().WithMessage("Price field cannot be empty.").GreaterThan(0);
            RuleFor(x => x.DirectorId).NotNull().WithMessage("Director field cannot be empty.").GreaterThan(0);
            RuleFor(x => x.CustomerId).NotNull().WithMessage("Customer field cannot be empty.").GreaterThan(0);
        }
    }
}
