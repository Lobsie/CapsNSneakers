using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Paging;
using Imi.Project.Api.Infrastructure.Data;
using Imi.Project.Api.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class CapRepository : EfRepository<Cap, PagingFilter>, ICapRepository
    {
        public CapRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Cap> GetAllAsync()
        {
            var caps = _dbContext.Caps
                .Include(x => x.Brand)
                .Include(x => x.Fitting)
                .Include(x => x.Users)
                .Include(x => x.LikedByUsers)
                .AsQueryable();

            return caps;
        }

        public override async Task<Cap> GetByIdAsync(Guid id)
        {
            var entity = await _dbContext.Caps
                .Include(x => x.Brand)
                .Include(x => x.Fitting)
                .Include(x => x.Users)
                .Include(x => x.LikedByUsers)
                .SingleOrDefaultAsync(x => x.Id == id);

            return entity;
        }
    }
}