using Imi.Project.Api.Wpf.ApiModels.Base;
using Imi.Project.Api.Wpf.ApiModels.Caps;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Imi.Project.Api.Wpf.Services.ApiService.Caps
{
    public class CapApiService : ICapApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CapApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(Constants.ApiConstants.ApiUrl);
        }

        private HttpClient _httpClient;

        public async Task<BaseapiResponse<IEnumerable<CapResponseModel>>> GetAllCaps()
        {
            var response = await _httpClient.GetAsync(Constants.ApiConstants.Caps);

            if (!response.IsSuccessStatusCode)
            {
                return new BaseapiResponse<IEnumerable<CapResponseModel>>();
            }

            var result = await response.Content.ReadFromJsonAsync<BaseapiResponse<IEnumerable<CapResponseModel>>>();
            return result;
        }

        public async Task DeleteCap(Guid id)
        {
            await _httpClient.DeleteAsync($"{Constants.ApiConstants.Caps}/{id}");
        }

        public async Task<CapDetailResponseModel> GetCap(Guid id)
        {
            var response = await _httpClient.GetAsync($"{Constants.ApiConstants.Caps}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new NullReferenceException($"Cap with ID {id} not found");
            }

            var result = await response.Content.ReadFromJsonAsync<CapDetailResponseModel>();

            return result;
        }
    }
}