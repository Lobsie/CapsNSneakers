using Imi.Project.Api.Core.Constants;
using Imi.Project.Api.Core.Dtos.Fittings;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FittingsController : ControllerBase
    {
        private readonly IFittingService _fittingService;

        public FittingsController(IFittingService fittingService)
        {
            _fittingService = fittingService;
        }

        /// <summary>
        /// Get all fittings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = CustomPolicies.CanRead)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync()
        {
            var fittings = await _fittingService.ListAllAsync();

            return Ok(fittings);
        }

        /// <summary>
        /// Get a fitting by id
        /// </summary>
        /// <param name="id">id of a fitting</param>"
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Policy = CustomPolicies.CanRead)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var fitting = await _fittingService.GetByIdAsync(id);

            if (fitting is null)
                return NotFound($"fitting with id: {id} was not found.");

            return Ok(fitting);
        }

        /// <summary>
        /// Gets all fittings paged
        /// </summary>
        /// <param name="filter">Optional filtering</param>
        /// <returns></returns>
        [HttpGet("overview")]
        [Authorize(Policy = CustomPolicies.CanRead)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagedList<FittingResponseDto>>> GetOverviewAsync([FromQuery] PagingFilter filter)
        {
            var fittings = await _fittingService.GetPagedAsync(filter);

            return Ok(fittings);
        }

        /// <summary>
        /// Gets a fitting with its caps
        /// </summary>
        /// <param name="id">id of the fitting</param>
        /// <returns></returns>
        [HttpGet("{id}/overview")]
        [Authorize(Policy = CustomPolicies.CanRead)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FittingWithCapsResponseDto>> GetFittingWithCapsAsync(Guid id)
        {
            var fitting = await _fittingService.GetFittingWithCapsAsync(id);

            if (fitting is null)
                return NotFound($"Fitting with ID {id} was not found.");

            return Ok(fitting);
        }

        /// <summary>
        /// Adds a new fitting
        /// </summary>
        /// <param name="fittingRequestDto">Values for a new fitting</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = CustomPolicies.CanCreate)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> PostAsync(FittingRequestDto fittingRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var fitting = await _fittingService.AddAsync(fittingRequestDto);

            return CreatedAtAction(nameof(PostAsync), new { id = fitting.Id }, fitting);
        }

        /// <summary>
        /// Edits a new fitting
        /// </summary>
        /// <param name="fittingRequestDto">New values for a new fitting</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Policy = CustomPolicies.CanEdit)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(FittingRequestDto fittingRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var fitting = await _fittingService.UpdateAsync(fittingRequestDto);

            return Ok(fitting);
        }

        /// <summary>
        /// Deletes a fitting
        /// </summary>
        /// <param name="id">Id of the fitting you want to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = CustomPolicies.CanDelete)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var fitting = await _fittingService.GetByIdAsync(id);

            if (fitting is null)
                return NotFound($"The fitting with ID {id} was not found");

            await _fittingService.DeleteAsync(id);

            return NoContent();
        }
    }
}