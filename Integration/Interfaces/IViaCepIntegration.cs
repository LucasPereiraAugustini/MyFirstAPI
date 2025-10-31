using WebAPI.Integration.Response;

namespace WebAPI.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> GetDataViaCep(string cep);
    }
}
