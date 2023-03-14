using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories.Base;
using Imi.Project.Api.Core.Paging;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IFittingRepository : IRepository<Fitting, PagingFilter>
    {
    }
}