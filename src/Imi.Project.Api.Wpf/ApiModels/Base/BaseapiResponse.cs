using System.Text.Json.Serialization;

namespace Imi.Project.Api.Wpf.ApiModels.Base
{
    public class BaseapiResponse<T>
    {
        [JsonPropertyName("$values")]
        public T Data { get; set; }
    }
}