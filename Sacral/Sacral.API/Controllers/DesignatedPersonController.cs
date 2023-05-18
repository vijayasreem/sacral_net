using Microsoft.AspNetCore.Mvc;
using Sacral.DTO;
using Sacral.Service;
using System.Threading.Tasks;

namespace Sacral.API
{
    [Route("/api/[controller]")]
    [ApiController]
    public class DesignatedPersonController : ControllerBase
    {
        private readonly DesignatedPersonService _designatedPersonService;

        public DesignatedPersonController(DesignatedPersonService designatedPersonService)
        {
            _designatedPersonService = designatedPersonService;
        }

        [HttpPost]
        public async Task<ActionResult<DesignatedPersonModel>> CreateDesignatedPersonAsync([FromBody] DesignatedPersonModel model)
        {
            var result = await _designatedPersonService.CreateDesignatedPersonAsync(model);

            if (result == null)
            {
                return BadRequest("Unable to create designated person");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DesignatedPersonModel>> GetDesignatedPersonAsync(int id)
        {
            var result = await _designatedPersonService.GetDesignatedPersonAsync(id);

            if (result == null)
            {
                return NotFound("Designated person not found");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<DesignatedPersonModel>> UpdateDesignatedPersonAsync([FromBody] DesignatedPersonModel model)
        {
            var result = await _designatedPersonService.UpdateDesignatedPersonAsync(model);

            if (result == null)
            {
                return BadRequest("Unable to update designated person");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDesignatedPersonAsync(int id)
        {
            await _designatedPersonService.DeleteDesignatedPersonAsync(id);

            return Ok();
        }
    }
}