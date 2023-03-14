using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Brands;
using Imi.Project.Api.Core.Dtos.Fittings;

namespace Imi.Project.Api.Core.Dtos.Caps
{
    public class CapOverviewResponseDto : DtoBase
    {
        public string Name { get; set; }
        public BrandResponseDto Brand { get; set; }
        public FittingResponseDto Fitting { get; set; }
    }
}