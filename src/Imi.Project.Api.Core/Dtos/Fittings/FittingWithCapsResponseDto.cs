using Imi.Project.Api.Core.Dtos.Caps;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Dtos.Fittings
{
    public class FittingWithCapsResponseDto
    {
        public FittingResponseDto Fitting { get; set; }
        public List<CapOverviewResponseDto> Caps { get; set; }
    }
}