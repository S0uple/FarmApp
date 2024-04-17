using Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Animals Controller
    /// </summary>
    /// <param name="mediator"></param>
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController(IMediator mediator)
    {
        /// <summary>
        /// Get all animals
        /// </summary>
        /// <returns>List of animals</returns>
        [HttpGet]
        public async Task<ActionResult<List<AnimalModel>>> Get(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAnimalsQuery(), cancellationToken);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Create an animal
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Create([FromForm]CreateAnimalCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
            return new OkResult();
        }

        /// <summary>
        /// Delete an animal
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteAnimalCommand { Id = id }, cancellationToken);
            return new OkResult();
        }

        /// <summary>
        /// Check if animal name is unique
        /// </summary>
        /// <returns>True if name is unique, false otherwise</returns>
        [HttpGet("checkIfNameIsUnique")]
        public async Task<ActionResult<bool>> CheckIfNameIsUnique([FromQuery]CheckAnimalNameQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return new OkObjectResult(result);
        }
    }
}
