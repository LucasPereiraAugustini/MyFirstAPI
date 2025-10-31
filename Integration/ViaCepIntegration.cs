using WebAPI.Integration.Interfaces;
using WebAPI.Integration.Refit;
using WebAPI.Integration.Response;

namespace WebAPI.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }
        
        public async Task<ViaCepResponse> GetDataViaCep(string cep)
        {
            var respondeData = await _viaCepIntegrationRefit.GetDataViaCep(cep);

            if (respondeData != null && respondeData.IsSuccessStatusCode)
            {
                return respondeData.Content;
            }

            return null;
        }
    }
}
