using AutoMapper;
using Imi.Project.Api.Core.Dtos.Brands;
using Imi.Project.Api.Core.Dtos.Caps;
using Imi.Project.Api.Core.Dtos.DummyUsers;
using Imi.Project.Api.Core.Dtos.Fittings;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            MapBrands();
            MapFittings();
            MapCaps();
        }

        private void MapBrands()
        {
            // Map entity to dto
            CreateMap<Brand, BrandResponseDto>();

            // Map Dto to Entity
            CreateMap<BrandRequestDto, Brand>();
        }

        private void MapFittings()
        {
            // Map entity to dto
            CreateMap<Fitting, FittingResponseDto>();

            // Map Dto to Entity
            CreateMap<FittingRequestDto, Fitting>();
        }

        private void MapCaps()
        {
            // Map entity to dto
            CreateMap<Cap, CapResponseDto>()
                .ForMember(dest => dest.OwnedByCount, opt => opt.MapFrom(src => src.Users.Count))
                .ForMember(dest => dest.LikedByCount, opt => opt.MapFrom(src => src.LikedByUsers.Count));
            CreateMap<Cap, CapOverviewResponseDto>();

            // Map Dto to Entity
            CreateMap<CapRequestDto, Cap>();
        }
    }
}