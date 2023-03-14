using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Entities.Base;
using Imi.Project.Api.Core.Paging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services.Base
{
    public interface IBaseService<TResponseDto, TRequestDto, in TFilter, TEntity> : IBaseService<TResponseDto, TRequestDto, TFilter, TResponseDto, TEntity>
        where TResponseDto : DtoBase
        where TRequestDto : DtoBase
        where TFilter : PagingFilter
        where TEntity : EntityBase
    {
        new Task<PagedList<TResponseDto>> GetPagedAsync(TFilter filter);

        new Task<List<TResponseDto>> ListAllAsync();
    }

    public interface IBaseService<TResponseDto, TRequestDto, in TFilter, TOverviewDto, TEntity>
        where TResponseDto : DtoBase
        where TRequestDto : DtoBase
        where TFilter : PagingFilter
        where TOverviewDto : DtoBase
        where TEntity : EntityBase
    {
        Task<TResponseDto> GetByIdAsync(Guid id);

        Task<List<TOverviewDto>> ListAllAsync();

        Task<PagedList<TOverviewDto>> GetPagedAsync(TFilter filter);

        Task<TResponseDto> AddAsync(TRequestDto requestDto);

        Task<TResponseDto> UpdateAsync(TRequestDto requestDto);

        Task DeleteAsync(Guid id);
    }
}