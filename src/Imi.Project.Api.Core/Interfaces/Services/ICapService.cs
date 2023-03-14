using Imi.Project.Api.Core.Dtos.Caps;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services.Base;
using Imi.Project.Api.Core.Paging;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ICapService : IBaseService<CapResponseDto, CapRequestDto, PagingFilter, CapOverviewResponseDto, Cap>
    {
    }
}