using System;
using System.Text.Json.Serialization;

namespace Imi.Project.Api.Wpf.ApiModels.Brands
{
    public class BrandRepsonseModel : BaseResponseModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}