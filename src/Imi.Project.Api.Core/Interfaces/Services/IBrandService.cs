using Imi.Project.Api.Core.Dtos.Brands;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services.Base;
using Imi.Project.Api.Core.Paging;
using System;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IBrandService : IBaseService<BrandResponseDto, BrandRequestDto, PagingFilter, Brand>
    {
        Task<BrandWithCapsResponseDto> GetBrandWithCapsAsync(Guid id);
    }
}