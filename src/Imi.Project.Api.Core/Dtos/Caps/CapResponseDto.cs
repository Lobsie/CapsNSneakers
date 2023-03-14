using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Brands;
using Imi.Project.Api.Core.Dtos.Fittings;

namespace Imi.Project.Api.Core.Dtos.Caps
{
    public class CapResponseDto : DtoBase
    {
        public string Name { get; set; }
        public string Material { get; set; }
        public string Colorway { get; set; }

        public BrandResponseDto Brand { get; set; }
        public FittingResponseDto Fitting { get; set; }
        public int OwnedByCount { get; set; }
        public int LikedByCount { get; set; }
    }
}