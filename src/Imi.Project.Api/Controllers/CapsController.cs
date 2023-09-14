using Imi.Project.Api.Core.Constants;
using Imi.Project.Api.Core.Dtos.Caps;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapsController : ControllerBase
    {
        private readonly ICapService _capService;
        private readonly IBrandService _brandService;
        private readonly IFittingService _fittingService;

        public CapsController(ICapService capService, IBrandService brandService, IFittingService fittingService)
        {
            _capService = capService;
            _brandService = brandService;
            _fittingService = fittingService;
        }

        /// <summary>
        /// Get all caps
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = CustomPolicies.CanRead)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync()
        {
            var caps = await _capService.ListAllAsync();

            return Ok(caps);
        }

        /// <summary>
        /// Get a cap by id
        /// </summary>
        /// <param name="id">id of a cap</param>"
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Policy = CustomPolicies.CanRead)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var cap = await _capService.GetByIdAsync(id);

            if (cap is null)
                return NotFound($"Cap with ID {id} was not found.");

            return Ok(cap);
        }

        /// <summary>
        /// Gets all caps paged
        /// </summary>
        /// <param name="filter">Optional filtering</param>
        /// <returns />
        [HttpGet("overview")]
        [Authorize(Policy = CustomPolicies.CanRead)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagedList<CapOverviewResponseDto>>> GetOverviewAsync([FromQuery] PagingFilter filter)
        {
            var caps = await _capService.GetPagedAsync(filter);

            return Ok(caps);
        }

        /// <summary>
        /// Adds a new cap
        /// </summary>
        /// <param name="capRequestDto">Values for a new cap</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = CustomPolicies.CanCreate)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> PostAsync(CapRequestDto capRequestDto)
        {
            var brandId = capRequestDto.BrandId;
            var fittingId = capRequestDto.FittingId;

            var brand = await _brandService.GetByIdAsync(brandId);
            var fitting = await _fittingService.GetByIdAsync(fittingId);

            if (brand is null)
                return BadRequest($"The brand with ID: {capRequestDto.BrandId}, was not found!");

            if (fitting is null)
                return BadRequest($"The fitting with ID: {fittingId}, was not found!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var cap = await _capService.AddAsync(capRequestDto);

            return CreatedAtAction(nameof(PostAsync), new { id = cap.Id }, cap);
        }

        /// <summary>
        /// Edits a new cap
        /// </summary>
        /// <param name="capRequestDto">New values for a cap</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Policy = CustomPolicies.CanEdit)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(CapRequestDto capRequestDto)
        {
            var brandId = capRequestDto.BrandId;
            var fittingId = capRequestDto.FittingId;

            var brand = await _brandService.GetByIdAsync(brandId);
            var fitting = await _fittingService.GetByIdAsync(fittingId);

            if (brand is null)
                return BadRequest($"The brand with ID: {capRequestDto.BrandId}, was not found!");

            if (fitting is null)
                return BadRequest($"The fitting with ID: {fittingId}, was not found!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var cap = await _capService.UpdateAsync(capRequestDto);

            return Ok(cap);
        }

        /// <summary>
        /// Deletes a cap
        /// </summary>
        /// <param name="id">Id of the cap you want to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = CustomPolicies.CanDelete)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var cap = await _capService.GetByIdAsync(id);

            if (cap is null)
                return NotFound($"The cap with ID {id} was not found");

            await _capService.DeleteAsync(id);

            return NoContent();
        }
    }
}