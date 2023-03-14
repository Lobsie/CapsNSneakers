using AutoMapper;
using Imi.Project.Api.Core.Dtos.Caps;
using Imi.Project.Api.Core.Dtos.Fittings;
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
    public class FittingService : BaseService<FittingResponseDto, FittingRequestDto, PagingFilter, Fitting>, IFittingService
    {
        private readonly ICapService _capService;

        public FittingService(IMapper mapper, IFittingRepository repository, ICapService capService) : base(mapper, repository)
        {
            _capService = capService;
        }

        public async Task<FittingWithCapsResponseDto> GetFittingWithCapsAsync(Guid id)
        {
            var fitting = await GetByIdAsync(id);

            if (fitting is null)
                throw new NullReferenceException("Fitting not found");

            var caps = await _capService.ListAllAsync();

            caps = caps.Where(x => x.Fitting.Id == id).ToList();

            if (!caps.Any())
                caps = new List<CapOverviewResponseDto>();

            var fittingWithCaps = new FittingWithCapsResponseDto()
            {
                Fitting = fitting,
                Caps = caps
            };

            return fittingWithCaps;
        }
    }
}