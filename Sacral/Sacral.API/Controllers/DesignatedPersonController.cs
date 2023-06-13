using Microsoft.AspNetCore.Mvc;
using Sacral.DTO;
using Sacral.Service;
using System.Threading.Tasks;

namespace Sacral.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignatedPersonController : ControllerBase
    {
        private readonly DesignatedPersonService _designatedPersonService;

        public DesignatedPersonController(DesignatedPersonService designatedPersonService)
        {
            _designatedPersonService = designatedPersonService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _designatedPersonService.GetDesignatedPersonAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DesignatedPersonModel designatedPersonModel)
        {
            var result = await _designatedPersonService.CreateDesignatedPersonAsync(designatedPersonModel);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]DesignatedPersonModel designatedPersonModel)
        {
            await _designatedPersonService.UpdateDesignatedPersonAsync(designatedPersonModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _designatedPersonService.DeleteDesignatedPersonAsync(id);
            return Ok();
        }
    }
}