using AutoMapper;
using Imi.Project.Api.Core.Dtos.Caps;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Paging;
using Imi.Project.Api.Core.Services.Base;

namespace Imi.Project.Api.Core.Services
{
    public class CapService : BaseService<CapResponseDto, CapRequestDto, PagingFilter, CapOverviewResponseDto, Cap>, ICapService
    {
        public CapService(IMapper mapper, ICapRepository repository) : base(mapper, repository)
        {
        }
    }
}