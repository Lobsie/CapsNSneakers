using Imi.Project.Api.Core.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Dtos.Brands
{
    public class BrandRequestDto : DtoBase
    {
        [Required(ErrorMessage = "You must give your brand a name.")]
        public string Name { get; set; }
    }
}