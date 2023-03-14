using Imi.Project.Api.Core.Dtos.Caps;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Dtos.Brands
{
    public class BrandWithCapsResponseDto
    {
        public BrandResponseDto Brand { get; set; }
        public List<CapOverviewResponseDto> Caps { get; set; }
    }
}