using AutoMapper;
using Imi.Project.Api.Core.Dtos.Brands;
using Imi.Project.Api.Core.Dtos.Caps;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Paging;
using Imi.Project.Api.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class BrandService : BaseService<BrandResponseDto, BrandRequestDto, PagingFilter, Brand>, IBrandService
    {
        private readonly ICapService _capService;

        public BrandService(IMapper mapper, IBrandRepository repository, ICapService capService) : base(mapper, repository)
        {
            _capService = capService;
        }

        public async Task<BrandWithCapsResponseDto> GetBrandWithCapsAsync(Guid id)
        {
            var brand = await GetByIdAsync(id);

            if (brand is null)
                throw new NullReferenceException("Brand not found");

            var caps = await _capService.ListAllAsync();

            caps = caps.Where(x => x.Brand.Id == id).ToList();

            if (!caps.Any())
                caps = new List<CapOverviewResponseDto>();

            var brandWithCaps = new BrandWithCapsResponseDto()
            {
                Brand = brand,
                Caps = caps
            };

            return brandWithCaps;
        }
    }
}