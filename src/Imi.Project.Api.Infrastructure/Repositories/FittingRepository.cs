using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Paging;
using Imi.Project.Api.Infrastructure.Data;
using Imi.Project.Api.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class FittingRepository : EfRepository<Fitting, PagingFilter>, IFittingRepository
    {
        public FittingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Fitting> GetByIdAsync(Guid id)
        {
            var entity = await _dbContext.Fittings
                .Include(x => x.Caps)
                .SingleOrDefaultAsync(x => x.Id == id);

            return entity;
        }
    }
}