using Refit;
using WebAPI.Integration.Response;

namespace WebAPI.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> GetDataViaCep(string cep);
    }
}
