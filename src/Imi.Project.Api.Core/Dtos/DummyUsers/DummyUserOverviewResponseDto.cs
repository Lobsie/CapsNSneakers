using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api.Core.Dtos.DummyUsers
{
    public class DummyUserOverviewResponseDto : DtoBase
    {
        public string Name { get; set; }
        public int OwnedCapsCount { get; set; }
        public int LikedCapsCount { get; set; }
    }
}