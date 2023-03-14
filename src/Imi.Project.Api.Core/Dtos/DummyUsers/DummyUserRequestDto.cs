using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Caps;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Dtos.DummyUsers
{
    public class DummyUserRequestDto : DtoBase
    {
        [Required(ErrorMessage = "You have to have a name!?")]
        public string Name { get; set; }

        public List<CapOverviewResponseDto> CapsCollection { get; set; }
        public List<CapOverviewResponseDto> LikedCaps { get; set; }
    }
}