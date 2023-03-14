using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Caps;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Dtos.DummyUsers
{
    public class DummyUserResponseDto : DtoBase
    {
        public string Name { get; set; }

        public List<CapOverviewResponseDto> CapsCollection { get; set; }
        public List<CapOverviewResponseDto> LikedCaps { get; set; }
    }
}