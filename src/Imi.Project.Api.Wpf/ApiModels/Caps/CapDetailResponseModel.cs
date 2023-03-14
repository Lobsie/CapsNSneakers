using Imi.Project.Api.Wpf.ApiModels.Brands;
using Imi.Project.Api.Wpf.ApiModels.Fittings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Imi.Project.Api.Wpf.ApiModels.Caps
{
    public class CapDetailResponseModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("material")]
        public string Material { get; set; }

        [JsonPropertyName("colorway")]
        public string Colorway { get; set; }

        [JsonPropertyName("brand")]
        public BrandRepsonseModel Brand { get; set; }

        [JsonPropertyName("fitting")]
        public FittingResponseModel Fitting { get; set; }

        [JsonPropertyName("ownedByCount")]
        public int OwnedByCount { get; set; }

        [JsonPropertyName("likedByCount")]
        public int LikedByCount { get; set; }
    }
}
