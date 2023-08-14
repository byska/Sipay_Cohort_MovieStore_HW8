using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sipay_Cohort_MovieStore.Business.Services.Token;
using Sipay_Cohort_MovieStore.Core.JWT;
using Sipay_Cohort_MovieStore.Core.Utilities.Response;
using Sipay_Cohort_MovieStore.DataAccess.UnitOfWork;
using Sipay_Cohort_MovieStore.Dtos.Token;
using Sipay_Cohort_MovieStore.Entities.DbSets;
using Sipay_Cohort_MovieStorel.Dtos.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sipay_Final.Business.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IUow _uow;
        private readonly JwtConfig _jwtConfig;
        private readonly IValidator<TokenRequest> _validator;
        public TokenService(IUow uow, IOptionsMonitor<JwtConfig> jwtConfig,IValidator<TokenRequest> validator)
        {
            _uow = uow;
            _jwtConfig = jwtConfig.CurrentValue;
            _validator = validator;
        }

        public async Task<ApiResponse<TokenResponse>> Login(TokenRequest request)
        {
            var result = _validator.Validate(request);
            if(result.IsValid)
            {
                if (request is null)
                {
                    return new ApiResponse<TokenResponse>("Request was null");
                }
                if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                {
                    return new ApiResponse<TokenResponse>("Request was null");
                }

                request.Email = request.Email.Trim().ToLower();
                request.Password = request.Password.Trim();

                var user = await _uow.GetRepository<Customer>().GetByDefault(x => x.Email.Equals(request.Email));

                if (user is null)
                {
                    return new ApiResponse<TokenResponse>("Invalid user informations");
                }

                if (user.Password.ToLower() != request.Password.ToLower())
                {

                    return new ApiResponse<TokenResponse>("Invalid user informations");
                }

                string token = Token(user);

                TokenResponse response = new()
                {
                    AccessToken = token,
                    ExpireTime = DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                    Email = user.Email
                };

                return new ApiResponse<TokenResponse>(response);
            }
            return new ApiResponse<TokenResponse>(false);
        }
        private string Token(Customer user)
        {
            Claim[] claims = GetClaims(user);
            var secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var jwtToken = new JwtSecurityToken(
               issuer: _jwtConfig.Issuer,
               audience: _jwtConfig.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration),
               signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
                );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }


        private Claim[] GetClaims(Customer user)
        {

            var claims = new[]
            {
            new Claim("Email",user.Email),
            new Claim("Id",user.Id.ToString()),
            new Claim("Role","Customer"),
            new Claim(ClaimTypes.Role,"Customer")
            };

            return claims;
        }
    }
}
