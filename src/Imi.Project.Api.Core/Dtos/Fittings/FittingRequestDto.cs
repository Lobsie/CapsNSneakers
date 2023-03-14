using Imi.Project.Api.Core.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Dtos.Fittings
{
    public class FittingRequestDto : DtoBase
    {
        [Required(ErrorMessage = "What kind of fitting is it?")]
        public string Name { get; set; }
    }
}