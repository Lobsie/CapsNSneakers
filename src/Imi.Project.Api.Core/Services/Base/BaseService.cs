using AutoMapper;
using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Entities.Base;
using Imi.Project.Api.Core.Interfaces.Repositories.Base;
using Imi.Project.Api.Core.Interfaces.Services.Base;
using Imi.Project.Api.Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services.Base
{
    public abstract class BaseService<TResponseDto, TRequestDto, TFilter, TEntity> : BaseService<TResponseDto, TRequestDto, TFilter, TResponseDto, TEntity>, IBaseService<TResponseDto, TRequestDto, TFilter, TEntity>
        where TResponseDto : DtoBase
        where TRequestDto : DtoBase
        where TFilter : PagingFilter
        where TEntity : EntityBase
    {
        protected BaseService(IMapper mapper, IRepository<TEntity, TFilter> repository) : base(mapper, repository)
        {
        }

        public new async Task<PagedList<TResponseDto>> GetPagedAsync(TFilter filter)
        {
            return await base.GetPagedAsync(filter);
        }

        public new async Task<List<TResponseDto>> ListAllAsync()
        {
            return await base.ListAllAsync();
        }
    }

    public abstract class BaseService<TResponseDto, TRequestDto, TFilter, TOverviewDto, TEntity> : IBaseService<TResponseDto, TRequestDto, TFilter, TOverviewDto, TEntity>
        where TResponseDto : DtoBase
        where TRequestDto : DtoBase
        where TFilter : PagingFilter
        where TOverviewDto : DtoBase
        where TEntity : EntityBase
    {
        protected IMapper _mapper;
        protected IRepository<TEntity, TFilter> _repository;

        protected BaseService(IMapper mapper, IRepository<TEntity, TFilter> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task<List<TOverviewDto>> ListAllAsync()
        {
            var entities = await _repository.ListAllAsync();

            var dtos = _mapper.Map<List<TOverviewDto>>(entities);

            return dtos;
        }

        public virtual async Task<PagedList<TOverviewDto>> GetPagedAsync(TFilter filter)
        {
            var entities = await _repository.ListAllAsync();

            var dtos = _mapper.Map<IEnumerable<TOverviewDto>>(entities).ToList();

            var pagedList = PagedList<TOverviewDto>.ToPagedList(dtos, filter.PageNumber, filter.PageSize);

            return pagedList;
        }

        public virtual async Task<TResponseDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            var dto = _mapper.Map<TResponseDto>(entity);

            return dto;
        }

        public virtual async Task<TResponseDto> AddAsync(TRequestDto requestDto)
        {
            var entity = _mapper.Map<TEntity>(requestDto);

            var result = await _repository.AddAsync(entity);

            var dto = _mapper.Map<TResponseDto>(result);

            return dto;
        }

        public virtual async Task<TResponseDto> UpdateAsync(TRequestDto requestDto)
        {
            var entity = _mapper.Map<TEntity>(requestDto);

            var result = await _repository.UpdateAsync(entity);

            var dto = _mapper.Map<TResponseDto>(result);

            return dto;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}