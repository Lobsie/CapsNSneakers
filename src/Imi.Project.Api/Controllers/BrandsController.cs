using Imi.Project.Api.Core.Constants;
using Imi.Project.Api.Core.Dtos.Brands;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        /// <summary>
        /// Get all brands
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = CustomPolicies.CanRead)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync()
        {
            var brands = await _brandService.ListAllAsync();

            return Ok(brands);
        }

        /// <summary>
        /// Get a brand by id
        /// </summary>
        /// <param name="id">id of a brand</param>"
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Policy = CustomPolicies.CanRead)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var brand = await _brandService.GetByIdAsync(id);

            if (brand is null)
                return NotFound($"Brand with id: {id} was not found.");

            return Ok(brand);
        }

        /// <summary>
        /// Gets all brands paged
        /// </summary>
        /// <param name="filter">Optional filtering</param>
        /// <returns></returns>
        [HttpGet("overview")]
        [Authorize(Policy = CustomPolicies.CanRead)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagedList<BrandResponseDto>>> GetOverviewAsync([FromQuery] PagingFilter filter)
        {
            var brands = await _brandService.GetPagedAsync(filter);

            return Ok(brands);
        }

        /// <summary>
        /// Gets a brand with its caps
        /// </summary>
        /// <param name="id">id of the brand</param>
        /// <returns></returns>
        [HttpGet("{id}/overview")]
        [Authorize(Policy = CustomPolicies.CanRead)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BrandWithCapsResponseDto>> GetBrandWithCapsAsync(Guid id)
        {
            var brand = await _brandService.GetBrandWithCapsAsync(id);

            if (brand is null)
                return NotFound($"Brand with ID {id} was not found.");

            return Ok(brand);
        }

        /// <summary>
        /// Adds a new brand
        /// </summary>
        /// <param name="brandRequestDto">Values for a new brand</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = CustomPolicies.CanCreate)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> PostAsync(BrandRequestDto brandRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var brand = await _brandService.AddAsync(brandRequestDto);

            return CreatedAtAction(nameof(PostAsync), new { id = brand.Id }, brand);
        }

        /// <summary>
        /// Edits a new brand
        /// </summary>
        /// <param name="brandRequestDto">New values for a new brand</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Policy = CustomPolicies.CanEdit)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(BrandRequestDto brandRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var brand = await _brandService.UpdateAsync(brandRequestDto);

            return Ok(brand);
        }

        /// <summary>
        /// Deletes a brand
        /// </summary>
        /// <param name="id">Id of the brand you want to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = CustomPolicies.CanDelete)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var brand = await _brandService.GetByIdAsync(id);

            if (brand is null)
                return NotFound($"The brand with ID {id} was not found");

            await _brandService.DeleteAsync(id);

            return NoContent();
        }
    }
}