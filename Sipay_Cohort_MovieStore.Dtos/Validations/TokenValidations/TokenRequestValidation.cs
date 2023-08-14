using FluentValidation;
using Sipay_Cohort_MovieStore.Dtos.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Dtos.Validations.TokenValidations
{
    public class TokenRequestValidation :AbstractValidator<TokenRequest>
    {
        public TokenRequestValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email field cannot be empty.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field cannot be empty.");
        }
    }
}
