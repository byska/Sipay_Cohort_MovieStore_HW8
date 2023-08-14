using Sipay_Cohort_MovieStore.Core.Utilities.Response;
using Sipay_Cohort_MovieStore.Dtos.Token;
using Sipay_Cohort_MovieStorel.Dtos.Token;

namespace Sipay_Cohort_MovieStore.Business.Services.Token
{
    public interface ITokenService
    {
        Task<ApiResponse<TokenResponse>> Login(TokenRequest request);
    }
}
