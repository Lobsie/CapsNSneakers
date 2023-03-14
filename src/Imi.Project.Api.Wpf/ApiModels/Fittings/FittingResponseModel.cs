using System;
using System.Text.Json.Serialization;

namespace Imi.Project.Api.Wpf.ApiModels.Fittings
{
    public class FittingResponseModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}