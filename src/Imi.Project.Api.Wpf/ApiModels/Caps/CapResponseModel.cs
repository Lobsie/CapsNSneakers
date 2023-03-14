using Imi.Project.Api.Wpf.ApiModels.Base;
using Imi.Project.Api.Wpf.ApiModels.Brands;
using Imi.Project.Api.Wpf.ApiModels.Fittings;
using System;
using System.Text.Json.Serialization;

namespace Imi.Project.Api.Wpf.ApiModels.Caps
{
    public class CapResponseModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("brand")]
        public BrandRepsonseModel Brand { get; set; }

        [JsonPropertyName("fitting")]
        public FittingResponseModel Fitting { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Brand.Name} / {Fitting.Name})";
        }
    }
}