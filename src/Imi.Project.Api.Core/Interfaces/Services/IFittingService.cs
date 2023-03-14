using Imi.Project.Api.Core.Dtos.Fittings;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services.Base;
using Imi.Project.Api.Core.Paging;
using System;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IFittingService : IBaseService<FittingResponseDto, FittingRequestDto, PagingFilter, Fitting>
    {
        Task<FittingWithCapsResponseDto> GetFittingWithCapsAsync(Guid id);
    }
}